using Minds.Interface.Domain;
using Minds.Interface.Repository;

namespace Minds.Business
{
    public class EmployeeBS :  IEmployeeBS
    {

        private IEmployeeRepository _employeeRepository;
        private IDepartamentRepository _departamentRepository;
        public EmployeeBS(Minds.Interface.Repository.IEmployeeRepository employeeRepository, IDepartamentRepository departamentRepository)
        {
            _employeeRepository = employeeRepository;
            _departamentRepository = departamentRepository;
        }
        public Minds.Interface.Model.Employee CreateOrUpdateEmployee(Minds.Interface.Model.Employee employee)
        {
            return _employeeRepository.CreateOrUpdateEmployee(employee);
        }
        public ICollection<Minds.Interface.Model.Employee> GetEmployees(Minds.Interface.Model.Employee employee)
        {
            return _employeeRepository.GetEmployees(employee);
        }
        public ICollection<Minds.Interface.Model.Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
      

    }
}
