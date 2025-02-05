using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minds.Interface.Domain
{
    public interface IDepartamentBS
    {
        public Minds.Interface.Model.Department CreateOrUpdateDepartament(Minds.Interface.Model.Department departament);
        public ICollection<Minds.Interface.Model.Department> GetDepartaments(Minds.Interface.Model.Department departament);
        public ICollection<Minds.Interface.Model.Department> GetAll();
    }
}
