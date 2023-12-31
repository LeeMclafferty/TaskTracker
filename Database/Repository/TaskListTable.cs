using BusinessEntities;
using Database.Interfaces;
using Database.Repository.InMemoryRepo;

namespace Database.Repository
{
    public class TaskList : Repository, ITaskListTable
    {
        public async System.Threading.Tasks.Task AddAsync(BusinessEntities.TaskList newList)
        {
            await database.InsertAsync(newList);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int taskListId)
        {
            // Delete nested task and the list
            await database.ExecuteAsync("DELETE FROM Task WHERE taskListId = ?", taskListId);
            await database.ExecuteAsync("DELETE FROM TaskList WHERE id = ?", taskListId);
        }

        public async Task<List<BusinessEntities.TaskList>> GetAllAsync()
        {
            await InitializeDatabase();
            return await database.Table<BusinessEntities.TaskList>().ToListAsync();
        }

        public async Task<BusinessEntities.TaskList> GetByIdAsync(int taskListId)
        {
            return await database.Table<BusinessEntities.TaskList>().Where(x => x.id == taskListId).FirstOrDefaultAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(int taskListId, BusinessEntities.TaskList updatedList)
        {
            if (taskListId == updatedList.id)
            {
                await database.UpdateAsync(updatedList);
            }
        }
    }
}
