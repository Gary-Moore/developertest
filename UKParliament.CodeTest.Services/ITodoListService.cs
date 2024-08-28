using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.DTO;

namespace UKParliament.CodeTest.Services
{
    public interface ITodoListService
    {
        //List<TodoItem> GetList();

        // gets a list of all to do items
        Task<IEnumerable<TodoItem>> GetListAsync();

        // gets a specific todo item by id
        Task<TodoItem> GetByIdAsync(int id);

        // AddToDoItem
        Task AddToDoAsync(CreateTodoRequestDTO request);

        // EditToDoItem
        Task UpdateToDoItemAsync(int id, UpdateTodoRequestDTO request);

        // CompleteToDoItem
        Task CompleteToDoItemAsync(int id);

        // DeleteToDoItem
        Task DeleteToDoItemAsync(int id);
    }
}