using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //IoC Container -- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            

          

            var result = _productService.GetAll();
            
             return Ok(result);
            
           

        }

      

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
           
            
                return Ok(result);
            

           
        }

      

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
             _productService.Add(product);
            
                return Ok("kayıt başarılı");
            
            
        }


    }
}
