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
    public class BlogController(ApplicationDbContext _db, IMapper _Bmapper) : ControllerBase
    {
        #region GetAllBlogs
        [HttpGet]
        [Route("getblogs")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BlogDTO>))]
        public IActionResult GetBlogs()
        {
            var blogs = _db.blogs.Include(m => m.BlogType).ToList();
            return Ok(_Bmapper.Map<List<BlogDTO>>(blogs));
        }

        #endregion

        #region GetOneBlog
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BlogDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBlog(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var blog = _db.blogs.Include(m => m.BlogType).FirstOrDefault(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(_Bmapper.Map<BlogDTO>(blog));

        }

        #endregion

        #region CreateBlog
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBlog(BlogDTO blogdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var blog = _Bmapper.Map<Blog>(blogdto);
            blog.AuthorName = " Amira";
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return Ok();
        }
        #endregion

        #region DeleteBlog
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBlog(int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }
            var blog = _db.blogs.FirstOrDefault(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return Ok();
        }
        #endregion

        #region updateBlog
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBlog(BlogDTO newblogdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var blog = _db.blogs.FirstOrDefault(m => m.Id == newblogdto.Id);
            _Bmapper.Map<BlogDTO, Blog>(newblogdto, blog);

            _db.SaveChanges();
            return Ok();
        }
        #endregion
    }
}
