using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minds.Interface.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }              // Primary key

        public string FirstName { get; set; }            // First Name
        public string LastName { get; set; }             // Last Name
        public DateTime HireDate { get; set; }           // Hire Date
        public string Phone { get; set; }                // Phone
        public string Address { get; set; }              // Address

        public int DepartmentId { get; set; }
        public Department Department { get; set; }       // Navigation property
    }
}
