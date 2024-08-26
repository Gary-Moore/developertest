using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Contracts;
using UKParliament.CodeTest.WebApi.Models;

namespace UKParliament.CodeTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;


        public ToDoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService ?? throw new ArgumentNullException(nameof(todoListService));
 
        }

        // need this to be implementing the interface not doing it directly

        [HttpGet(Name = "GetTodos")]
        public async Task<ActionResult> GetToDoList()
        {
            try
            {
                // fetch all the items
                var toDoList = await _todoListService.GetListAsync();
                if (toDoList == null || !toDoList.Any())
                {
                    // message if list is empty
                    return Ok(new { message = "No Todo Items found" });
                }
                // success message if this works
                return Ok(new { message = "Successfully retrieved To Do List!", data = toDoList });
            }
            catch (Exception ex)
            {
                // error message if the getting of the list fails
                return StatusCode(500, new { message = "An error occurred while retrieving the To Do list" });
            }
        }

        //TODO:

        // GetToDoById

        // AddToDoItem
        [HttpPost]
        public async Task<IActionResult> AddTodoAsync(CreateTodoRequest request)
        {
            // checking the model is valid, if not returnning Bad Request with the model state errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // creating a new item using the ITodoListService Interface
                await _todoListService.AddToDoAsync(request);
                // succcess response if this works
                return Ok(new { message = "New To Do list item successfully created"});
            }
            catch (Exception ex)
            {
                // error handling if it doesn't
                return StatusCode(500, new { message = "An error occured while create the To Do List item" });
            }
        }

        // EditToDoItem

        // CompleteToDoItem

        // DeleteToDoItem
    }
}
