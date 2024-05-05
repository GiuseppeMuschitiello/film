using AutoMapper;
using Cinema.BLL.Models;
using Cinema.DAL.Entities;

namespace Cinema.Web.Configuratiojn
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Dvd, DvdModel>().ReverseMap();
        }
    }
}
