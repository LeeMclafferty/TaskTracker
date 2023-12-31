using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BusinessEntities
{
    public partial class TaskList : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [Required]
        public string displayName { get; set; }

        [AllowNull]
        public string deviceName { get; set; }

        [AllowNull]
        public DateTime changedDate { get; set; }

        public TaskList()
        {
            displayName = string.Empty;
            AssociatedTask = new ObservableCollection<Task>();
        }

        public TaskList(string name)
        {
            displayName = name;
            AssociatedTask = new ObservableCollection<Task>();
        }

        public TaskList(string name, int taskId)
        {
            displayName = name;
            id = taskId;
            AssociatedTask = new ObservableCollection<Task>();
        }

        private ObservableCollection<BusinessEntities.Task> _associatedTask;

        [Ignore]
        public ObservableCollection<BusinessEntities.Task> AssociatedTask
        {
            get => _associatedTask;
            set => SetProperty(ref _associatedTask, value);
        }
    }
}
