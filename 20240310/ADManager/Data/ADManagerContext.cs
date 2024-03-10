using ADManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADManager.Data
{
    public class ADManagerContext : DbContext
    {
        public ADManagerContext(DbContextOptions<ADManagerContext> options): base(options)
        {
            
        }

        public DbSet<UserInformation> UserInformation { get; set; }
    }
}
