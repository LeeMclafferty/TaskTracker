using Database.Interfaces;
using Database.Repository;

namespace UseCases.TaskListUseCases
{
    public class GetTaskList
    {
        private readonly ITaskListTable table = new Database.Repository.TaskList();
        public GetTaskList(ITaskListTable listTable) 
        {
            table = listTable;
        }

        public async Task<BusinessEntities.TaskList> GetSingle(int taskListId)
        {
            return await table.GetByIdAsync(taskListId);
        }

        public async Task<List<BusinessEntities.TaskList>> GetAll()
        {
            return await table.GetAllAsync();
        }
    }
}
