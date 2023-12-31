using TaskTracker.ViewModels;

namespace TaskTracker.Views;

[QueryProperty(nameof(listIdString), "Id")]
public partial class SingleTaskView : ContentPage
{

    /* -- Public Variables--*/
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

    /* -- Private Variables--*/
    private int listId { get; set; }
    private readonly TaskViewModel taskViewModel;

    /* -- Public Functions--*/
    public SingleTaskView(TaskViewModel vm)
	{
		InitializeComponent();
        taskViewModel = vm;
        BindingContext = taskViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await taskViewModel.SetParentTaskList(listId);
        await taskViewModel.LoadAllTask();
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filter = e.NewTextValue;

        _ = taskViewModel.SearchTaskCollection(filter);
    }
}