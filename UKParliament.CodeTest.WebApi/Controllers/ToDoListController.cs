using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.WebApi.Models;

namespace UKParliament.CodeTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly ILogger<ToDoListController> _logger;

        public ToDoListController(ILogger<ToDoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTodos")]
        public IEnumerable<TodoListModel> Get()
        {
            throw new NotImplementedException();
        }
    }
}
