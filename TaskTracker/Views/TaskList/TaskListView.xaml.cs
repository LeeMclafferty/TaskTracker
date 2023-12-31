using TaskTracker.ViewModels;

namespace TaskTracker
{
    public partial class TaskListView : ContentPage
    {
        /* -- Private Variables -- */
        private readonly TaskListViewModel viewModel;

        /* -- Public Functions -- */
        public TaskListView(TaskListViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
 
        }
        protected override async void OnAppearing()
        {
            await viewModel.LoadAllTaskList();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = e.NewTextValue;

            _ = viewModel.SearchTaskListCollection(filter);
        }
    }

}
