using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses
{
    public class ResponseGetByIdTaskJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public PriorityType Priority { get; set; }
        public DateTime DueDate { get; set; }
        public StatusType Status { get; set; }

    }
}
