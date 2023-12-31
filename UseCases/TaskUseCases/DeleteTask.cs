using Database.Interfaces;

namespace UseCases.TaskUseCases
{
    internal class DeleteTask
    {
        private readonly ITaskTable table;
        public DeleteTask(ITaskTable taskTable)
        {
            table = taskTable;
        }

        public async Task Execute(int taskId)
        {
           await table.DeleteAsync(taskId);
        }
    }
}
