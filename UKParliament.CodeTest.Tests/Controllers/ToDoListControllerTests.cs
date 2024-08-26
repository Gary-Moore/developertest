namespace UKParliament.CodeTest.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FakeItEasy;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using UKParliament.CodeTest.Data;
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
            _testClass = new ToDoListController(_logger, _todoListService, _todoListRepository, _todoContext);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ToDoListController(_logger, _todoListService, _todoListRepository, _todoContext);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullLogger()
        {
            Assert.Throws<ArgumentNullException>(() => new ToDoListController(default(ILogger<ToDoListController>), _todoListService, _todoListRepository, _todoContext));
        }

        [Fact]
        public void CannotConstructWithNullTodoListService()
        {
            Assert.Throws<ArgumentNullException>(() => new ToDoListController(_logger, default(ITodoListService), _todoListRepository, _todoContext));
        }

        [Fact]
        public void CannotConstructWithNullTodoListRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new ToDoListController(_logger, _todoListService, default(ITodoListRepository), _todoContext));
        }

        [Fact]
        public void CannotConstructWithNullTodoContext()
        {
            Assert.Throws<ArgumentNullException>(() => new ToDoListController(_logger, _todoListService, _todoListRepository, default(TodoListContext)));
        }

        [Fact]
        public async Task CanCallGet()
        {
            // Arrange
            A.CallTo(() => _todoListRepository.GetList()).Returns(new List<TodoItem>());

            // Act
            var result = await _testClass.Get();

            // Assert
            A.CallTo(() => _todoListRepository.GetList()).MustHaveHappened();

            //not entirely sure this is testing it properly, need to look at again
        }
    }
}