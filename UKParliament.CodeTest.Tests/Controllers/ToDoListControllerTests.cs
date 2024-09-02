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

        private ITodoListService _todoListService;

        private ToDoListController _testclass;

        //setup 
        public void TodoListControllerTests()
        {
            _todoListService = A.Fake<TodoListService>();
            _testclass = new ToDoListController(_todoListService);

        }

        //[Fact]
        //public void CanConstruct()
        //{
        //    // Act
        //    var instance = _testclass;

        //    // Assert
        //    Assert.NotNull(instance);
        //}

        [Fact]
        public void CannotConstructWithNullTodoListService()
        {
            Assert.Throws<ArgumentNullException>(() => new ToDoListController(default(ITodoListService)));
        }

        // GetToList_Success
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

}
