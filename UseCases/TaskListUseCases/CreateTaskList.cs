using Database.Interfaces;
using Database.Repository;
using BusinessEntities;

namespace UseCases.TaskList
{
    // All the code in this file is included in all platforms.
    public class CreateTaskList
    {
        private readonly ITaskListTable table = new Database.Repository.TaskList();
        public CreateTaskList(ITaskListTable listTable) 
        {
            table = listTable;
        }

        public async System.Threading.Tasks.Task Execute(BusinessEntities.TaskList newTaskList)
        {
            await table.AddAsync(newTaskList);
        }
    }
}
