namespace Database.Interfaces
{
    public interface ITaskTable
    {
        Task AddAsync(BusinessEntities.Task task);
        Task DeleteAsync(int taskId);
        Task UpdateAsync(int taskId, BusinessEntities.Task taskChanges);
        Task<BusinessEntities.Task> GetByIdAsync(int taskId);
        Task<List<BusinessEntities.Task>> GetAllAsync(int parentId);
        Task<List<BusinessEntities.Task>> GetAllAsync();
    }
}
