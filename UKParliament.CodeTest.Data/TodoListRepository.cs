using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Data
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoListContext _context;

        public TodoListRepository(TodoListContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // need this to be implementing the interface, not doing it directly
        public List<TodoItem> GetList()
        {
            return _context.TodoItems.ToList();
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
