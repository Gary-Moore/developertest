namespace UKParliament.CodeTest.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FakeItEasy;
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
        private ToDoListController _testClass;
        private ILogger<ToDoListController> _logger;
        private ITodoListService _todoListService;
        private ITodoListRepository _todoListRepository;
        private TodoListContext _todoContext;

        public ToDoListControllerTests()
        {
            _logger = A.Fake<ILogger<ToDoListController>>();
            _todoListService = A.Fake<ITodoListService>();
            _todoListRepository = A.Fake<ITodoListRepository>();
            _todoContext = new TodoListContext(new DbContextOptions<TodoListContext>());
            _testClass = new ToDoListController(_todoListService);
        }


        //[Fact]
        //public async Task CanCallGetToDoList_AndGetResult()
        //{
        //    // Arrange
        //    // Act
        //    var result = await _testClass.GetToDoList();

        //    // Assert
        //    // just checking it has made the call, is this actually verifying that you have a useful result though?
        //    //not entirely sure this is testing it properly, need to look at again
        //    Assert
        //        .Contains("Successfully retrieved To Do List!", (IEnumerable<string>)result);

        //}
    }
}