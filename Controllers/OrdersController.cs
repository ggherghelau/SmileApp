using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smile.Data;
using Smile.Models;
using AutoMapper;
using Smile.Dtos.OrderDtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Smile.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/orders
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllOrders()
        {
            var orderItems = await _repository.GetAllOrders();
            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orderItems));
        }

        //GET api/orders/{id}
        [HttpGet("{id}", Name = "GetOrderById")]
        [Authorize]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var orderItem = await _repository.GetOrderById(id);
            if(orderItem != null)
            {
                return Ok(_mapper.Map<OrderReadDto>(orderItem));
            }
            return NotFound();
        }

        //POST api/orders
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var orderModel = _mapper.Map<Order>(orderCreateDto);
            _repository.CreateOrder(orderModel);
            await _repository.SaveChangesAsync();

            var orderReadDto = _mapper.Map<OrderReadDto>(orderModel);
            
            return CreatedAtRoute(nameof(GetOrderById), new {Id = orderReadDto.Id}, orderReadDto);
        }

        //PUT api/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderUpdateDto orderUpdateDto)
        {
            var orderModelFromRepo = await _repository.GetOrderById(id);
            if(orderModelFromRepo == null){
                return NotFound();
            }
            _mapper.Map(orderUpdateDto, orderModelFromRepo);

            _repository.UpdateOrder(orderModelFromRepo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        //PATCH api/orders/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialOrderUpdate(int id, JsonPatchDocument<OrderUpdateDto> patchDoc)
        {
            var orderModelFromRepo = await _repository.GetOrderById(id);
            if(orderModelFromRepo == null){
                return NotFound();
            }
            var orderToPatch = _mapper.Map<OrderUpdateDto>(orderModelFromRepo);
            patchDoc.ApplyTo(orderToPatch, ModelState);
            if(!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(orderToPatch, orderModelFromRepo);
            _repository.UpdateOrder(orderModelFromRepo);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orderModelFromRepo = await _repository.GetOrderById(id);
            if(orderModelFromRepo == null){
                return NotFound();
            }
            _repository.DeleteOrder(orderModelFromRepo);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}