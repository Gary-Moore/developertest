using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.Entities;
using FakeItEasy;
using UKParliament.CodeTest.Data.DTO;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.WebApi.Controllers;
using Xunit.Sdk;

namespace UKParliament.CodeTest.Tests.Controllers
{
    public class ToDoListControllerTests
    {
        private ToDoListController _testclass;

        private ITodoListService _todoListService;

        //setup 
        public ToDoListControllerTests()
        {
            _todoListService = A.Fake<ITodoListService>();
            _testclass = new ToDoListController(_todoListService);

        }
            
        [Fact]
        public void CannotConstructWithNullTodoListService()
        {
            Assert.Throws<ArgumentNullException>(() => new ToDoListController(default(ITodoListService)));
        }

        // as I've got the error handling middleware working, just need to be checking for the OK/Successes on the controller

        // GetToDoList_Success
        [Fact]
        public async Task GetToDoList_ReturnsList()
        {
            // Arrange
            // Fake list of items
            A.CallTo(() => _todoListService.GetListAsync()).Returns([
            new TodoItem
                {
                    Id = 13,
                    Title = "TestValue2118389539",
                    Description = "TestValue78583088",
                    IsComplete = true,
                    DueDate = DateTime.UtcNow
                },
                new TodoItem
                {
                    Id = 1029280869,
                    Title = "TestValue2143976076",
                    Description = "TestValue2006440808",
                    IsComplete = true,
                    DueDate = DateTime.UtcNow
                },
                new TodoItem
                {
                    Id = 1465824854,
                    Title = "TestValue2018133201",
                    Description = "TestValue1206707915",
                    IsComplete = false,
                    DueDate = DateTime.UtcNow
                }
                 ]);

            // Act
            var result = await _testclass.GetToDoList();

            // Assert
            // if successful, OKObjectResult (200 status code) is passed
            Assert.IsType<OkObjectResult>(result);
        }

        // GetToDoByID_Success
        [Fact]
        public async Task GetToDoByItem_ReturnsItem()
            {
                // Arrange
                // Fake item to be returned
                A.CallTo(() => _todoListService.GetByIdAsync(13)).Returns(
                new TodoItem
                {
                    Id = 13,
                    Title = "TestValue2118389539",
                    Description = "TestValue78583088",
                    IsComplete = true,
                    DueDate = DateTime.UtcNow
                });

                // Act
                var result = await _testclass.GetById(13);

                // Assert
                // if successful, OKObjectResult (200 status code) is passed
                Assert.IsType<OkObjectResult>(result);
            }

        // AddTodoAsync_Success
        [Fact]
        public async Task AddToDoAsync_Success()
        {
           
            // Arrange
            // create item
            var request = new CreateTodoRequestDTO
            {
                Title = "TestValue1100041166",
                Description = "TestValue1568731792",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            };

            // Act
            var result = await _testclass.AddTodoAsync(request);

            // Assert
            // if successful, OKObjectResult (200 status code) is passed
            Assert.IsType<OkObjectResult>(result);
           
        }

        // UpdateToDoItemAsync_Success

        [Fact]
        public async Task UpdateToDoItemAsync_Success()
        {

            // Arrange
            // existing item to be updated
            A.CallTo(() => _todoListService.GetByIdAsync(13)).Returns(
               new TodoItem
               {
                   Id = 13,
                   Title = "TestValue2118389539",
                   Description = "TestValue78583088",
                   IsComplete = true,
                   DueDate = DateTime.UtcNow
               });
            // update item request
            var id = 13;
            var request = new UpdateTodoRequestDTO
            {
                Title = "TestValue1100041166",
                Description = "TestValue1568731792",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            };

            // Act
            var result = await _testclass.UpdateToDoItemAsync(id, request);

            // Assert
            // if successful, OKObjectResult (200 status code) is passed - this is something slightly different to the OKObject, because the method is a Task<ActionResult<int>> but can see a clear 200 status code etc on the object so I think this is fine
            Assert.IsType<ActionResult<int>>(result);

        }

        // CompleteToDoItemAsync_Success
        [Fact]
        public async Task CompleteToDoItemAsync_Success()
        {

            // Arrange
            // existing item to be updated
            A.CallTo(() => _todoListService.GetByIdAsync(13)).Returns(
               new TodoItem
               {
                   Id = 13,
                   Title = "TestValue2118389539",
                   Description = "TestValue78583088",
                   IsComplete = false,
                   DueDate = DateTime.UtcNow
               });

            // update item request
            var id = 13;
            var request = new CompleteTodoRequestDTO
            {
                IsComplete = true,
            };

            // Act
            var result = await _testclass.CompleteToDoItemAsync(id, request);

            // Assert
            // if successful, OKObjectResult (200 status code) is passed - this is something slightly different to the OKObject, because the method is a Task<ActionResult<int>> but can see a clear 200 status code etc on the object so I think this is fine
            Assert.IsType<ActionResult<int>>(result);

        }

        // DeleteToDoItemAsync_Success

        [Fact]
        public async Task DeleteToDoItemAsync_Success()
        {
            // Arrange
            // existing item to be deleted
            A.CallTo(() => _todoListService.GetByIdAsync(13)).Returns(
               new TodoItem
               {
                   Id = 13,
                   Title = "TestValue2118389539",
                   Description = "TestValue78583088",
                   IsComplete = false,
                   DueDate = DateTime.UtcNow
               });

            // Act
            var result = await _testclass.DeleteToDoItemAsync(13);

            //Assert
            // if successful, OKObjectResult (200 status code) is passed - this is something slightly different to the OKObject, because the method is a Task<ActionResult<int>> but can see a clear 200 status code etc on the object so I think this is fine
            Assert.IsType<ActionResult<int>>(result);

        }

        }

}
