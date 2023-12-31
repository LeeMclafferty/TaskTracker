using Database.Interfaces;
using Database.Repository;
using BusinessEntities;

namespace UseCases.TaskListUseCases
{
    public class UpdateTaskList
    {
        private readonly ITaskListTable table = new Database.Repository.TaskList();
        public UpdateTaskList(ITaskListTable listTable) 
        {
            table = listTable;
        }

        public async System.Threading.Tasks.Task Execute(int id, BusinessEntities.TaskList updatedList)
        {
            await table.UpdateAsync(id, updatedList);
        }
    }
}
