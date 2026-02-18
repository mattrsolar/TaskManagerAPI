using TaskManager.Communication.Enums;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.GetById
{
    public class GetByIdTaskUseCase
    {
        public ResponseGetByIdTaskJson Execute(int id) {

            return new ResponseGetByIdTaskJson {
                Id = Guid.NewGuid(), //just a test
                Name = "Task 1",
                Description = "Description of Task 1",
                Priority = PriorityType.high,
                DueDate = DateTime.Now.AddDays(7),
                Status = StatusType.pending
            };
        }
    }
}
