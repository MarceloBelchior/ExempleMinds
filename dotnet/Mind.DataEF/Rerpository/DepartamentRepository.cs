
using Minds.DataEF.Mapping;
using Minds.Interface.Model;


namespace Minds.DataEF.Rerpository
{
    public class DepartamentRepository : BaseRepository<Models.Department>, Interface.Repository.IDepartamentRepository
    {
      
        public DepartamentRepository(ApplicationDbContext applicationDb) : base(applicationDb) { }
       
        public Minds.Interface.Model.Department CreateOrUpdateDepartament(Minds.Interface.Model.Department department)
        {
            Models.Department data = department.Map();
            if (base.Select(c => c.DepartmentId == department.DepartmentId).Count() == 0 )
            {
                return base.Insert(data).Map();
            }
            return base.Update(data).Map();
          
        }
        public ICollection<Minds.Interface.Model.Department> GetDepartaments(Minds.Interface.Model.Department department)
        {
            Models.Department data = department.Map();
            return base.Select(c => c.DepartmentId == data.DepartmentId).Select(c => c.Map()).ToList();

        }
        public ICollection<Minds.Interface.Model.Department> GetAll()
        {
            return base.Select(c => c.Name != null).ToList().Select(c => c.Map()).ToList();
        }

    }
}
