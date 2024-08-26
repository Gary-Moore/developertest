using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Data
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Use this method to seed the DB with Todo items, if desired, like so:
            // look at how I am doing datetime here, not sure this is right
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem { Id = 1, Title = "Project planning", Description = "Write project plan", IsCompleted = false, DueDate = DateTime.Today});
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
