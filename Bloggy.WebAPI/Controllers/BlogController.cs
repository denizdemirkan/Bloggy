using Bloggy.Core.DTOs;
using Bloggy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BlogController
    {
        private IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("{id}")]
        public async Task<BlogDto> Get(int id)
        {
            return await _blogService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<BlogDto>> GetAll()
        {
            return await _blogService.GetAllAsync();
        }

        [HttpGet]
        public async Task<BlogDto> GetMostReadPost()
        {
            return await _blogService.GetMostReadAsync();
        }

        [HttpGet]
        public async Task<BlogDto> GetMostLikedPost()
        {
            return await _blogService.GetMostLikedAsync();
        }

        [HttpGet]
        public async Task<BlogDto> GetLastPost()
        {
            return await _blogService.GetLastPostAsync();
        }

        [HttpPost]
        public async Task<BlogDto> Add(BlogDto blogDto)
        {
            await _blogService.AddAsync(blogDto);

            return blogDto;
        }

        [HttpPut]
        public async Task<BlogDto> Update(BlogDto blogDto)
        {
            await _blogService.Update(blogDto);

            return blogDto;
        }

        [HttpDelete]
        public async Task Remove(BlogDto blogDto)
        {
            await _blogService.RemoveById(blogDto.Id);
        }
    }
}
