using AutoMapper;
using Smile.Dtos;
using Smile.Models;

namespace Smile.Profiles
{
    public class JokesProfile : Profile
    {
        public JokesProfile()
        {
            CreateMap<Joke, JokeReadDto>();
            CreateMap<JokeCreateDto, Joke>();
            CreateMap<JokeUpdateDto, Joke>();
        }
    }
}