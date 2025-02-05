using System;
using System.Collections.Generic;

namespace Minds.DataEF.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }            // Primary key
        public string Name { get; set; }                 // e.g., "Human Resources", "IT", etc.

        public ICollection<Employee> Employees { get; set; }
    }

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
