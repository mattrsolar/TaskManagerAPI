using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Requests
{
    public class RequestTaskJson
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public PriorityType Priority { get; set; }
        public DateTime DueDate { get; set; }
        public StatusType Status { get; set; }
    }
}
