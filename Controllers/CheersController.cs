using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smile.Data;
using Smile.Models;
using AutoMapper;
using Smile.Dtos.CheerDtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Smile.Controllers
{

    [Route("api/cheers")]
    [ApiController]
    public class CheersController : ControllerBase
    {
        private readonly ICheerRepo _repository;
        private readonly IMapper _mapper;

        public CheersController(ICheerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/cheers
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCheers()
        {
            var cheerItems = await _repository.GetAllCheers();
            return Ok(_mapper.Map<IEnumerable<CheerReadDto>>(cheerItems));
        }

        //GET api/cheers/{id}
        [HttpGet("{id}", Name = "GetCheerById")]
        public async Task<IActionResult> GetCheerById(int id)
        {
            var cheerItem = await _repository.GetCheerById(id);
            if(cheerItem != null)
            {
                return Ok(_mapper.Map<CheerReadDto>(cheerItem));
            }
            return NotFound();
        }

    }
}