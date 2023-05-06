using Bloggy.Core.Entities;
using Bloggy.Core.Repositories;
using Bloggy.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bloggy.Repository.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly MsSqlDbContext _dbContext;
        private readonly DbSet<Blog> _dbSet;

        public BlogRepository(MsSqlDbContext dbContext)
        {
            this._dbContext = dbContext;
            _dbSet = dbContext.Set<Blog>();
        }

        public async Task AddAsync(Blog blog)
        {
            await _dbSet.AddAsync(blog);
        }

        public Task<bool> AnyAsync(Expression<Func<Blog, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Blog> GetAll()
        {
            var blogs = _dbContext.Blogs.Include(b => b.Author).Include(b => b.Category).AsQueryable();
            return blogs;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            var blog = await _dbSet.FindAsync(id);
            return blog;
        }

        public Task<Blog> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(Blog blog)
        {
            _dbSet.Remove(blog);
        }

        public void Update(Blog blog)
        {
            _dbSet.Update(blog);
        }
    }
}
