using AutoMapper;
using Smile.Dtos.PraiseDtos;
using Smile.Models;

namespace Smile.Profiles
{
    public class PraisesProfile : Profile
    {
        public PraisesProfile()
        {
            CreateMap<Praise, PraiseReadDto>();
        }
    }
}