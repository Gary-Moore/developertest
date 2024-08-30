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

        // UpdateToDoItem
        public async Task<TodoItem> Update(TodoItem item)
        {
            await _context.SaveChangesAsync();
            return item;
        }

        // CompleteToDoItem
        public async Task<TodoItem> Complete(TodoItem item)
        {
            await _context.SaveChangesAsync();
            return item;
        }

        // DeleteToDoItem
        public async Task<TodoItem> Delete(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
                return todo;
            }
            else
            {
                throw new Exception($"No item found with the id: {id}");
            }
        }

        // not totally sure that I need a seperate save method, need to check this
        public async Task<TodoItem> SaveChangesAsync(TodoItem item)
        {
            await _context.SaveChangesAsync();
            return item;
        }

  




        


  

     
    }
}
