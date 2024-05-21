namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class RaiseRequestDTO
    {
        public int UserId { get; set; }
        public string RequestMessage { get; set; } = string.Empty;

    }
}
