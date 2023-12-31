using BusinessEntities;
using Database.Interfaces;
using Database.Repository.InMemoryRepo;

namespace TaskListTest
{
    public class TaskListUnitTest
    {
        private readonly ITaskListTable _table;
        public TaskListUnitTest()
        {
            _table = new InMemoryTasklistTable();
        }

        [Fact]
        public async System.Threading.Tasks.Task TestInsertTaskList()
        {
            var newList = new BusinessEntities.TaskList("AddedList");

            await _table.AddAsync(newList);

            var retrievedList = await _table.GetByIdAsync(newList.id);
            Assert.NotNull(retrievedList);
            Assert.Equal("AddedList", retrievedList.displayName);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestUpdateTaskList()
        {
            var allTaskList = await _table.GetAllAsync();
            var singleTaskList = await _table.GetByIdAsync(allTaskList[0].id);

            singleTaskList.displayName = allTaskList[0].displayName + "Updated";
            await _table.UpdateAsync(singleTaskList.id, singleTaskList);

            var retrievedList = await _table.GetByIdAsync(singleTaskList.id);
            Assert.NotNull(retrievedList);
            Assert.Equal(retrievedList.displayName, singleTaskList.displayName);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestReadTaskList()
        {
            var allTaskList = await _table.GetAllAsync();
            var singleList = await _table.GetByIdAsync(allTaskList[0].id);

            Assert.NotNull(allTaskList);
            Assert.NotNull(singleList);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestDeleteTaskList()
        {
            // Arrange: Create and add a TaskList
            var taskList = new BusinessEntities.TaskList("Test List for Deletion");
            await _table.AddAsync(taskList);

            // Act: Delete the TaskList
            await _table.DeleteAsync(taskList.id);

            var retrievedList = await _table.GetByIdAsync(taskList.id);
            Assert.Null(retrievedList);
        }


    }
}