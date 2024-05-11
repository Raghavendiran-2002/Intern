using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerModelLibrary
{
    public class SpecializedDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department_Head { get; set; }

        public SpecializedDepartment()
        {
            Id = 0;
            Name = string.Empty;
            Department_Head = string.Empty;
        }

        public SpecializedDepartment(int id,string name,string department_head)
        {
            Id = id;
            Name = name;
            Department_Head = department_head;
        }
    }
}
