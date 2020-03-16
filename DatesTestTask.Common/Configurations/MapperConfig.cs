using AutoMapper;
using DatesTestTask.Core;
using DatesTestTask.Services.DTO;

namespace DatesTestTask.Common.Configurations
{
    public static class MapperConfig
    {
        public static IMapperConfigurationExpression Configure(this IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<DatesRangeDTO, DatesRange>();
            mapper.CreateMap<DatesRange, DatesRangeDTO>();
            return mapper;
        }
    }
}
