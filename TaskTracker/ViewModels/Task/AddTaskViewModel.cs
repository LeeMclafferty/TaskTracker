using CommunityToolkit.Mvvm.ComponentModel;
using UseCases.TaskUseCases;
using BusinessEntities;
using TaskTracker.Navigation;
using TaskTracker.Views;
using CommunityToolkit.Mvvm.Input;

namespace TaskTracker.ViewModels
{
    public partial class AddTaskViewModel : ObservableObject
    {

        /* -- Public Variables -- */
        [ObservableProperty]
        public string taskName;
        [ObservableProperty]
        public string taskDescription;
        [ObservableProperty]
        DateTime dueDate;

        /* -- Private Variables -- */
        private readonly TaskUseCases taskUseCases;
        private int parentListId;

        /* -- Public Functions -- */
        public AddTaskViewModel(TaskUseCases cases)
        {
            taskUseCases = cases;
            DueDate = DateTime.Today;
        }

        public void SetParentListId(int id)
        {
            parentListId = id;
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task AddTask()
        {
            //TODO: Validate user input for title

            BusinessEntities.Task newTask = new BusinessEntities.Task(TaskName, TaskDescription, DueDate, parentListId);

            string deviceModel = DeviceInfo.Model;
            string manufacturer = DeviceInfo.Manufacturer;
            newTask.deviceName = $"{manufacturer} {deviceModel}";
            newTask.changedDate = DateTime.Now;

            await taskUseCases.Create(newTask);
            await CancelAddTask();
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task CancelAddTask()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", parentListId.ToString());
            await ViewNavigation.NavigateToPageAsync(nameof(SingleTaskView), parameters);
        }

        /* -- Private Functions-- */
    }
}
