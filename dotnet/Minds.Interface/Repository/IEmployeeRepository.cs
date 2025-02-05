using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minds.Interface.Repository
{
    public interface IEmployeeRepository
    {
        public Minds.Interface.Model.Employee CreateOrUpdateEmployee(Minds.Interface.Model.Employee employee);
        public ICollection<Minds.Interface.Model.Employee> GetEmployees(Minds.Interface.Model.Employee employee);
        public ICollection<Minds.Interface.Model.Employee> GetAll();
    }
}
