using TaskTracker.ViewModels;

namespace TaskTracker.Views
{
	public partial class AddTaskListView : ContentPage
	{
		/* -- Private Variables -- */
		private readonly AddTaskListViewModel vm;

		/* Public Functions*/
		public AddTaskListView(AddTaskListViewModel viewmodel)
		{
			InitializeComponent();
			vm = viewmodel;
			BindingContext = vm;
		}
	}
}