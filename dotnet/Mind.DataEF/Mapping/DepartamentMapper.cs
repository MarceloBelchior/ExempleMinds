using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Minds.DataEF.Mapping
{
    internal static class DepartamentMapper
    {
        private static IMapper ConfigureAutoMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Minds.Interface.Model.Department, Models.Department>()
               
                .ReverseMap();
                //cfg.CreateMap<Domain.Models.fixedPrices, Documents.fixedPrices>().ReverseMap();
                // cfg.CreateMap<Domain.Models.dateRange, Documents.dateRange>().ReverseMap();

            });

            return config.CreateMapper();
        }
        internal static Minds.Interface.Model.Department Map(this Models.Department entity)
        {
            if (entity == null)
            {
                return null;
            }
            var autoMapper = ConfigureAutoMapper();

            var _result = autoMapper.Map<Models.Department, Minds.Interface.Model.Department>(entity);
            return _result;
        }
        internal static Models.Department Map(this Minds.Interface.Model.Department entity)
        {
            if (entity == null)
            {
                return null;
            }
            var autoMapper = ConfigureAutoMapper();

            var _result = autoMapper.Map< Minds.Interface.Model.Department, Models.Department>(entity);
            return _result;
        }
    }
}
