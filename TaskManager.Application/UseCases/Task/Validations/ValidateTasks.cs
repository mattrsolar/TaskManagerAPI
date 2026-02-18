using System;
using TaskManager.Communication.Responses;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Enums;

namespace TaskManager.Application.UseCases.Task.Validations
{
    public class ValidateTasks
    {
        public ResponseErrorsJson Validate(RequestTaskJson request)
        {
            var errors = new ResponseErrorsJson().Errors;

            if (string.IsNullOrWhiteSpace(request?.Name))
                errors.Add("Name is required");
            else if (request.Name.Length > 100)
                errors.Add("Name maximum characters is 100");

            if (!string.IsNullOrEmpty(request?.Description) && request.Description.Length > 500)
                errors.Add("Description maximum characters is 500");

            if (request != null && request.DueDate <= DateTime.Now)
                errors.Add("Due date cannot be in the past");

            if (request != null && !Enum.IsDefined(typeof(PriorityType), request.Priority))
                errors.Add("Invalid priority type");

            if (request != null && !Enum.IsDefined(typeof(StatusType), request.Status))
                errors.Add("Invalid status type");

            return new ResponseErrorsJson { Errors = errors };
        }
    }
}

