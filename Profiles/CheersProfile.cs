using AutoMapper;
using Smile.Dtos.CheerDtos;
using Smile.Models;

namespace Smile.Profiles
{
    public class CheersProfile : Profile
    {
        public CheersProfile()
        {
            CreateMap<Cheer, CheerReadDto>();
        }
    }
}