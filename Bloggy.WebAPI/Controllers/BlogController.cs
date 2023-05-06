using Bloggy.Core.DTOs;
using Bloggy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.WebAPI.Controllers
{
    [ApiController]
    [Route("blog/[controller]")]
    public class BlogController
    {
        private IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IEnumerable<BlogDto>> GetAll()
        {
            return await _blogService.GetAllAsync();
        }
    }
}
