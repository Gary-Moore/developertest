using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.DTO;

namespace UKParliament.CodeTest.Services
{
    public interface ITodoListService
    {
        // gets a list of all to do items
        Task<IEnumerable<TodoItem>> GetListAsync();

        // gets a specific todo item by id
        Task<TodoItem> GetByIdAsync(int id);

        // AddToDoItem
        Task AddToDoAsync(CreateTodoRequestDTO request);

        // UpdateToDoItem
        Task UpdateToDoItemAsync(int id, UpdateTodoRequestDTO request);

        // CompleteToDoItem
        Task CompleteToDoItemAsync(int id, CompleteTodoRequestDTO request);

        // DeleteToDoItem
        Task DeleteToDoItemAsync(int id);
    }
}