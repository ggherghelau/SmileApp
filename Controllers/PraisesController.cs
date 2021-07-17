using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smile.Data;
using Smile.Models;
using AutoMapper;
using Smile.Dtos.PraiseDtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Smile.Controllers
{

    [Route("api/cheers")]
    [ApiController]
    public class PraisesController : ControllerBase
    {
        private readonly IPraiseRepo _repository;
        private readonly IMapper _mapper;

        public PraisesController(IPraiseRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/praises
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPraises()
        {
            var praiseItems = await _repository.GetAllPraises();
            return Ok(_mapper.Map<IEnumerable<PraiseReadDto>>(praiseItems));
        }

        //GET api/praises/{id}
        [HttpGet("{id}", Name = "GetPraiseById")]
        public async Task<IActionResult> GetPraiseById(int id)
        {
            var praiseItem = await _repository.GetPraiseById(id);
            if(praiseItem != null)
            {
                return Ok(_mapper.Map<PraiseReadDto>(praiseItem));
            }
            return NotFound();
        }

    }
}