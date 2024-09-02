namespace UKParliament.CodeTest.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using FakeItEasy;
    using Microsoft.Extensions.Logging;
    using UKParliament.CodeTest.Data;
    using UKParliament.CodeTest.Data.DTO;
    using UKParliament.CodeTest.Data.Entities;
    using UKParliament.CodeTest.Services;
    using Xunit;

    public class ToDoItemValidatorTests
    {
        private ToDoItemValidator _testclass;


        //setup 
        public ToDoItemValidatorTests()
        {
            _testclass = new ToDoItemValidator();

        }

        [Fact]
        public void CanCallValidateToDoItem()
        {
            // Arrange
            var item = new TodoItem
            {
                Id = 766020939,
                Title = "TestValue18696715",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.Empty(result);
        }

        [Fact]
        public void CanCallValidateToDoItem_ValidationFail_EmptyTitle()
        {
            // Arrange
            var item = new TodoItem
            {
                Id = 766020939,
                Title = "",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item must have a title", result);
        }

        [Fact]
        public void CanCallValidateToDoItem_ValidationFail_LengthyTitle()
        {
            // Arrange
            var item = new TodoItem
            {
                Id = 766020939,
                Title = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Title must be less than 100 characters", result);
        }

        [Fact]
        public void CanCallValidateToDoItem_ValidationFail_LengthyDescription()
        {
            // Arrange
            var item = new TodoItem
            {
                Id = 766020939,
                Title = "abcdefghijklmnopqrstuvwxyz-abcdefghijklm",
                Description = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Description must be less than 500 characters", result);
        }

        [Fact]
        public void CanCallValidateToDoItem_ValidationFail_MultipleErrors()
        {
            // Arrange
            var item = new TodoItem
            {
                Id = 766020939,
                Title = "",
                Description = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Description must be less than 500 characters", result);
            Assert.Contains("To Do Item must have a title", result);
        }

        // can't test for bool and datetime as it doesn't let you pass in invalid values before you get to this point

        [Fact]
        public void CanCallValidateCreateToDoItem()
        {
            // Arrange
            var item = new CreateTodoRequestDTO
            {
                Title = "TestValue18696715",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateCreateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.Empty(result);
        }

        [Fact]
        public void CanCallValidateCreateToDoItem_ValidationFail_EmptyTitle()
        {
            // Arrange
            var item = new CreateTodoRequestDTO
            {
                Title = "",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateCreateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item must have a title", result);
        }

        [Fact]
        public void CanCallValidateCreateToDoItem_ValidationFail_LengthyTitle()
        {
            // Arrange
            var item = new CreateTodoRequestDTO
            { 
                Title = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateCreateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Title must be less than 100 characters", result);
        }

        [Fact]
        public void CanCallValidateCreateToDoItem_ValidationFail_LengthyDescription()
        {
            // Arrange
            var item = new CreateTodoRequestDTO
            {
                Title = "abcdefghijklmnopqrstuvwxyz-abcdefghijklm",
                Description = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateCreateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Description must be less than 500 characters", result);
        }

        [Fact]
        public void CanCallValidateCreateToDoItem_ValidationFail_MultipleErrors()
        {
            // Arrange
            var item = new CreateTodoRequestDTO
            {
                Title = "",
                Description = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateCreateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Description must be less than 500 characters", result);
            Assert.Contains("To Do Item must have a title", result);
        }

        // can't test for bool and datetime as it doesn't let you pass in invalid values before you get to this point

        [Fact]
        public void CanCallValidateUpdateToDoItem()
        {
            // Arrange
            var item = new UpdateTodoRequestDTO
            {
                Title = "TestValue18696715",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateUpdateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.Empty(result);
        }

        [Fact]
        public void CanCallValidateUpdateToDoItem_ValidationFail_LengthyTitle()
        {
            // Arrange
            var item = new UpdateTodoRequestDTO
            {
                Title = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                Description = "TestValue1869624715",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateUpdateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Title must be less than 100 characters", result);
        }

        [Fact]
        public void CanCallValidateUpdateToDoItem_ValidationFail_LengthyDescription()
        {
            // Arrange
            var item = new UpdateTodoRequestDTO
            {
                Title = "abcdefghijklmnopqrstuvwxyz-abcdefghijklm",
                Description = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateUpdateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Description must be less than 500 characters", result);
        }

        [Fact]
        public void CanCallValidateUpdateToDoItem_ValidationFail_MultipleErrors()
        {
            // Arrange
            var item = new UpdateTodoRequestDTO
            {
                Title = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                Description = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            };

            // Act
            var result = _testclass.ValidateUpdateToDoItem(item);

            // Assert
            // Result will be empty unless there is an error
            Assert.NotEmpty(result);
            // To check for that specific expected error 
            Assert.Contains("To Do Item Description must be less than 500 characters", result);
            Assert.Contains("To Do Item Title must be less than 100 characters", result);
        }

        // can't test for bool and datetime as it doesn't let you pass in invalid values before you get to this point


        [Fact]
        public void CannotCallValidateToDoItemWithNullItem()
        {
            Assert.Throws<NullReferenceException>(() => _testclass.ValidateToDoItem(default(TodoItem)));
        }
    }




}
