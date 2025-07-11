using Donation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Repository.Interface
{
    public interface IProdutoRepository
    {
        public Task <IList<ProdutoModel>> FindAll();
        
        public Task <IList<ProdutoModel>> FindAll(int pagina, int tamanho);

        public Task <IList<ProdutoModel>> FindAll(DateTime? dataReferencia, int tamanho);

        public int Count();

        public Task<IList<ProdutoModel>> FindByNome(string nome);

        public Task <ProdutoModel> FindById(int id);

        public Task <int> Insert(ProdutoModel produtoModel);

        public void Update(ProdutoModel produtoModel);

        public void Delete(ProdutoModel produtoModel);

        public void Delete(int id);
    }
}
