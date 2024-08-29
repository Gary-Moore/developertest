using System.ComponentModel;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.WebApi.Models
{
    public class TodoListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
      
        public bool IsCompleted { get; set; }
       
        public DateTime DueDate { get; set; }

  
        // I don't think the list should be here, but was in the code originally, so i guess should be? This makes the API response look a bit odd with a list within a list on the schema
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
