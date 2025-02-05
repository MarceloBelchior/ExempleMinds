using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minds.Interface.Repository
{
    public interface IDepartamentRepository
    {
        public Minds.Interface.Model.Department CreateOrUpdateDepartament(Minds.Interface.Model.Department departament);
        public ICollection<Minds.Interface.Model.Department> GetDepartaments(Minds.Interface.Model.Department departament);
        public ICollection<Minds.Interface.Model.Department> GetAll();
    }
}
