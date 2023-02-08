using Asynchronous_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace Asynchronous_APIs.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
    
        }

        public DbSet<ListingRequest> ListingRequests => Set<ListingRequest>();
    }
}
