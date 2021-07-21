using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smile.Data;
using Smile.Models;
using AutoMapper;
using Smile.Dtos.OrderDetailDtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Smile.Controllers
{

    [Route("api/orderdetails")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepo _repository;
        private readonly IMapper _mapper;

        public OrderDetailsController(IOrderDetailRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/orderdetails
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var orderDetailItems = await _repository.GetAllOrderDetails();
            return Ok(_mapper.Map<IEnumerable<OrderDetailReadDto>>(orderDetailItems));
        }

        //GET api/orders/{id}
        [HttpGet("{oid}", Name = "GetOrderDetailById")]
        [Authorize]
        public async Task<IActionResult> GetOrderDetailById(int oid)
        {
            var orderDetailItem = await _repository.GetOrderDetailById(oid);
            if(orderDetailItem != null)
            {
                return Ok(_mapper.Map<OrderDetailReadDto>(orderDetailItem));
            }
            return NotFound();
        }

        //POST api/orderdetails
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailCreateDto orderDetailCreateDto)
        {
            var orderDetailModel = _mapper.Map<OrderDetail>(orderDetailCreateDto);
            _repository.CreateOrderDetail(orderDetailModel);
            await _repository.SaveChangesAsync();

            var orderDetailReadDto = _mapper.Map<OrderDetailReadDto>(orderDetailModel);
            
            return CreatedAtRoute(nameof(GetOrderDetailById), new {OrderId = orderDetailReadDto.OrderId}, orderDetailReadDto);
        }

        //PUT api/orderdetails/{id}
        [HttpPut("{oid}")]
        public async Task<IActionResult> UpdateOrderDetail(int oid, OrderDetailUpdateDto orderDetailUpdateDto)
        {
            var orderDetailModelFromRepo = await _repository.GetOrderDetailById(oid);
            if(orderDetailModelFromRepo == null){
                return NotFound();
            }
            _mapper.Map(orderDetailUpdateDto, orderDetailModelFromRepo);

            _repository.UpdateOrderDetail(orderDetailModelFromRepo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        //PATCH api/orderdetails/{oid}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialOrderUpdate(int oid, JsonPatchDocument<OrderDetailUpdateDto> patchDoc)
        {
            var orderDetailModelFromRepo = await _repository.GetOrderDetailById(oid);
            if(orderDetailModelFromRepo == null){
                return NotFound();
            }
            var orderDetailToPatch = _mapper.Map<OrderDetailUpdateDto>(orderDetailModelFromRepo);
            patchDoc.ApplyTo(orderDetailToPatch, ModelState);
            if(!TryValidateModel(orderDetailToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(orderDetailToPatch, orderDetailModelFromRepo);
            _repository.UpdateOrderDetail(orderDetailModelFromRepo);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/orderdetails/{id}
        [HttpDelete("{oid}")]
        public async Task<IActionResult> DeleteOrderDetail(int oid)
        {
            var orderDetailModelFromRepo = await _repository.GetOrderDetailById(oid);
            if(orderDetailModelFromRepo == null){
                return NotFound();
            }
            _repository.DeleteOrderDetail(orderDetailModelFromRepo);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}