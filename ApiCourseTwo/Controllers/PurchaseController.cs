using Application.DTOs;
using Application.Service;
using Application.Service.Interfaces;
using Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace ApiCourseTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.Create(purchaseDTO);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
            
        }
        [HttpGet]
        public async Task<ActionResult> FindByAllAsync()
        {
          
                var result = await _purchaseService.FindByAllAsync();
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);            
           
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindByIdAsync(int id)
        {
          
                var result = await _purchaseService.FindByIdAsync(id);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);            
           
        }
    }
}
