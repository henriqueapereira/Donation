using Donation.Data;
using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Donation.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _dataContext;
        public CategoriaRepository(DataContext ctx)
        {
            _dataContext = ctx;
        }

        public async Task <IList<CategoriaModel>> FindAll()
        {
            return await _dataContext.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task <CategoriaModel> FindById(int id)
        {
            var categoria = await _dataContext.Categorias.AsNoTracking().FirstOrDefaultAsync(u => u.CategoriaId == id);

            return categoria;
        }

        public async Task <int> Insert(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Add(categoriaModel);
            _dataContext.SaveChanges();

            return categoriaModel.CategoriaId;
        }

        public async void Update(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Update(categoriaModel);
            _dataContext.SaveChanges();

        }

        public async void Delete(int id)
        {
            var categoriaModel = new CategoriaModel()
            {
                CategoriaId = id
            };

            _dataContext.Categorias.Remove(categoriaModel);
            _dataContext.SaveChanges();
        }
    }
}
