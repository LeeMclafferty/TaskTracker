using BusinessEntities;
using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskTracker.Navigation;
using TaskTracker.Views;
using UseCases.TaskListUseCases;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using TaskTracker.ContentViews;
using Microsoft.Extensions.DependencyInjection;

namespace TaskTracker.ViewModels
{
    public partial class TaskListViewModel : ObservableObject
    {
        /* -- Public Variables -- */
        [ObservableProperty]
        public ObservableCollection<BusinessEntities.TaskList> taskListCollection;
        [ObservableProperty]
        public string? listName;
        [ObservableProperty]
        public string searchParams = string.Empty;

        /* -- Private Variables -- */
        private readonly TaskListUseCases taskListUseCases;
        private readonly IPopupService popupService;

        /* -- Public Functions -- */
        public TaskListViewModel(TaskListUseCases cases, IPopupService popupService) 
        { 
            taskListUseCases = cases;
            this.popupService = popupService;
            TaskListCollection = new ObservableCollection<BusinessEntities.TaskList>();
        }

        [RelayCommand]
        async System.Threading.Tasks.Task DeleteTaskList(BusinessEntities.TaskList listToDelete)
        {
            await taskListUseCases.Delete(listToDelete.id);
            await LoadAllTaskList();
        }

        public async System.Threading.Tasks.Task LoadAllTaskList(string filter = "")
        {
            TaskListCollection.Clear();
            var buffer = await taskListUseCases.GetLists();

            foreach (BusinessEntities.TaskList list in buffer)
            {
                if (string.IsNullOrWhiteSpace(filter) || list.displayName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                { 
                    if (!TaskListCollection.Any(t => t.id == list.id))
                        TaskListCollection.Add(list);
                }
            }
        }

        [RelayCommand]
        public void ShowPopupEditView(BusinessEntities.TaskList list)
        {
            var popup = new EditTaskListPopup(new UpdateTaskListViewModel(taskListUseCases), list.id, this);
            Shell.Current.CurrentPage.ShowPopup(popup);
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToAddTaskListView()
        {
            await ViewNavigation.NavigateToPageAsync(nameof(AddTaskListView));
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToAddTaskView(int id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", id.ToString());
            await ViewNavigation.NavigateToPageAsync(nameof(SingleTaskView), parameters);
        }

        public async System.Threading.Tasks.Task SearchTaskListCollection(string filter)
        {
            await LoadAllTaskList(filter);
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToReport()
        {
            await ViewNavigation.NavigateToPageAsync(nameof(ReportView));
        }

        /* -- Private Function -- */
    }
}
