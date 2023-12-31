using BusinessEntities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TaskTracker.Navigation;
using TaskTracker.Views;
using UseCases.TaskListUseCases;
using UseCases.TaskUseCases;

namespace TaskTracker.ViewModels
{
    public partial class TaskViewModel : ObservableObject
    {
        /* -- Public Variables -- */
        [ObservableProperty]
        private string pageTitle = string.Empty;
        [ObservableProperty]
        public ObservableCollection<BusinessEntities.Task> taskCollection;
        [ObservableProperty]
        public string searchParams = string.Empty;

        /* -- Private Variables -- */
        private readonly TaskUseCases taskUseCases;
        private readonly TaskListUseCases taskListUseCases;
        private TaskList? parentTaskList;

        /* -- Public Functions -- */
        public TaskViewModel(TaskUseCases cases, TaskListUseCases listCases)
        {
            taskUseCases = cases;
            taskListUseCases = listCases;
            TaskCollection = new ObservableCollection<BusinessEntities.Task>();
        }

        public async System.Threading.Tasks.Task SetParentTaskList(int id)
        {
            parentTaskList = await taskListUseCases.GetList(id);
            SetPageTitle();
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToAddTaskPage()
        {
            if (parentTaskList == null) return;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", parentTaskList.id.ToString());
            await ViewNavigation.NavigateToPageAsync(nameof(AddTaskView), parameters);
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task DeleteTask(BusinessEntities.Task task)
        {
            await taskUseCases.Delete(task.id);
            await LoadAllTask();
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToUpdateTaskPage(int id)
        {
            if (parentTaskList == null) return;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", id.ToString());
            await ViewNavigation.NavigateToPageAsync(nameof(UpdateTaskView), parameters);
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task MarkTaskCompleted(BusinessEntities.Task task)
        {
            if(!task.isCompleted)
            {
                await SetTaskToComplete(task);
            }
            else
            {
                await SetTaskToIncomplete(task);
            }
            await LoadAllTask();
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task SearchTaskCollection(string filter)
        {
            await LoadAllTask(filter);
        }

        public async System.Threading.Tasks.Task LoadAllTask(string filter = "")
        {
            TaskCollection.Clear();
            var buffer = await taskUseCases.GetAllTask(parentTaskList.id);

            foreach (BusinessEntities.Task task in buffer)
            {
                if ((string.IsNullOrWhiteSpace(filter) || task.displayName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    if (!TaskCollection.Any(t => t.id == task.id))
                    {
                        TaskCollection.Add(task);
                    }
                }
            }
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToTaskListsPage()
        {
            await ViewNavigation.NavigateToPageAsync(nameof(TaskListView));
        }

        /* -- Private Functions-- */
        private void SetPageTitle()
        {
            if (parentTaskList != null)
            {
                PageTitle = parentTaskList.displayName + " To-Do List";
            }
            else
            {
                PageTitle = "To-Do List";
            }
        }

        private async System.Threading.Tasks.Task SetTaskToComplete(BusinessEntities.Task task)
        {
            task.isCompleted = true;
            await taskUseCases.Update(task.id, task);
        }
        private async System.Threading.Tasks.Task SetTaskToIncomplete(BusinessEntities.Task task)
        {
            task.isCompleted = false;
            await taskUseCases.Update(task.id, task);
        }
    }
}
