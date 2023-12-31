using Database.Interfaces;
using BusinessEntities;
using Database.Repository;

namespace UseCases.TaskListUseCases
{
    public class DeleteTaskList
    {

        private readonly ITaskListTable table = new Database.Repository.TaskList();
        public DeleteTaskList(ITaskListTable listTable)
        {
            table = listTable;
        }

        public async System.Threading.Tasks.Task Execute(int taskListId)
        {
            await table.DeleteAsync(taskListId);
        }
    }
}
