using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Database.Interfaces;

namespace UseCases.TaskUseCases
{
    public class TaskUseCases
    {
        private CreateTask CreateTask;
        private DeleteTask DeleteTask;
        private UpdateTask UpdateTask;
        private GetTask GetTask;

        public TaskUseCases(ITaskTable table)
        {
            CreateTask = new CreateTask(table);
            DeleteTask = new DeleteTask(table);
            UpdateTask = new UpdateTask(table); 
            GetTask = new GetTask(table);
        }

        public async System.Threading.Tasks.Task Create(BusinessEntities.Task newTask)
        {
            await CreateTask.Execute(newTask);
        }
        
        public async System.Threading.Tasks.Task Delete(int taskId)
        {
            await DeleteTask.Execute(taskId);
        }

        public async System.Threading.Tasks.Task Update(int taskId, BusinessEntities.Task updatedTask)
        { 
            await UpdateTask.Execute(taskId, updatedTask);
        }

        public async System.Threading.Tasks.Task<BusinessEntities.Task> GetSingleTask(int taskId)
        {
            return await GetTask.GetSingleTask(taskId);
        }

        public async System.Threading.Tasks.Task<List<BusinessEntities.Task>> GetAllTask(int parentId)
        {
            return await GetTask.GetAllTask(parentId);
        }
        public async System.Threading.Tasks.Task<List<BusinessEntities.Task>> GetAllTask()
        {
            return await GetTask.GetAllTask();
        }
    }
}
