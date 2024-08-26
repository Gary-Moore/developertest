using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _repository;

        public TodoListService(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public List<TodoItem> GetList()
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        //TODO:

        // AddToDoItem

        // EditToDoItem

        // CompleteToDoItem

        // DeleteToDoItem
    }
}
