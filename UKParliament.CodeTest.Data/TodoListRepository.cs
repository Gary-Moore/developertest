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
            _context = context;
        }

        public List<TodoItem> GetList()
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
