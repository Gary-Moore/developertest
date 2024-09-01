using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.WebApi.Models;
using UKParliament.CodeTest.Data.DTO;

namespace UKParliament.CodeTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;


        public ToDoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
 
        }

       
        // get a list of all the ToDo items
        // next step is to implement some sorting? By date? Group by Completed or not?
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
                    return NotFound(new { message = "No To do Items found" });
                }
                // success message if this works
                return Ok(new { message = "Successfully retrieved To Do List!", data = toDoList });
            }
            catch (Exception ex)
            {
                // error message if the getting of the list fails
                return StatusCode(500, new { message = $"An error occurred while retrieving the To Do list: {ex.Message}" });
            }
        }

        // GetToDoById
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var itemById = await _todoListService.GetByIdAsync(id);

            if (itemById is null)
            {
                return NotFound(new { message = $"No To Do item with Id: {id}" });
            }

            return Ok(new { message = $"Successfully retrieved item with Id: {id}", data = itemById });
        }

        // AddToDoItem
        [Route("/addItem")]
        [HttpPost]
        public async Task<IActionResult> AddTodoAsync(CreateTodoRequestDTO request)
        {
            // checking the model is valid, if not returning Bad Request with the model state errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // creating a new item using the ITodoListService Interface
                await _todoListService.AddToDoAsync(request);
                // succcess response if this works
                return Ok(new { message = "New To Do list item successfully created", data = request});
            }
            catch (Exception ex)
            {
                // error handling if it doesn't
                return StatusCode(500, new { message = $"An error occured while create the To Do List item: {ex.Message}" });
            }
        }

        // UpdateToDoItem
        //use HTTPput over HTTPatch as this can cause unexpected behaviour
        [Route("/update/{id:int}")]
        [HttpPut]
        public async Task<ActionResult<int>> UpdateToDoItemAsync(int id, [FromBody]UpdateTodoRequestDTO item)
        {
            // checking the model is valid, if not returning Bad Request with the model state errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _todoListService.UpdateToDoItemAsync(id, item);
                return Ok(new { message = "To Do list item successfully updated", data = item });
            }

            catch (Exception ex)
            {
                // error handling if it doesn't
                if (ex is FileNotFoundException)
                {
                    return NotFound(new { message = ex.Message });
                }
                // generic error for if something else goes wrong
                return StatusCode(500, new { message = $"An error occured while edit the To Do List item: {ex.Message}" });
            }


        }

        // CompleteToDoItem
        // HTTPPUT because we are only ever changing one field, so have created a new DTO, it is a complete update of that, therefore PUT and not PATCH (but this may be wrong!)
        [Route("/complete/{id:int}")]
        [HttpPut]
        public async Task<ActionResult<int>> CompleteToDoItemAsync(int id, [FromBody] CompleteTodoRequestDTO item)
        {
            // checking the model is valid, if not returnning Bad Request with the model state errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // mark the item complete and return success message
                await _todoListService.CompleteToDoItemAsync(id, item);
                return Ok(new { message = $"To Do list item with Id: {id} successfully completed." });
            }

             catch (Exception ex)
            {
                // error handling if it doesn't
                if (ex is FileNotFoundException)
                {
                    return NotFound(new { message = ex.Message });
                }
                // generic error for if something else goes wrong
                return StatusCode(500, new { message = $"An error occured while trying to complete the To Do List item: {ex.Message}" });
            }
        }

        // DeleteToDoItem
        [Route("/delete/{id:int}")]
        [HttpDelete]

        public async Task<ActionResult<int>> DeleteToDoItemAsync(int id)
        {
            // checking the model is valid, if not returnning Bad Request with the model state errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // delete the item and return success message
                await _todoListService.DeleteToDoItemAsync(id);
                return Ok(new { message = $"To Do list item with Id: {id} successfully deleted" });
            }      

             catch (Exception ex)
            {
                // error handling if it doesn't
                if (ex is FileNotFoundException)
                {
                    return NotFound(new { message = ex.Message });
                }
                // generic error for if something else goes wrong
                return StatusCode(500, new { message = $"An error occured while trying to delete the To Do List item: {ex.Message}" });
            }

        }


        }
}
