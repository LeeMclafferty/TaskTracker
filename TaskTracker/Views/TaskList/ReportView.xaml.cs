using TaskTracker.ViewModels;

namespace TaskTracker.Views;

public partial class ReportView : ContentPage
{
    private readonly ReportViewModel viewModel;
    public ReportView(ReportViewModel vm)
	{
		InitializeComponent();
        viewModel = vm;
        BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.LoadAll();

        var test = viewModel.TaskListCollection;
        var test2 = viewModel.TaskCollection;
    }
}