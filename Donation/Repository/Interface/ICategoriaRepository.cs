using Donation.Models;

namespace Donation.Repository.Interface
{
    public interface ICategoriaRepository
    {
        public Task <IList<CategoriaModel>> FindAll();

        public Task <CategoriaModel> FindById(int id);

        public Task <int> Insert(CategoriaModel categoriaModel);

        public void Update(CategoriaModel categoriaModel);

        public void Delete(int id);
    }
}
