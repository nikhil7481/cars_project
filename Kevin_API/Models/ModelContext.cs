using Microsoft.EntityFrameworkCore;

namespace Kevin_API.Models
{
    public class ModelContext:DbContext
    {
public DbSet<Model>cars { get; set; }
        public ModelContext(DbContextOptions options) : base(options) 
        {
       
        }   
    }
}
