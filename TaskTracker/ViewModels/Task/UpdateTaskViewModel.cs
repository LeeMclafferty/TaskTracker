using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskTracker.Navigation;
using TaskTracker.Views;
using UseCases.TaskUseCases;

namespace TaskTracker.ViewModels
{
    public partial class UpdateTaskViewModel : ObservableObject
    {
        /* -- Public Variables -- */
        [ObservableProperty]
        BusinessEntities.Task? selectedTask;

        /* -- Private Variables -- */
        private readonly TaskUseCases taskUseCases;

        /* -- Public Functions -- */
        public UpdateTaskViewModel(TaskUseCases cases)
        {
            taskUseCases = cases;
        }

        public async System.Threading.Tasks.Task SetSelectedTask(int id)
        {
            SelectedTask = await taskUseCases.GetSingleTask(id);
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task UpdateTask()
        {
            if (SelectedTask == null) return;
            SelectedTask.changedDate = DateTime.Now;
            string deviceModel = DeviceInfo.Model;
            string manufacturer = DeviceInfo.Manufacturer;
            SelectedTask.deviceName = $"{manufacturer} {deviceModel}";
            await taskUseCases.Update(SelectedTask.id, SelectedTask);
            await GoToSingleTaskView();
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task GoToSingleTaskView()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Id", SelectedTask.taskListId.ToString());
            await ViewNavigation.NavigateToPageAsync(nameof(SingleTaskView), parameters);
        }
        /* -- Private Functions-- */
    }
}
