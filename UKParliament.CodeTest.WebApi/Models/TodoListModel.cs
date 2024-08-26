using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.WebApi.Models
{
    public class TodoListModel
    {
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
