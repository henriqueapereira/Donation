using Donation.Data;
using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Donation.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _dataContext;
        public ProdutoRepository(DataContext ctx)
        {
            _dataContext = ctx;
        }

        public  async Task<IList<ProdutoModel>> FindAll()
        {
            var produtos = await _dataContext.Produtos.AsNoTracking().ToListAsync();

            return produtos == null ? [] : produtos;
        }
        
        //PAGINAÇÃO
        public async Task<IList<ProdutoModel>> FindAll(int pagina = 0, int tamanho = 5)
        {
            var produtos = _dataContext.Produtos
                                .OrderBy(p => p.ProdutoId)
                                .Skip(tamanho * pagina)
                                .Take(tamanho)
                                .AsNoTracking()
                                .ToList();

            return produtos == null ? [] : produtos;
        }

        public async Task<IList<ProdutoModel>> FindAll(DateTime? dataReferencia, int tamanho = 5)
        {
            var produtos = _dataContext.Produtos
                                .Where ( p => p.DataCadastro > dataReferencia)
                                .OrderBy(p => p.DataCadastro)
                                .Take(tamanho)
                                .AsNoTracking()
                                .ToList();

            return produtos == null ? [] : produtos;
        }

        public int Count()
        {
            return _dataContext.Produtos.Count();
        }


        public async Task<IList<ProdutoModel>> FindByNome(string nome)
        {
            var produtos = await _dataContext
                                .Produtos // SELECT * FROM Produtos
                                .AsNoTracking()
                                .Include(p => p.Categoria) // INNER JOIN
                                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                    .ToListAsync();

            return produtos == null ? [] : produtos;
        }

        public  async Task <ProdutoModel> FindById(int id)
        {
            var produto = await _dataContext
                                .Produtos
                                .AsNoTracking()
                                .FirstOrDefaultAsync(p => p.ProdutoId == id);

            return produto;
        }

        // Inserir
        public async Task <int> Insert(ProdutoModel produtoModel)
        {
            _dataContext.Produtos.Add(produtoModel);
            _dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }

        public  async void Update(ProdutoModel produtoModel)
        {
            _dataContext.Produtos.Update(produtoModel);
            _dataContext.SaveChanges();
        }

        public async void Delete(ProdutoModel produtoModel)
        {
            _dataContext.Produtos.Remove(produtoModel);
            _dataContext.SaveChanges();
        }


        public  async void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id,
            };

            Delete(produtoModel);
        }

    }
}
