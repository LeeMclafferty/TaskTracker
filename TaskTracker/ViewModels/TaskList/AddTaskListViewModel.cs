using BusinessEntities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskTracker.Navigation;
using UseCases.TaskListUseCases;

namespace TaskTracker.ViewModels
{
    public partial class AddTaskListViewModel : ObservableObject
    {
        /* -- Public Variables -- */
        [ObservableProperty]
        public string? listName;

        /* -- Private Variables -- */
        private readonly TaskListUseCases taskListUseCases;


        /* -- Public Functions -- */
        public AddTaskListViewModel(TaskListUseCases cases)
        {
            taskListUseCases = cases;
        }

        [RelayCommand]
        async System.Threading.Tasks.Task AddTaskList()
        {
            if (string.IsNullOrEmpty(ListName))
                return;

            TaskList taskList = new TaskList(ListName);
            taskList.changedDate = DateTime.Today;

            string deviceModel = DeviceInfo.Model;
            string manufacturer = DeviceInfo.Manufacturer;
            taskList.deviceName = $"{manufacturer} {deviceModel}";

            await taskListUseCases.Create(taskList);
            await CancelAddTaskList();
        }
        
        [RelayCommand]
        async System.Threading.Tasks.Task CancelAddTaskList()
        {
            await ViewNavigation.NavigateToPageAsync(nameof(TaskListView));
        }
    }
}
