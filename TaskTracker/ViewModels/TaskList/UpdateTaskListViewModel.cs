using BusinessEntities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskTracker.ContentViews;
using UseCases.TaskListUseCases;

namespace TaskTracker.ViewModels
{

    public partial class UpdateTaskListViewModel : ObservableObject
    {
        /* -- Public Variables -- */
        [ObservableProperty]
        public string? listName;
        public TaskList? selectedTaskList {  get; private set; }

        /* -- Private Variables -- */
        private readonly TaskListUseCases taskListUseCases;
        private EditTaskListPopup? popup;
        private TaskListViewModel? taskListVm;

        /* -- Public Functions-- */
        public UpdateTaskListViewModel(TaskListUseCases useCases) 
        { 
            taskListUseCases = useCases;
        }

        [RelayCommand]
        public async System.Threading.Tasks.Task UpdateTaskList()
        {
            if (selectedTaskList == null || taskListVm == null) return;

            string deviceModel = DeviceInfo.Model;
            string manufacturer = DeviceInfo.Manufacturer;
            selectedTaskList.deviceName = $"{manufacturer} {deviceModel}";

            selectedTaskList.changedDate = DateTime.Now;

            await taskListUseCases.Update(selectedTaskList.id, selectedTaskList);
            ClosePopup();
            await taskListVm.LoadAllTaskList();
        }

        public async System.Threading.Tasks.Task SetSelectedTaskList(int id)
        {
            selectedTaskList = await taskListUseCases.GetList(id);
        }

        public void SetPopup(EditTaskListPopup currentPopup)
        {
            popup = currentPopup;
        }


        [RelayCommand]
        public void ClosePopup()
        {
            if(popup != null) 
            {
                popup.Close();
            }
        }

        public void SetTaskListVm(TaskListViewModel vm)
        {
            taskListVm = vm;
        }
    }
}
