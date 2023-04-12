using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Context;
using ProjetoWebApi.DTO;
using ProjetoWebApi.Models;

namespace ProjetoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly LocacaoContext _marca;

        public MarcaController(LocacaoContext marca)
        {
            _marca = marca;
        }

            // Método Inserir:

        [HttpPost]
        public ActionResult Inserir ([FromBody] MarcaDTO marcaDTO)
        {
            if (marcaDTO.Nome == null || marcaDTO.Codigo!= 0)
            {
                return BadRequest("Dados não inseridos. Preencha o Nome e mantenha o codigo zerado (0)");
            }
            else
            {
            MarcaModel marca = new MarcaModel();
            marca.Nome = marcaDTO.Nome;
            marca.Id = 0;
            _marca.Marcas.Add(marca);
            _marca.SaveChanges();
            return Ok();
            }          
            
        }

            // Método Editar por ID:
            [HttpPut("{codigo}")]
            public ActionResult EditarId([FromRoute] int codigo, [FromBody] MarcaDTO marcaDTO)
            {
                var filtro = _marca.Marcas.Where(x=>x.Id == codigo).FirstOrDefault();
                if (filtro != null)
                {
                    if (marcaDTO.Codigo != 0)
                    {
                        return BadRequest("Dados não editados.");
                    }
                    else 
                    {
                        MarcaModel marcaModel = new MarcaModel();
                        marcaModel.Id = marcaDTO.Codigo;
                        marcaModel.Nome = marcaDTO.Nome;
                        _marca.Marcas.Attach(marcaModel);
                        _marca.SaveChanges();
                        return Ok();
                    }
                }
                else{
                    return BadRequest("Código não identificado.");
                }
            }

            // Método Remover por ID:

            [HttpDelete("{codigo}")]
            public ActionResult RemoverId([FromRoute] int codigo)
            {
                var filtro = _marca.Marcas.Where(x => x.Id == codigo).FirstOrDefault();
                if (filtro!= null)
                {
                    _marca.Marcas.Remove(filtro);
                    _marca.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Código não removido.");
                }
            }

            // Método Obter Tudo:

            [HttpGet]
            public ActionResult<List<MarcaDTO>> ObterTodos()
            {
                List<MarcaDTO> ListaMarcaDTO = new List<MarcaDTO>();
                foreach (var item in _marca.Marcas)
                {
                    var marcaDTO = new MarcaDTO();
                    marcaDTO.Codigo = item.Id;
                    marcaDTO.Nome = item.Nome;
                    ListaMarcaDTO.Add(marcaDTO);
            }
                return Ok(ListaMarcaDTO);
        }
        
            // Método Obter por ID:

            [HttpGet("codigo/{codigo}")]
            public ActionResult<List<MarcaDTO>> ObterId([FromRoute] int codigo)
            {
                var filtro = _marca.Marcas.Where(x => x.Id == codigo).FirstOrDefault();
                List<MarcaDTO> ListaMarcaDTO = new List<MarcaDTO>();
                if (filtro!= null)
                {
                    var marcaDTO = new MarcaDTO();
                    marcaDTO.Codigo = filtro.Id;
                    marcaDTO.Nome = filtro.Nome;
                    ListaMarcaDTO.Add(marcaDTO);
                    return Ok(ListaMarcaDTO);
            }
            else
            {
                return BadRequest("Código não encontrado");
            }
        }
    }
}