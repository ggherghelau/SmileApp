using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smile.Data;
using Smile.Models;
using AutoMapper;

namespace Smile.Controllers
{

    [Route("api/jokes")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeRepo _repository;
        private IMapper _mapper;

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
            return Ok(_mapper.Map<IEnumerable<Joke>>(jokeItems));
        }

        //GET api/jokes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJokeById(int id)
        {
            var jokeItem = await _repository.GetJokeById(id);
            return Ok(_mapper.Map<Joke>(jokeItem));
        }
    }
}