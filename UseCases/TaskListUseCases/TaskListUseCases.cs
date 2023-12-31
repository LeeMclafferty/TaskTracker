using UseCases.TaskList;
using BusinessEntities;
using Database.Interfaces;

namespace UseCases.TaskListUseCases
{
    public class TaskListUseCases
    {
        // public use case commands
        private CreateTaskList CreateTaskList;
        private DeleteTaskList DeleteTaskList;
        private UpdateTaskList UpdateTaskList;
        private GetTaskList GetTaskList;
        public TaskListUseCases(ITaskListTable table) 
        {
            CreateTaskList = new CreateTaskList(table);
            DeleteTaskList = new DeleteTaskList(table);
            UpdateTaskList = new UpdateTaskList(table);
            GetTaskList = new GetTaskList(table);
        }

        public async System.Threading.Tasks.Task Create(BusinessEntities.TaskList newTaskList)
        {
            await CreateTaskList.Execute(newTaskList);
        }

        public async System.Threading.Tasks.Task Delete(int listId)
        {
            await DeleteTaskList.Execute(listId);
        }

        public async System.Threading.Tasks.Task Update(int listId, BusinessEntities.TaskList updatedList)
        {   
            await UpdateTaskList.Execute(listId, updatedList);
        }

        public async System.Threading.Tasks.Task<BusinessEntities.TaskList> GetList(int listId)
        {
            return await GetTaskList.GetSingle(listId);
        }

        public async System.Threading.Tasks.Task<List<BusinessEntities.TaskList>> GetLists()
        {
            return await GetTaskList.GetAll();
        }

    }
}
