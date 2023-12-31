using SQLite;

namespace Database.Repository
{
    public class Repository
    {
        //Public Variables 
        public SQLiteAsyncConnection database { get; private set; }

        //Private Variables

        public Repository() 
        {
            // Create DB at DataPath if it does not exist.
            database = new SQLiteAsyncConnection(Constants.DataPath);
            _ = InitializeDatabase();
        }

        public async System.Threading.Tasks.Task InitializeDatabase()
        {
            await database.CreateTableAsync<BusinessEntities.Task>();
            await database.CreateTableAsync<BusinessEntities.TaskList>();
        }

    }
}
