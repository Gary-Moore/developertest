using AutoMapper;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.DTO;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Exceptions;

namespace UKParliament.CodeTest.Tests
{
    public class TodoListServiceTests
    {
        private TodoListService _testclass;

        private ITodoListRepository _repository;
        private ILogger<TodoListService> _logger;
        private IMapper _mapper;
        private IToDoItemValidator _validator;

        //setup 
        public TodoListServiceTests()
        {
            _validator = A.Fake<IToDoItemValidator>();
            _mapper = A.Fake<IMapper>();
            _logger = A.Fake<ILogger<TodoListService>>();
            _repository = A.Fake<ITodoListRepository>();

            _testclass = new TodoListService(_repository, _logger, _mapper, _validator);

        }

        [Fact]
        public async Task CanCallGetListAsync_ReturnsList()
        {
            // Arrange
            A.CallTo(() => _repository.GetList()).Returns([
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
            var result = await _testclass.GetListAsync();

            // checking that call to repo has happened
            // do I also need to check contents of what is returned? look for exceptions/failure messages?
            // Assert
            A.CallTo(() => _repository.GetList()).MustHaveHappened();
            
        }

        [Fact]
        public async Task CallGetListAsync_NoList_Exception()
        {
            // Arrange 
            A.CallTo(() => _repository.GetList()).Throws<FileNotFoundException>();

            // Act
            // Assert
            // checking that exception is raised when there is no list to return
            await Assert.ThrowsAsync<FileNotFoundException>(() => _testclass.GetListAsync());

        }

        [Fact]
        public async Task GetByIdAsync_ReturnsToDoItem()
        {
            //Arrange
            A.CallTo(() => _repository.GetById(1)).Returns(new TodoItem
            {
                Id = 1,
                Title = "TestValue2118389539",
                Description = "TestValue78583088",
                IsComplete = true,
                DueDate = DateTime.UtcNow
            });

            //Act
            var result = await _testclass.GetByIdAsync(1);

            //Assert
            A.CallTo(() => _repository.GetById(1)).MustHaveHappened();
            // checking that a valid ToDoItem is returned
            Assert.IsType<TodoItem>(result);
        }

        [Fact]
        public async Task GetByIdAsyncNotFound_ThrowsException()
        {
            //Arrange
            A.CallTo(() => _repository.GetById(1)).Throws<FileNotFoundException>();
 
            //Act
            //Assert
            // checking that exception is raised when there is no list to return
            await Assert.ThrowsAsync<FileNotFoundException>(() => _testclass.GetByIdAsync(1));
      
        }

        [Fact]
        public async Task AddToDoAsync_CanCall()
        {
            // Arrange
            // original input
            var request = new CreateTodoRequestDTO
            {
                Title = "TestValue1100041166",
                Description = "TestValue1568731792",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            };

            // mapped object

            A.CallTo(() => _repository.SaveChangesAsync(A<TodoItem>._)).Returns(new TodoItem
            {
                Id = 1832587942,
                Title = "TestValue1100041166",
                Description = "TestValue1568731792",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            });

            // Act
            await _testclass.AddToDoAsync(request);

            // Assert
            A.CallTo(() => _validator.Validate(A<Func<CreateTodoRequestDTO, ICollection<string>>>._, A<CreateTodoRequestDTO>._)).MustHaveHappened();
            A.CallTo(() => _repository.Add(A<TodoItem>._)).MustHaveHappened();
            A.CallTo(() => _repository.SaveChangesAsync(A<TodoItem>._)).MustHaveHappened();
            
        }

        [Fact]
        public async Task AddToDoAsync_FailsValidation()
        {
            // Arrange
            // original input
            var request = new CreateTodoRequestDTO
            {
                Title = "",
                Description = "TestValue1568731792",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            };

            // validation failure due to empty title string, have faked the exception, but not sure if this is the right approach
            var errors = "To Do Item must have a title";
            var fakeexception = new ValidationException(errors);

            A.CallTo(() => _validator.Validate(A<Func<CreateTodoRequestDTO, ICollection<string>>>._, A<CreateTodoRequestDTO>._)).Throws(fakeexception);

            // therefore no mapped object

            // Act
            // Assert
            await Assert.ThrowsAsync<ValidationException>(() => _testclass.AddToDoAsync(request));          
            A.CallTo(() => _validator.Validate(A<Func<CreateTodoRequestDTO, ICollection<string>>>._, A<CreateTodoRequestDTO>._)).MustHaveHappened();
            
        }

        [Fact]
        public async Task CannotCallAddToDoAsyncWithNullRequest_ThrowsException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testclass.AddToDoAsync(default(CreateTodoRequestDTO)));
        }

        [Fact]
        public async Task CanCallUpdateToDoItemAsync_ValidatesAndSavesChanges()
        {
            // Arrange
            // getting a To Do Item that we then want to modify
            A.CallTo(() => _repository.GetById(A<int>._)).Returns(new TodoItem
            {
                Id = 1477758342,
                Title = "TestValue869951767",
                Description = "TestValue1354470730",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            });

            // the change we want to make to an existing item
            var id = 1477758342;
            var request = new UpdateTodoRequestDTO
            {
                Title = "TestValue869951767",
                Description = "changed value",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            };

            // saving the change
            A.CallTo(() => _repository.SaveChangesAsync(A<TodoItem>._)).Returns(new TodoItem
            {
                Id = 1477758342,
                Title = "TestValue869951767",
                Description = "changed value",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            });

            // Act
            await _testclass.UpdateToDoItemAsync(id, request);

            // Assert
            // get the existing item
            A.CallTo(() => _repository.GetById(A<int>._)).MustHaveHappened();
            // validate the changes
            A.CallTo(() => _validator.Validate(A<Func<UpdateTodoRequestDTO, ICollection<string>>>._, A<UpdateTodoRequestDTO>._)).MustHaveHappened();
            // save the changes
            A.CallTo(() => _repository.SaveChangesAsync(A<TodoItem>._)).MustHaveHappened();
            
        }

        [Fact]
        public async Task CannotCallUpdateToDoItemAsyncWithNullRequest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testclass.UpdateToDoItemAsync(1000504978, default(UpdateTodoRequestDTO)));
        }

        [Fact]
        public async Task CanCallCompleteToDoItemAsync()
        {
            // Arrange
            var id = 339372194;
            var request = new CompleteTodoRequestDTO { IsComplete = true };

            // original item with IsComplete being false
            A.CallTo(() => _repository.GetById(A<int>._)).Returns(new TodoItem
            {
                Id = 339372194,
                Title = "TestValue336728293",
                Description = "TestValue710502485",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            });

            // after saving changes IsComplete should now be true
            A.CallTo(() => _repository.SaveChangesAsync(A<TodoItem>._)).Returns(new TodoItem
            {
                Id = 339372194,
                Title = "TestValue336728293",
                Description = "TestValue710502485",
                IsComplete = true,
                DueDate = new DateTime(2024, 08, 28)
            });

            // Act
            await _testclass.CompleteToDoItemAsync(id, request);

            // Assert
            A.CallTo(() => _repository.GetById(A<int>._)).MustHaveHappened();
            A.CallTo(() => _repository.SaveChangesAsync(A<TodoItem>._)).MustHaveHappened();

        }

        [Fact]
        public async Task CannotCallCompleteToDoItemAsync_AlreadyComplete()
        {
            // Arrange
            var id = 339372194;
            var request = new CompleteTodoRequestDTO { IsComplete = true };

            // original item with IsComplete being already true
            A.CallTo(() => _repository.GetById(A<int>._)).Returns(new TodoItem
            {
                Id = 339372194,
                Title = "TestValue336728293",
                Description = "TestValue710502485",
                IsComplete = true,
                DueDate = new DateTime(2024, 08, 28)
            });

            // shouldn't be able to save changes, should throw exception, before it gets to save changes, so it isn't calling the repo because it doesn't get that far

            // Act
            // Assert
            await Assert.ThrowsAsync<AlreadyCompleteException>(() => _testclass.CompleteToDoItemAsync(id, request));                              
            A.CallTo(() => _repository.GetById(A<int>._)).MustHaveHappened();
            
        }

        [Fact]
        public async Task CannotCallCompleteToDoItemAsyncWithNullRequest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testclass.CompleteToDoItemAsync(1354558909, default(CompleteTodoRequestDTO)));
        }

        [Fact]
        public async Task CanCallDeleteToDoItemAsync_Deletes()
        {
            // Arrange
            var id = 31254499;

            A.CallTo(() => _repository.GetById(A<int>._)).Returns(new TodoItem
            {
                Id = 31254499,
                Title = "TestValue1473679904",
                Description = "TestValue1548832059",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            });
            A.CallTo(() => _repository.Delete(A<int>._)).Returns(new TodoItem
            {
                Id = 533704669,
                Title = "TestValue1473679904",
                Description = "TestValue1548832059",
                IsComplete = false,
                DueDate = new DateTime(2024, 08, 28)
            });

            // Act
            await _testclass.DeleteToDoItemAsync(id);

            // Assert
            A.CallTo(() => _repository.GetById(A<int>._)).MustHaveHappened();
            A.CallTo(() => _repository.Delete(A<int>._)).MustHaveHappened();

        }

        [Fact]
        public async Task CannotCallDeleteToDoItemAsync_FileNotFound()
        {
            // Arrange
            var id = 31254499;

            A.CallTo(() => _repository.GetById(A<int>._)).Throws<FileNotFoundException>();

            // Act
            // Assert
            await Assert.ThrowsAsync<FileNotFoundException>(() => _testclass.DeleteToDoItemAsync(31254499));
            A.CallTo(() => _repository.GetById(A<int>._)).MustHaveHappened();

        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new TodoListService(_repository, _logger, _mapper, _validator);

            // Assert
            // checking that service can be constructed
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new TodoListService(default(ITodoListRepository), _logger, _mapper, _validator));
        }

        [Fact]
        public void CannotConstructWithNullLogger()
        {
            Assert.Throws<ArgumentNullException>(() => new TodoListService(_repository, default(ILogger<TodoListService>), _mapper, _validator));
        }

        [Fact]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new TodoListService(_repository, _logger, default(IMapper), _validator));
        }

        [Fact]
        public void CannotConstructWithNullValidator()
        {
            Assert.Throws<ArgumentNullException>(() => new TodoListService(_repository, _logger, _mapper, default(IToDoItemValidator)));
        }
      
    }
}
