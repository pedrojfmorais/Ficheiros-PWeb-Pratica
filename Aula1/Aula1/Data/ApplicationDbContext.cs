using Aula1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aula1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CategoriaCarta> CategoriaCartas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}