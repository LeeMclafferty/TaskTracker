using Database.Interfaces;

namespace Database.Repository.InMemoryRepo
{
    public class InMemoryTaskTable : InMemoryRepository, ITaskTable
    {
        public async System.Threading.Tasks.Task AddAsync(BusinessEntities.Task task)
        {
            await database.InsertAsync(task);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int taskId)
        {
            await database.ExecuteAsync("DELETE FROM Task WHERE id = ?", taskId);
        }

        public async Task<List<BusinessEntities.Task>> GetAllAsync(int parentId)
        {
            await InitializeDatabase();
            return await database.Table<BusinessEntities.Task>()
                .Where(task => task.taskListId == parentId)
                .ToListAsync();
        }

        public async Task<List<BusinessEntities.Task>> GetAllAsync()
        {
            await InitializeDatabase();
            return await database.QueryAsync<BusinessEntities.Task>("SELECT * FROM Task");
        }

        public async Task<BusinessEntities.Task> GetByIdAsync(int taskId)
        {
            BusinessEntities.Task returnedTask = await database.Table<BusinessEntities.Task>().Where(x => x.id == taskId).FirstOrDefaultAsync();
            return returnedTask;
        }

        public async System.Threading.Tasks.Task UpdateAsync(int taskId, BusinessEntities.Task taskChanges)
        {
            if (taskId == taskChanges.id)
            {
                await database.UpdateAsync(taskChanges);
            }
        }
    }
}
