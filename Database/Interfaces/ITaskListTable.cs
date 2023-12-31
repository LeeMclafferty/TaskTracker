using BusinessEntities;
using Task = System.Threading.Tasks.Task;

namespace Database.Interfaces
{
    public interface ITaskListTable
    {
        Task AddAsync(BusinessEntities.TaskList newList);
        Task DeleteAsync(int taskListId);
        Task UpdateAsync(int taskListId, BusinessEntities.TaskList updatedList);
        Task<BusinessEntities.TaskList> GetByIdAsync(int taskListId);
        Task<List<BusinessEntities.TaskList>> GetAllAsync();
    }
}
