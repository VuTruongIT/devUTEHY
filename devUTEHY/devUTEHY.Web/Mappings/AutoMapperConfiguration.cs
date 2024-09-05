using AutoMapper;
using devUTEHY.Model.Models;
using devUTEHY.Web.Models;

namespace devUTEHY.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<LoaiCongNghe, LoaiCongNgheViewModel>();
        }
    }
}