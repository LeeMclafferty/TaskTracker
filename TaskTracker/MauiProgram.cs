using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using TaskTracker.Views;
using Database.Interfaces;
using Database.Repository;
using UseCases.TaskListUseCases;
using UseCases.TaskUseCases;
using TaskTracker.ViewModels;
using TaskTracker.ContentViews;

namespace TaskTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.UseMauiCommunityToolkit();

            // Register views
            builder.Services.AddSingleton<TaskListView>();
            builder.Services.AddSingleton<SingleTaskView>();
            builder.Services.AddTransient<AddTaskListView>();
            builder.Services.AddTransient<EditTaskListPopup>();
            builder.Services.AddTransient<AddTaskView>();
            builder.Services.AddTransient<UpdateTaskView>();
            builder.Services.AddTransient<ReportView>();

            // Dependency injection registration
            builder.Services.AddSingleton<ITaskListTable, Database.Repository.TaskList>();
            builder.Services.AddSingleton<ITaskTable, Database.Repository.Task>();

            builder.Services.AddTransient<TaskListUseCases>();
            builder.Services.AddTransient<TaskUseCases>();
            
            builder.Services.AddTransient<TaskListViewModel>();
            builder.Services.AddTransient<AddTaskListViewModel>();
            builder.Services.AddTransient<UpdateTaskListViewModel>();
            builder.Services.AddTransient<TaskViewModel>();
            builder.Services.AddTransient<AddTaskViewModel>();
            builder.Services.AddTransient<UpdateTaskViewModel>();
            builder.Services.AddTransient<ReportViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
