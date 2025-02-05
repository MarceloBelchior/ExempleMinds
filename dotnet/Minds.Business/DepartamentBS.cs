using Minds.Interface.Domain;
using Minds.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minds.Business
{
    public class DepartamentBS : IDepartamentBS
    {
        public IDepartamentRepository _departamentRepository;
        public DepartamentBS(IDepartamentRepository departamentRepository)
        {
            _departamentRepository = departamentRepository;
        }
        public Minds.Interface.Model.Department CreateOrUpdateDepartament(Minds.Interface.Model.Department departament)
        {
            return _departamentRepository.CreateOrUpdateDepartament(departament);
        }
        public ICollection<Minds.Interface.Model.Department> GetDepartaments(Minds.Interface.Model.Department departament)
        {
            return _departamentRepository.GetDepartaments(departament);
        }
        public ICollection<Minds.Interface.Model.Department> GetAll()
        {
            return _departamentRepository.GetAll();
        }

    }
}
