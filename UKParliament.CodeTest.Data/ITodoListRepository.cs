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
        void Update(TodoItem item);
        // CompleteToDoItem
        void Complete(TodoItem item);
        // DeleteToDoItem
        void Delete(int id);

        void Save();
    }
}