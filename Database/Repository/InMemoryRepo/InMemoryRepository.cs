using SQLite;
using BusinessEntities;

namespace Database.Repository.InMemoryRepo
{
    public class InMemoryRepository
    {
        //Public Variables 
        public SQLiteAsyncConnection database { get; private set; }

        //Private Variables

        public InMemoryRepository()
        {
            // Create DB at DataPath if it does not exist.
            database = new SQLiteAsyncConnection(":memory:");
            //_ = EmptyDatabaseAsync();
        }

        public async System.Threading.Tasks.Task InitializeDatabase()
        {
            await database.CreateTableAsync<BusinessEntities.Task>();
            await database.CreateTableAsync<BusinessEntities.TaskList>();
            CreateTestEntities();
        }

        private void CreateTestEntities()
        {
            List<BusinessEntities.TaskList> sampleTaskLists = new List<BusinessEntities.TaskList>
            {
                new BusinessEntities.TaskList("Task List 1"),
                new BusinessEntities.TaskList("Task List 2"),
                new BusinessEntities.TaskList("Task List 3"),
                new BusinessEntities.TaskList("Task List 4")
            };

            foreach (var taskList in sampleTaskLists)
            {
                var existingTaskList = database.Table<BusinessEntities.TaskList>()
                                                .Where(t => t.displayName == taskList.displayName)
                                                .FirstOrDefaultAsync().GetAwaiter().GetResult();

                if (existingTaskList == null) // Check uniqueness based on name
                {
                    database.InsertAsync(taskList).GetAwaiter().GetResult();

                    // Create 2 tasks for each TaskList with the correct taskListId
                    BusinessEntities.Task task1 = new BusinessEntities.Task("Task 1", "Description 1", DateTime.Now, taskList.id);
                    BusinessEntities.Task task2 = new BusinessEntities.Task("Task 2", "Description 2", DateTime.Now, taskList.id);

                    database.InsertAsync(task1).GetAwaiter().GetResult();
                    database.InsertAsync(task2).GetAwaiter().GetResult();
                }
            }
        }


        public async System.Threading.Tasks.Task EmptyDatabaseAsync()
        {
            // Delete all records from the Task and TaskList tables
            await database.DeleteAllAsync<BusinessEntities.Task>();
            await database.DeleteAllAsync<BusinessEntities.TaskList>();
        }

    }
}
