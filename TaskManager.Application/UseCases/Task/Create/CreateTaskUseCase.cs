using TaskManager.Communication.Enums;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Create
{
    public class CreateTaskUseCase
    {
        public ResponseCreateTaskJson Execute(RequestTaskJson request)
        {
            var validator = new Validations.ValidateTasks();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
                throw new ArgumentException(string.Join("; ", validationResult.Errors));

            return new ResponseCreateTaskJson
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Priority = request.Priority,
                DueDate = request.DueDate,
                Status = request.Status,
            };
        }
    }
}
