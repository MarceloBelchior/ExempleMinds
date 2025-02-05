using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minds.Interface.Domain
{
    public interface IEmployeeBS
    {
        public Minds.Interface.Model.Employee CreateOrUpdateEmployee(Minds.Interface.Model.Employee employee);
        public ICollection<Minds.Interface.Model.Employee> GetEmployees(Minds.Interface.Model.Employee employee);
        public ICollection<Minds.Interface.Model.Employee> GetAll();
    }
}
