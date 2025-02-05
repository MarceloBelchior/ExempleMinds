using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minds.Interface.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }            // Primary key
        public string Name { get; set; }                 // e.g., "Human Resources", "IT", etc.

        public ICollection<Employee> Employees { get; set; }
    }

}
