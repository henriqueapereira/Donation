using Donation.Data;
using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Donation.Repository
{
    public class TrocaRepository : ITrocaRepository
    {
        private readonly DataContext _dataContext;

        public TrocaRepository(DataContext context)
        {
            _dataContext = context;
        }

        public Guid Insert(Models.TrocaModel trocaModel)
        {
            _dataContext.Trocas.Add(trocaModel);
            _dataContext.SaveChanges();

            return trocaModel.TrocaId;
        }


        public TrocaModel FindById(Guid id)
        {
            var troca = _dataContext.Trocas
                    .Include(t => t.ProdutoModel1)
                    .Include(t => t.ProdutoModel2)
                .FirstOrDefault(t => t.TrocaId == id);

            return troca;
        }
    }
}