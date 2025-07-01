using Donation.Models;

namespace Donation.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public Task<IList<UsuarioModel>> FindAll();

        public Task<UsuarioModel> FindById(int id);

        public Task<UsuarioModel> FindByEmailAndSenha(string email, string senha);

        public Task<int> Insert(UsuarioModel usuarioModel);

        public void Update(UsuarioModel usuarioModel);

        public void Delete(int id);
    }
}
