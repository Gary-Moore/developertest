using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Services;
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
            _todoListService = todoListService ?? throw new ArgumentNullException(nameof(todoListService));
 
        }
               
        // get a list of all the ToDo items
        // next step is to implement some sorting? By date? Group by Completed or not?
        [HttpGet(Name = "GetTodos")]
        public async Task<ActionResult> GetToDoList()
        {
            // fetch all the items
            var toDoList = await _todoListService.GetListAsync();
          
            // success message if this works
            return Ok(new { message = "Successfully retrieved To Do List!", data = toDoList});
        }

        // GetToDoById
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            // fetch the item
            var itemById = await _todoListService.GetByIdAsync(id);

            // success message if this works
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

            // creating a new item using the ITodoListService Interface
            await _todoListService.AddToDoAsync(request);

            // succcess response if this works
            return Ok(new { message = "New To Do list item successfully created", data = request});
            
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

            // updating the item - finding it by ID and then updating
            await _todoListService.UpdateToDoItemAsync(id, item);

            // success message if this works
            return Ok(new { message = "To Do list item successfully updated", data = item });
            
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

            // mark the item complete and return success message
            await _todoListService.CompleteToDoItemAsync(id, item);
            return Ok(new { message = $"To Do list item with Id: {id} successfully completed." });
           
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

            // delete the item and return success message
            await _todoListService.DeleteToDoItemAsync(id);
            return Ok(new { message = $"To Do list item with Id: {id} successfully deleted" });

        }

    }
}
