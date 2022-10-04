using Code.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Code.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);    
    }
}
