using AutoMapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace UKParliament.CodeTest.Data
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoListContext _context;
        private readonly IMapper _mapper;


        public TodoListRepository(TodoListContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // this will return all of the ToListItems in the db
        public async Task<IEnumerable<TodoItem>> GetList()
        {
            // need to do some mapping here from the db object to a ui object
            var listofToDo = await _context.TodoItems.ToListAsync();
            var mappedList = listofToDo.Select(_mapper.Map<TodoItem>);
            return mappedList;
        }


        // this will return one specific To Do list item based on the ID received as an argument
        public async Task<TodoItem> GetById(int id)
        {
            return _context.TodoItems.Find(id);
        }
             
        // AddToDoItem
        public void Insert(TodoItem item)
        {
            _context.TodoItems.Add(item);
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Complete(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

  




        // EditToDoItem


        // CompleteToDoItem

        // DeleteToDoItem
    }
}
