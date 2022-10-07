using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCourseTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.Create(productDTO);
            if(result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet] 
          public async Task<ActionResult> FindByAll()
        {
            var result = await _productService.FindByAll(); 
            if(result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _productService.FindById(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.Update(productDTO);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
