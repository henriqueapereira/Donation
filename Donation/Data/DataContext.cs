using Donation.Models;
using Microsoft.EntityFrameworkCore;

namespace Donation.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
