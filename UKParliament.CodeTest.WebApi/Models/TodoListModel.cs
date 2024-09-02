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

        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
