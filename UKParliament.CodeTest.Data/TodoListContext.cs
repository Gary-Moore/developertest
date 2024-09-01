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
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                { Id = 1, Title = "Project planning", Description = "Write project plan", IsComplete = false, DueDate = new DateTime(2024, 08, 12) },
                new TodoItem
                { Id = 2, Title = "Refine goals", Description = "Work with stakeholders to refine goals", IsComplete = true, DueDate = new DateTime(2024, 08, 18) },
                new TodoItem
                { Id = 3, Title = "Sprint planning", Description = "Work with stakeholders to plan the next sprint", IsComplete = false, DueDate = new DateTime(2024, 09, 03) },
                new TodoItem
                { Id = 4, Title = "Ticket refinement", Description = "Refine and point tickets with other devs", IsComplete = false, DueDate = new DateTime(2024, 08, 21) },
                new TodoItem
                { Id = 5, Title = "Work on ticket MNIS-219", Description = "Need to work out where the data is coming from, change how the query is working to include the needed data, discuss testing etc", IsComplete = false, DueDate = new DateTime(2024, 08, 28) },
                new TodoItem
                { Id = 6, Title = "Book annual leave", Description = "Confirm can take requested days off, update chronos", IsComplete = false, DueDate = new DateTime(2024, 09, 26) },
                new TodoItem
                { Id = 7, Title = "Personal Development", Description = "Work through E-Learning", IsComplete = false, DueDate = new DateTime(2024, 09, 22) },
                new TodoItem
                { Id = 8, Title = "Order new washing machine", Description = "Research and order new machine, arrange for old one to be disposed of", IsComplete = false, DueDate = new DateTime(2024, 09, 01) }
            );


        }

        public DbSet<TodoItem> TodoItems { get; set; }

      
    }
}
