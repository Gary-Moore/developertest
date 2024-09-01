namespace UKParliament.CodeTest.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using FakeItEasy;
    using Microsoft.Build.Logging;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using UKParliament.CodeTest.Data;
    using UKParliament.CodeTest.Data.DTO;
    using UKParliament.CodeTest.Data.Entities;
    using UKParliament.CodeTest.Services;
    using UKParliament.CodeTest.WebApi.Controllers;
    using Xunit;

    public class ToDoListControllerTests
    {

        private ITodoListService FaketodoListService;

        private ToDoListController ToDoListController;

        //setup 
        public void TodoListControllerTests()
        {
            FaketodoListService = A.Fake<TodoListService>();
            ToDoListController = new ToDoListController(FaketodoListService);
   
        }
        // GetToList_Success
        //[Fact]

        //public async Task GetList_Returns_Success()
        //{
        //    //Arrange

        //    var todolist = new TodoItem
        //        {
        //            Id = 13,
        //            Title = "TestValue2118389539",
        //            Description = "TestValue78583088",
        //            IsComplete = true,
        //            DueDate = DateTime.UtcNow
        //        };
        //    A.CallTo(() => FaketodoListService.GetListAsync()).Returns(Task.FromResult(todolist));

        //    // failing here, not even getting to the next lines of the test, really not sure why, says faked object is null when I am passing it values?

        //    //Act
        //    var result = await ToDoListController.GetToDoList();
        //    //Assert
        //    Assert.Contains("200", (IAsyncEnumerable<string>)result);

        }
        // GetToDoList_Fail_NotFound


        // GetToList_Fail_Generic
        // GetToDoByID_Success
        // GetToDoByID_FailNotFound
        // AddTodoAsync_Success
        // AddToDoAsync_Fail
        // UpdateToDoItemAsync_Success
        // UpdateToDoItemAsync_Fail_NotFound
        // UpdateToDoItemAsync_Fail_Generic
        // CompleteToDoItemAsync_Success
        // CompleteToDoItemAsync_Fail_NotFound
        // CompleteToDoItemAsync_Fail_Generic
        // DeleteToDoItemAsync_Success
        // DeleteToDoItemAsync_Fail_NotFound
        // DeleteToDoItemAsync_Fail_Generic
    }
