using AutoMapper;
using Resort.ng.Model;
using Resort.ng.Model.DTO;

namespace Resort.ng
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Resorts, ResortsDto>().ReverseMap();
            //CreateMap<ResortsDto, Resorts>();

            CreateMap<Resorts, ResortsCreateDto>().ReverseMap();
            CreateMap<Resorts, ResortsUpdateDto>().ReverseMap();
        }
    }
}
