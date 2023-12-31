using Database.Interfaces;

namespace UseCases.TaskUseCases
{
    internal class GetTask
    {
        private readonly ITaskTable table;

        public GetTask(ITaskTable taskTable)
        {
            table = taskTable;
        }
       
        public async Task<BusinessEntities.Task> GetSingleTask(int taskId)
        {
            return await table.GetByIdAsync(taskId);
        }
        public async Task<List<BusinessEntities.Task>> GetAllTask(int parentId)
        {
            return await table.GetAllAsync(parentId);
        }

        public async Task<List<BusinessEntities.Task>> GetAllTask()
        {
            return await table.GetAllAsync();
        }
    }
}
