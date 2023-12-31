using System.Collections.Generic;
using TaskTracker.ViewModels;

namespace TaskTracker.Views;


[QueryProperty(nameof(listIdString), "Id")]
public partial class AddTaskView : ContentPage
{
    /* -- Public Variables -- */
    public string listIdString
    {
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out int taskListId))
            {
                listId = taskListId;
            }
        }
    }

    /* -- Private Variables -- */
    private int listId;
    private readonly AddTaskViewModel viewModel;
    /* -- Public Functions -- */
    public AddTaskView(AddTaskViewModel vm)
	{
		InitializeComponent();
        viewModel = vm;
        BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.SetParentListId(listId);
    }
}