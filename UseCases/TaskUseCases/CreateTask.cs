using Database.Interfaces;
using Database.Repository;
using System.Threading.Tasks;

namespace UseCases.TaskUseCases
{
    public class CreateTask
    {
        private readonly ITaskTable table = new Database.Repository.Task();
        public CreateTask(ITaskTable taskTable)
        {
            table = taskTable;
        }

        public async System.Threading.Tasks.Task Execute(BusinessEntities.Task newTask)
        {
            await table.AddAsync(newTask);
        }
    }
}
