using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;

        public string RequestStatus;
        public int RequestRaisedBy { get; set; }
        public  Employee  RequestRaisedByEmployee { get; set; }
        public int? RequestClosedBy { get; set; }
        public Employee? RequestClosedByEmployee { get; set; }
    }
}
