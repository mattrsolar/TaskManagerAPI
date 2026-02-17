using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.Create;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateTaskJson),StatusCodes.Status201Created)]
        public IActionResult CreateTask([FromBody] RequestCreateTaskJson request)
        {
            var useCase = new CreateTaskUseCase();

            var response = useCase.Execute(request);

            return Created();
        }

    }
}
