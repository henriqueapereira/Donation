using Donation.Data;
using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Donation.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;
        public UsuarioRepository(DataContext ctx) 
        {
            _dataContext = ctx;
        }
        public async Task<IList<UsuarioModel>> FindAll()
        {
            var usuarios = await _dataContext.Usuarios.AsNoTracking().ToListAsync();
            return usuarios;
        }

        public async Task<UsuarioModel> FindById(int id)
        {
            var usuario = await _dataContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.UsuarioId == id);
            return usuario;
        }

        public async void Delete(int id)
        {
            var usuario = new UsuarioModel();
            usuario.UsuarioId = id;

            _dataContext.Usuarios.Remove(usuario);
            _dataContext.SaveChanges();
        }

        public async Task<int> Insert(UsuarioModel usuarioModel)
        {
            _dataContext.Usuarios.Add(usuarioModel);
            _dataContext.SaveChanges();

            return usuarioModel.UsuarioId;
        }

        public async void Update(UsuarioModel usuarioModel)
        {
            _dataContext.Usuarios.Update(usuarioModel);
            _dataContext.SaveChanges();
        }

        public async Task<UsuarioModel> FindByEmailAndSenha(string email, string senha)
        {
            var usuario = await _dataContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(
                    u => u.EmailUsuario == email &&
                         u.Senha == senha
                );

            return usuario;
        }
        
    }
}
