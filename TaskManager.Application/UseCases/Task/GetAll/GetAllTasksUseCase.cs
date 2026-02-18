using TaskManager.Communication.Enums;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.GetAll
{
    public class GetAllTasksUseCase
    {
        public ResponseGetAllTasksJson Execute()
        {
            return new ResponseGetAllTasksJson
            {
                Tasks = new List<ResponseGetTasksJson> 
                { 
                    new ResponseGetTasksJson
                    {
                        Id = Guid.NewGuid(),
                        Name = "Task 1",
                        Description = "Description for Task 1",
                        Priority = PriorityType.high,
                        DueDate = DateTime.Now.AddDays(7),
                        Status = StatusType.pending
                    },
                    new ResponseGetTasksJson
                    {
                        Id = Guid.NewGuid(),
                        Name = "Task 2",
                        Description = "Description for Task 2",
                        Priority = PriorityType.medium,
                        DueDate = DateTime.Now.AddDays(14),
                        Status = StatusType.inProgress
                    }

                }
            };
        }
    }
}
