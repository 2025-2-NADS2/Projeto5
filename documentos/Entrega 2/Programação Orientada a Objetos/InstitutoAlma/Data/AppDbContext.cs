using InstitutoAlma.Models; // ajuste caso sua pasta de modelos seja diferente
using Microsoft.EntityFrameworkCore;

namespace InstitutoAlma.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
    }
}
