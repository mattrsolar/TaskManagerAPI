using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Update
{
    public class UpdateTaskUseCase
    {
        public ResponseCreateTaskJson Execute(int id, RequestTaskJson request)
        {

            return new ResponseCreateTaskJson
            {
                //Id = id,
                Name = request.Name,
                Description = request.Description,
                Priority = request.Priority,
                DueDate = request.DueDate,
                Status = request.Status
            };


        }
    }
}
