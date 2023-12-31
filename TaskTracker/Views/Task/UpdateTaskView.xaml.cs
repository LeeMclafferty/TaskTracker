using TaskTracker.ViewModels;

namespace TaskTracker.Views;

[QueryProperty(nameof(listIdString), "Id")]
public partial class UpdateTaskView : ContentPage
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
    private readonly UpdateTaskViewModel viewModel;

    /* -- Public Functions -- */
    public UpdateTaskView(UpdateTaskViewModel vm)
	{
		InitializeComponent();
        viewModel = vm;
        BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.SetSelectedTask(listId);
    }
}