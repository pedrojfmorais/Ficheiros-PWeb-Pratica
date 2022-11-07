using Aula1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aula1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<TipoDeAula> TipoDeAula { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}