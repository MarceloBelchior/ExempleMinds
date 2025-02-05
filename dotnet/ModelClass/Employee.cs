namespace ModelClass
{
    public class Department
    {
        public int DepartmentId { get; set; }           
        public string Name { get; set; }                 
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

        // Foreign key for Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }       // Navigation property
    }
}
