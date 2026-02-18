using TaskManager.Application.UseCases.Task.Validations;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Delete
{
    public class DeleteTaskUseCase
    {
        public void Execute(int id)
        {
            var errors = new ResponseErrorsJson().Errors;

            //Logic to delete the task from the database would go here

            if (id == 0)
            {
                errors.Add("Task ID not found");
                throw new Exception("Task not found");
            }
        }
    }
}
