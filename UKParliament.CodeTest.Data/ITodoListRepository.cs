using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Data
{
    public interface ITodoListRepository
    {
        List<TodoItem> GetList();
        TodoItem GetById(int id);

        //TODO:

        // AddToDoItem
        TodoItem Add(TodoItem item);

        // EditToDoItem

        // CompleteToDoItem

        // DeleteToDoItem
    }
}