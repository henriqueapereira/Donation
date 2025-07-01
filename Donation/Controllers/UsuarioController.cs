using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IList<UsuarioModel>>> GetAsync()
        {
            var usuarios = await _usuarioRepository.FindAll();

            if( usuarios != null && usuarios.Count > 0 )
            {
                return Ok(usuarios);
            } else
            {
                return NoContent();
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioModel>> GetAsync(int id)
        {
            var usuario = await _usuarioRepository.FindById(id);

            if (usuario != null)
            {
                return Ok(usuario);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Post([FromBody] UsuarioModel usuarioModel)
        {
                
            if ( ! ModelState.IsValid )
            {
                return BadRequest();
            }

            await _usuarioRepository.Insert(usuarioModel);

            var url = Request.GetEncodedUrl().EndsWith("/") ?
                        Request.GetEncodedUrl() : 
                        Request.GetEncodedUrl() + "/";

            url = url + usuarioModel.UsuarioId;
           

            return Created(url, usuarioModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if ( (!ModelState.IsValid) || (id != usuarioModel.UsuarioId) )
            {
                return BadRequest();
            } else 
            {
                _usuarioRepository.Update(usuarioModel);
                return NoContent();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {

            if ( id == 0 )
            {
                return BadRequest();
            }

            var usuario = _usuarioRepository.FindById(id);

            if (usuario == null )
            {
                return NotFound();

            }
            
            _usuarioRepository.Delete(id);
            return NoContent();
            
        }

        
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UsuarioModel>> Login([FromBody] UsuarioModel usuarioModel)
        {
            var usuario = await _usuarioRepository.FindByEmailAndSenha(
                usuarioModel.EmailUsuario,
                usuarioModel.Senha);

            if ( usuario != null)
            {
                usuario.Senha = string.Empty;
                return Ok(usuario);
            } else
            {
                return NotFound();
            }

        }

    }
}
