using Database.Interfaces;

namespace UseCases.TaskUseCases
{
    internal class UpdateTask
    {
        private readonly ITaskTable table;
        public UpdateTask(ITaskTable taskTable)
        {
            table = taskTable;
        }

        public async Task Execute(int taskId, BusinessEntities.Task updatedTask)
        {
            await table.UpdateAsync(taskId, updatedTask);
        }
    }
}
