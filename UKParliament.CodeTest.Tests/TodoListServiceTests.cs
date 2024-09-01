namespace UKParliament.CodeTest.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AutoMapper;
    using FakeItEasy;
    using Microsoft.Extensions.Logging;
    using UKParliament.CodeTest.Data;
    using UKParliament.CodeTest.Data.DTO;
    using UKParliament.CodeTest.Data.Entities;
    using UKParliament.CodeTest.Services;
    using Xunit;

    public class TodoListServiceTests
    {
        private TodoListService todoListService;

        private ITodoListRepository FakeRepository;
        private ILogger<TodoListService> FakeLogger;
        private IMapper FakeMapper; 

        //setup 
        public TodoListServiceTests()
        {
            FakeRepository = A.Fake<ITodoListRepository>();
            FakeLogger = A.Fake<ILogger<TodoListService>>();
            FakeMapper = A.Fake<IMapper>();

            todoListService = new TodoListService(FakeRepository, FakeLogger, FakeMapper);

            A.CallTo(() => FakeRepository.GetList()).Returns([
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

        }

        [Fact]
        public async Task CanCallGetListAsync_ReturnsList()
        {
            // Arrange - repo call faked in setup above     

            // Act
            var result = await todoListService.GetListAsync();

            // Assert
            A.CallTo(() => FakeRepository.GetList()).MustHaveHappened();
        


        }

        [Fact]
        public async Task CallGetListAsync_NoList_Exception()
        {
            // Arrange 
            A.CallTo(() => FakeRepository.GetList()).Throws<FileNotFoundException>();

            // Act
            // Assert
            await Assert.ThrowsAsync<FileNotFoundException>(() => todoListService.GetListAsync()); 



        }

        [Fact]
        public async Task GetByIdAsync_ReturnsToDoItem()
        {
            //Arrange
            A.CallTo(() => FakeRepository.GetById(1)).Returns(new TodoItem
            {
                Id = 1,
                Title = "TestValue2118389539",
                Description = "TestValue78583088",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            });

            //Act
            var result = await todoListService.GetByIdAsync(1);

            //Assert
            Assert.IsType<TodoItem>(result);
        }

        [Fact]
        public async Task GetByIdAsyncNotFound_ReturnsNull()
        {
            //Arrange
            A.CallTo(() => FakeRepository.GetById(1))
                .Returns(Task.FromResult((TodoItem)null));

            //Act
            var result = await todoListService.GetByIdAsync(1);

            //Assert
            Assert.Null(result);
        }

        //[Fact]
        //public async Task AddToDoAsync_SavesChanges()
        //{
        //    //Arrange
        //    var todo = new TodoItem
        //    {
        //        Id = 158,
        //        Title = "TestValue2018133201",
        //        Description = "TestValue1206707915",
        //        IsComplete = false,
        //        DueDate = new DateTime(2024, 08, 23)
        //    };

        //    var todoCreateTodoRequestDTO = new CreateTodoRequestDTO
        //    {
        //        Title = "TestValue2018133201",
        //        Description = "TestValue1206707915",
        //        IsComplete = false,
        //        DueDate = new DateTime(2024, 08, 23)
        //    };
        //    A.CallTo(() => FakeRepository.SaveChangesAsync(todo))
        //        .Returns(Task.FromResult((TodoItem)null));

        //    //Act
        //    var result = await todoListService.AddToDoAsync(todoCreateTodoRequestDTO);

        //    //Assert
        //    Assert.Null(result);
        //}

        //// what causes this to fail? mapping going wrong, passing in a null object? Not sure how to mock these eventualities
        //[Fact]
        //public async Task AddTodoAsync_Fails_Exception()
        //{
        //    // Arrange 
        //    var todo = new TodoItem
        //    {
        //        Id = 158,
        //        Title = "",
        //        Description = "TestValue1206707915",
        //        IsComplete = false,
        //        DueDate = new DateTime(2024, 08, 23)
        //    };

        //    A.CallTo(() => FakeRepository.Insert((TodoItem)(object(null)).Throws<Exception>();

        //    // Act
        //    // Assert
        //    await Assert.ThrowsAsync<Exception>(() => todoListService.AddToDoAsync((CreateTodoRequestDTO)(object)null));



        //}
    }
}
