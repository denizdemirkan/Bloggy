using Bloggy.Core.UnitOfWorks;
using Bloggy.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggy.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MsSqlDbContext _dbConttext;
        public UnitOfWork(MsSqlDbContext dbContext)
        {
            this._dbConttext= dbContext;
        }
        public void Commit()
        {
            _dbConttext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbConttext.SaveChangesAsync();
        }
    }
}
