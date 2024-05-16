namespace EmployeeRequestTrackerAPI.Models
{
    public class ErrorModel
    {
        public int errorcode { get; set; }
        public string message { get; set; }

        public ErrorModel(int errorcode, string message)
        {
            this.errorcode = errorcode;
            this.message = message;
        }
    }
}