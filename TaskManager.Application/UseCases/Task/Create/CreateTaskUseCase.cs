using TaskManager.Communication.Enums;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Create
{
    public class CreateTaskUseCase
    {
        public ResponseCreateTaskJson Execute(RequestTaskJson request)
        {
            if (request.Name == null) 
                throw new ArgumentNullException();

            if (request.Name.Length > 100)
                throw new ArgumentException("Name maximum characters is 100");

            if (request.Description.Length > 500)
                throw new ArgumentException("Description maximum characters is 500");

            if (request.DueDate <= DateTime.Now)
                throw new ArgumentException("Due date cannot be in the past");
            
            if (!Enum.IsDefined(typeof(PriorityType), request.Priority))
                throw new ArgumentException("Invalid priority type");

            if (!Enum.IsDefined(typeof(StatusType), request.Status))
                throw new ArgumentException("Invalid status type");

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
