using Donation.Models;

namespace Donation.Repository.Interface
{
    public interface ITrocaRepository
    {
        public Guid Insert(Models.TrocaModel trocaModel);

        public TrocaModel FindById(Guid id);
    }
}