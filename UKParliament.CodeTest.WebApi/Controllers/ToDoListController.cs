using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.WebApi.Models;

namespace UKParliament.CodeTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly ILogger<ToDoListController> _logger;
        private readonly ITodoListService _todoListService;
        private readonly ITodoListRepository _todoRepository;
        private readonly TodoListContext _todoContext;

        public ToDoListController(ILogger<ToDoListController> logger, ITodoListService todoListService, ITodoListRepository todoListRepository, TodoListContext todoContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _todoListService = todoListService ?? throw new ArgumentNullException(nameof(todoListService));
            _todoRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));
            _todoContext = todoContext ?? throw new ArgumentNullException(nameof(todoContext));
        }

        [HttpGet(Name = "GetTodos")]
        public async Task<ActionResult<IEnumerable<TodoListModel>>> Get()
        {
            var toDoListEntities = _todoRepository.GetList();
            return Ok(toDoListEntities);
        }
    }
}
