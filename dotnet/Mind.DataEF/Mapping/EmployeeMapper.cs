using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Minds.DataEF.Mapping
{
    internal static class EmployeeMapper
    {
        private static IMapper ConfigureAutoMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Minds.Interface.Model.Employee, Models.Employee>()
               
                .ReverseMap();
                //cfg.CreateMap<Domain.Models.fixedPrices, Documents.fixedPrices>().ReverseMap();
                // cfg.CreateMap<Domain.Models.dateRange, Documents.dateRange>().ReverseMap();

            });

            return config.CreateMapper();
        }
        internal static Minds.Interface.Model.Employee Map(this Models.Employee entity)
        {
            if (entity == null)
            {
                return null;
            }
            var autoMapper = ConfigureAutoMapper();

            var _result = autoMapper.Map<Models.Employee, Minds.Interface.Model.Employee>(entity);
            return _result;
        }
        internal static Models.Employee Map(this Minds.Interface.Model.Employee entity)
        {
            if (entity == null)
            {
                return null;
            }
            var autoMapper = ConfigureAutoMapper();

            var _result = autoMapper.Map< Minds.Interface.Model.Employee, Models.Employee>(entity);
            return _result;
        }
    }
}
