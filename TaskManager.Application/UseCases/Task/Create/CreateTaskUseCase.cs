using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Create
{
    public class CreateTaskUseCase
    {
        public ResponseCreateTaskJson Execute(RequestCreateTaskJson request)
        {
            return new ResponseCreateTaskJson
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
        }
    }
}
