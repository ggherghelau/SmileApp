using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smile.Data;
using Smile.Models;
using AutoMapper;
using Smile.Dtos;

namespace Smile.Controllers
{

    [Route("api/jokes")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeRepo _repository;
        private readonly IMapper _mapper;

        public JokesController(IJokeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/jokes
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllJokes()
        {
            var jokeItems = await _repository.GetAllJokes();
            return Ok(_mapper.Map<IEnumerable<JokeReadDto>>(jokeItems));
        }

        //GET api/jokes/{id}
        [HttpGet("{id}", Name = "GetJokeById")]
        public async Task<IActionResult> GetJokeById(int id)
        {
            var jokeItem = await _repository.GetJokeById(id);
            if(jokeItem != null)
            {
                return Ok(_mapper.Map<JokeReadDto>(jokeItem));
            }
            return NotFound();
        }

        //POST api/jokes
        [HttpPost]
        public ActionResult<JokeReadDto> CreateJoke(JokeCreateDto jokeCreateDto)
        {
            var jokeModel = _mapper.Map<Joke>(jokeCreateDto);
            _repository.CreateJoke(jokeModel);
            _repository.SaveChanges();

            var jokeReadDto = _mapper.Map<JokeReadDto>(jokeModel);
            
            return CreatedAtRoute(nameof(GetJokeById), new {Id = jokeReadDto.Id}, jokeReadDto);
        }

        //PUT api/jokes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateJoke(int id, JokeUpdateDto jokeUpdateDto)
        {
            var jokeModelFromRepo = _repository.GetJokeById(id);
            if(jokeModelFromRepo == null){
                return NotFound();
            }
            _mapper.Map(jokeUpdateDto, jokeModelFromRepo);

            //_repository.UpdateJoke(jokeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}