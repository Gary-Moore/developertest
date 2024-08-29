using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Data
{
    public interface ITodoListRepository
    {

        
        Task<IEnumerable<TodoItem>> GetList();
        Task<TodoItem> GetById(int id);

        //TODO:

        // AddToDoItem
        void Insert(TodoItem item);

        // EditToDoItem
        Task<TodoItem> Update(TodoItem item);
        // CompleteToDoItem
        Task<TodoItem> Complete(TodoItem item);
        // DeleteToDoItem
        Task<TodoItem> Delete(int id);

        Task<TodoItem> SaveChangesAsync(TodoItem item);
    }
}