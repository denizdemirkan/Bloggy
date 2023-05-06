using Azure;
using Bloggy.Core.DTOs;
using Bloggy.Core.Entities;
using Bloggy.Core.Repositories;
using Bloggy.Core.Services;
using Bloggy.Core.UnitOfWorks;
using Bloggy.Service.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggy.Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BlogDto> AddAsync(BlogDto blogDto)
        {
            var blog = ObjectMapper.Mapper.Map<Blog>(blogDto);

            await _blogRepository.AddAsync(blog);

            await _unitOfWork.CommitAsync();

            return blogDto;
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            var blogDtos = ObjectMapper.Mapper.Map<List<BlogDto>>(await _blogRepository.GetAll().ToListAsync());

            return blogDtos;
        }

        public async Task<BlogDto> GetByIdAsync(int id)
        {
            var blogDto = ObjectMapper.Mapper.Map<BlogDto>(await _blogRepository.GetByIdAsync(id));

            return blogDto;
        }

        public async Task RemoveById(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);

            // fill with if null 

            _blogRepository.Remove(blog);

            await _unitOfWork.CommitAsync();
        }

        public async Task Update(BlogDto blogDto)
        {
            var blog = ObjectMapper.Mapper.Map<Blog>(blogDto);

            _blogRepository.Update(blog);

            await _unitOfWork.CommitAsync();
        }
    }
}
