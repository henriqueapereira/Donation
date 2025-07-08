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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoModel>().HasData(
                new ProdutoModel(1, "Produto 1", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(2, "Produto 2", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(3, "Produto 3", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(4, "Produto 4", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(5, "Produto 5", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(6, "Produto 6", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(7, "Produto 7", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(8, "Produto 8", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(9, "Produto 9", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(10, "Produto 10", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(11, "Produto 11", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(12, "Produto 12", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(13, "Produto 13", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(14, "Produto 14", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(15, "Produto 15", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(16, "Produto 16", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(17, "Produto 17", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(18, "Produto 18", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(19, "Produto 19", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(20, "Produto 20", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(21, "Produto 21", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(22, "Produto 22", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(23, "Produto 23", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(24, "Produto 24", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(25, "Produto 25", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(26, "Produto 26", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(27, "Produto 27", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(28, "Produto 28", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(29, "Produto 29", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(30, "Produto 30", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1),
                new ProdutoModel(31, "Produto 31", true, "Descrição", "Sugestão de troca", 1, new DateTime(2025, 7, 1), new DateTime(2027, 3, 1), 1, 1)

            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
