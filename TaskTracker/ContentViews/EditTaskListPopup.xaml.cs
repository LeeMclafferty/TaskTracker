using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using TaskTracker.ViewModels;
using UseCases.TaskListUseCases;
namespace TaskTracker.ContentViews;

public partial class EditTaskListPopup : Popup
{
	private readonly UpdateTaskListViewModel updateTaskListVm;
    public EditTaskListPopup(UpdateTaskListViewModel vm)
	{
		InitializeComponent();
		updateTaskListVm = vm;
		BindingContext = updateTaskListVm;
	}

    public EditTaskListPopup(UpdateTaskListViewModel vm, int selectedTaskListId, TaskListViewModel taskListVm)
    {
        InitializeComponent();
        updateTaskListVm = vm;
        BindingContext = updateTaskListVm;
        _ = updateTaskListVm.SetSelectedTaskList(selectedTaskListId);
        updateTaskListVm.SetPopup(this);
        updateTaskListVm.SetTaskListVm(taskListVm);
    }

}