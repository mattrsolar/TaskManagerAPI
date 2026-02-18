using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.Create;
using TaskManager.Application.UseCases.Task.Delete;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Application.UseCases.Task.GetById;
using TaskManager.Application.UseCases.Task.Update;
using TaskManager.Application.UseCases.Task.Validations;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult CreateTask([FromBody] RequestTaskJson request)
        {
            var validator = new ValidateTasks().Validate(request);

            if (validator.Errors.Any())
                return BadRequest(validator);

            var useCase = new CreateTaskUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]

        public IActionResult UpdateTask([FromRoute] int id, [FromBody] RequestTaskJson request)
        {
            var validator = new ValidateTasks().Validate(request);

            if (validator.Errors.Any()) 
                return BadRequest(validator);  

            var useCase = new UpdateTaskUseCase();
            useCase.Execute(id, request);

            return NoContent();

        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseGetAllTasksJson),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllTasks()
        {
            var useCase = new GetAllTasksUseCase();
            var response = useCase.Execute();

            if (!response.Tasks.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseGetByIdTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult GetTaskById([FromRoute] int id)
        {
            var useCase = new GetByIdTaskUseCase();
            var response = useCase.Execute(id);
            
            if(response is null)
                return NotFound();
            
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteTask([FromRoute] int id)
        {         
            
            var useCase = new DeleteTaskUseCase();
            useCase.Execute(id);

            return NoContent();
        }



    }
}
