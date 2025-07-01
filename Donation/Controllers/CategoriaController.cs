using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Donation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }   

        [HttpGet]
        public async Task <ActionResult <IList<CategoriaModel>>> Get() 
        {
            var categorias = await _categoriaRepository.FindAll();

            if (categorias != null && categorias.Count > 0)
            {
                return Ok(categorias);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id:int}")]
        public async Task <ActionResult <CategoriaModel>> Get(int id)
        {
            var categoria = await _categoriaRepository.FindById(id);

            if(categoria != null)
            {
                return Ok(categoria);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task <ActionResult<CategoriaModel>> Post([FromBody]CategoriaModel categoriaModel)
        {
            if ( ! ModelState.IsValid )
            {
                return BadRequest();
            }
            await _categoriaRepository.Insert(categoriaModel);

            var url2 = Request.GetEncodedUrl().EndsWith("/") ?
                Request.GetEncodedUrl() : 
                Request.GetEncodedUrl() + "/";

            url2 = url2 + categoriaModel.CategoriaId;

            return Created(url2 + categoriaModel.CategoriaId, categoriaModel);
            
        }

        [HttpPut("{id:int}")]
        public async Task <ActionResult> Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            if ( !ModelState.IsValid )
            {
                return BadRequest();
            }

            if ( id != categoriaModel.CategoriaId)
            {
                return BadRequest();
            } else
            {
                _categoriaRepository.Update(categoriaModel);
                return NoContent();
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task <ActionResult> Delete([FromRoute] int id)
        {
            if ( id == 0)
            {
                return BadRequest();
            }
            var categoria = _categoriaRepository.FindById(id);

            if ( categoria == null )
            {
                return NotFound();
            }

            _categoriaRepository.Delete(id);
            return NoContent();

            
        }
    }
}
