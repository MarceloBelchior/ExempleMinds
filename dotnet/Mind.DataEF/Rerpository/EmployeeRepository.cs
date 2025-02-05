using Minds.DataEF.Mapping;

namespace Minds.DataEF.Rerpository
{
    public class EmployeeRepository : BaseRepository<DataEF.Models.Employee>, Minds.Interface.Repository.IEmployeeRepository
    {
      
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public Minds.Interface.Model.Employee CreateOrUpdateEmployee(Minds.Interface.Model.Employee employee)
        {
            Models.Employee data = employee.Map();
            if (base.Select(c => c.EmployeeId == data.EmployeeId).Count() == 0)
            {
               
                return base.Insert(data).Map();
            }
            return base.Update(data).Map();

        }
        public ICollection<Minds.Interface.Model.Employee> GetEmployees(Minds.Interface.Model.Employee employee)
        {
            Models.Employee data = employee.Map();
            return base.Select(c => c.EmployeeId == data.EmployeeId).Select(c => c.Map()).ToList();
        }
        public ICollection<Minds.Interface.Model.Employee> GetAll()
        {

            return base.Select(c => c.EmployeeId != null).Select(c=> c.Map()).ToList();
        }

    }
}
