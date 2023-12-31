using TaskTracker.ContentViews;
using TaskTracker.Views;

namespace TaskTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TaskListView), typeof(TaskListView));
            Routing.RegisterRoute(nameof(AddTaskListView), typeof(AddTaskListView));
            Routing.RegisterRoute(nameof(EditTaskListPopup), typeof(EditTaskListPopup));
            
            Routing.RegisterRoute(nameof(SingleTaskView), typeof(SingleTaskView));
            Routing.RegisterRoute(nameof(AddTaskView), typeof(AddTaskView));
            Routing.RegisterRoute(nameof(UpdateTaskView), typeof(UpdateTaskView));

            Routing.RegisterRoute(nameof(ReportView), typeof(ReportView));

        }
    }
}
