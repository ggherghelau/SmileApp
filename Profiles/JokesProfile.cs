using AutoMapper;
using Smile.Dtos.JokeDtos;
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
            CreateMap<Joke, JokeUpdateDto>();
        }
    }
}