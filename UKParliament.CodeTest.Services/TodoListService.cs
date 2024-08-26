using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Services.Contracts;

namespace UKParliament.CodeTest.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _repository;
        private readonly TodoListContext _context;
        private readonly ILogger<TodoListService> _logger;
        private readonly IMapper _mapper;

        public TodoListService(ITodoListRepository repository, TodoListContext context, ILogger<TodoListService> logger, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        //public List<TodoItem> GetList()
        //{
        //    throw new NotImplementedException();
        //}

        //public TodoItem GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public TodoItem Add(TodoItem item)
        //{
        //     return _repository.Add(item);
        //}

        public async Task<IEnumerable<TodoItem>> GetListAsync()
        {
            // use EF core method to fetch all the ToDo items from the db
            var todo = await _context.TodoItems.ToListAsync();
            if (todo == null)
            {
                // if none found throw a meaningful error
                throw new Exception("No To Do Items found");
            }
            return todo;
        }

        public Task<TodoItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddToDoAsync(CreateTodoRequest request)
        {
            try
            {
                // use automapper to covert the CreateTodoRequest object into a ToDoItem entity
                var todo = _mapper.Map<TodoItem>(request);
                // add the ToDoItem entity to the TodoItems Dbset in our context and save the changes asynchronously
                _context.TodoItems.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // catch any exceptions, log the error and throw new excpetion with a descriptive error message 
                _logger.LogError(ex, "An error occurred while creating the new To Do List item");
                throw new Exception("An error occurred while creating the new To Do List item");
            }
        }

        public Task UpdateToDoItemAsync(int id, UpdateTodoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task CompleteToDoItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
