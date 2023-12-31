using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskTracker.Navigation;
using UseCases.TaskListUseCases;
using UseCases.TaskUseCases;

namespace TaskTracker.ViewModels
{
    public partial class ReportViewModel : ObservableObject
    {
        /* -- Public Variables -- */
        [ObservableProperty]
        public ObservableCollection<BusinessEntities.TaskList> taskListCollection;
        [ObservableProperty]
        public ObservableCollection<BusinessEntities.Task> taskCollection;

        /* -- Private Variables -- */
        private readonly TaskListUseCases taskListUseCases;
        private readonly TaskUseCases taskUseCases;
        
        public ReportViewModel(TaskListUseCases cases, TaskUseCases taskCases) 
        {
            taskListUseCases = cases;
            taskUseCases = taskCases;
            taskListCollection = new ObservableCollection<BusinessEntities.TaskList>();
            taskCollection = new ObservableCollection<BusinessEntities.Task>();
        }

        public async System.Threading.Tasks.Task LoadAll()
        {
            await LoadTask();
            await LoadTaskList();
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GetAssociatedTask(int id)
        {
            var tasks = await taskUseCases.GetAllTask(id);
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToTaskListView()
        {
            await ViewNavigation.NavigateToPageAsync(nameof(TaskListView));
        }

        private async System.Threading.Tasks.Task LoadTaskList()
        {
            var buffer = await taskListUseCases.GetLists();

            foreach (BusinessEntities.TaskList list in buffer)
            {
                foreach (var task in TaskCollection) 
                { 
                    if(task.taskListId == list.id)
                    {
                        list.AssociatedTask.Add(task);
                    }
                }
                if (!TaskListCollection.Any(t => t.id == list.id))
                    TaskListCollection.Add(list);
            }
        }

        private async System.Threading.Tasks.Task LoadTask()
        {
            var buffer = await taskUseCases.GetAllTask();

            foreach (BusinessEntities.Task task in buffer)
            {
                if (!TaskCollection.Any(t => t.id == task.id))
                {
                    TaskCollection.Add(task);
                }
            }
        }
    }
}
