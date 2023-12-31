using SQLite;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BusinessEntities
{
    // All the code in this file is included in all platforms.
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        //Foreign Key
        [Required]
        public int taskListId { get; set; }

        [Required]
        public string displayName { get; set; }

        [AllowNull]
        public string description { get; set; }

        [AllowNull]
        public DateTime dueDate { get; set; }

        [Required]
        public bool isCompleted { get; set; }

        [AllowNull]
        public string deviceName { get; set; }

        [AllowNull]
        public DateTime changedDate { get; set; }

        public Task()
        {
            displayName = string.Empty;
        }

        public Task(string taskName)
        {
            displayName = taskName;
        }

        public Task(string taskName, string taskDesctiption, DateTime date, int parentId)
        {
            displayName = taskName;
            description = taskDesctiption;
            dueDate = date;
            taskListId = parentId;
            isCompleted = false;
        }
    }
}
