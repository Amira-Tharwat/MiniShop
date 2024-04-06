using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniShop.Data;
using MiniShop.Models;
using MiniShop.Models.DTO;

namespace MiniShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ApplicationDbContext _db, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        [Route("getproducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDTO>))]
        public IActionResult GetProducts()
        {
            var products = _db.products.Include(m => m.company).ToList();
            return Ok(_mapper.Map<List<ProductDTO>>(products));
        }


        [HttpGet("{id}")]
        //   [Route("getproduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = _db.products.Include(m => m.company).FirstOrDefault(m => m.Id == id);
            if (product == null)
                return NotFound();
            return Ok(_mapper.Map<ProductDTO>(product));

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateProduct(ProductDTO productdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newproduct = _mapper.Map<Product>(productdto);
            newproduct.Quantity = 0;
            _db.products.Add(newproduct);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProduct(int id)
        {

            if (id <= 0)

                return BadRequest();

            var product = _db.products.FirstOrDefault(m => m.Id == id);
            if (product == null)

                return NotFound();

            _db.products.Remove(product);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult updateProduct(ProductDTO newproductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = _db.products.FirstOrDefault(m => m.Id == newproductDTO.Id);
            _mapper.Map<ProductDTO, Product>(newproductDTO, product);

            _db.SaveChanges();
            return Ok();
        }
    }
}
