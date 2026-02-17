using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Requests
{
    public class RequestRegisterTaskJson
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime dueDate { get; set; }
        public StatusType Status { get; set; }
    }
}
