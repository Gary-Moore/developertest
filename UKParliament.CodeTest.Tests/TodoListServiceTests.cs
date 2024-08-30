namespace UKParliament.CodeTest.Tests
{
    using System;
    using System.Collections.Generic;
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

        ITodoListRepository FakeRepository;
        ILogger<TodoListService> FakeLogger;
        IMapper FakeMapper;
        TodoListService todoListService;


        [Fact]
        public async Task CanCallGetListAsync_ReturnsList()
        {
            // Arrange
            A.CallTo(() => FakeRepository.GetList()).Returns(new[] {
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
            });

            // Act
            var result = await todoListService.GetListAsync();

            // Assert
            A.CallTo(() => FakeRepository.GetList()).MustHaveHappened();
            Assert.NotNull(result);


        }
    }
}
