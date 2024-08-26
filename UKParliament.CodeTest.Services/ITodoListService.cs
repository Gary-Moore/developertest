using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Services
{
    public interface ITodoListService
    {
        List<TodoItem> GetList();
        TodoItem GetById(int id);

        //TODO:

        // AddToDoItem

        // EditToDoItem

        // CompleteToDoItem

        // DeleteToDoItem
    }
}