using Microsoft.EntityFrameworkCore;
using produtoCRUD.Domain.Entities;

namespace produtoCRUD.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext 
        
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
             
            public DbSet<Produto> Produtos {  get; set; }

        }
}

