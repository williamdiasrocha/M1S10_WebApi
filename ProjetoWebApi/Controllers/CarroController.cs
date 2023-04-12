using System.Security.Principal;
using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Context;
using ProjetoWebApi;
using ProjetoWebApi.DTO;
using ProjetoWebApi.Models;


namespace ProjetoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly LocacaoContext _context;
        public CarroController(LocacaoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Inserir([FromBody] CarroDTO carroDTO)
        {
            if (carroDTO == null)
            {
                return BadRequest ("Insira os dados completos");
            }
            else
            {
                if (carroDTO.Codigo != 0)
                {
                    return BadRequest("Código deve ser igual a zero '0'.");
                }
                else
                {
                var BuscarMarca = _context.Marcas.Where(Marca => Marca.Id == carroDTO.CodigoMarca).FirstOrDefault();
                if (BuscarMarca != null)
                    {
                        CarroModel carroModel = new CarroModel()
                        {
                            Id = carroDTO.Codigo,
                            Nome = carroDTO.DescricaoCarro,
                            DataLocacao = carroDTO.DataLocacao,
                            IdMarca = BuscarMarca.Id,
                            Marca = BuscarMarca
                        };
                        
                        _context.Carros.Add(carroModel);
                        _context.SaveChanges();
                        return Ok("Dados salvos com sucesso.");
                    }
                    else 
                    {
                        return BadRequest("Código não encontrado.");
                    }

                }
            }
            
        }
        
        [HttpGet]
    
        public ActionResult<List<CarroDTO>> ObterTodos()
        {
            List<CarroDTO> ListacarroDTOs = new List<CarroDTO>();
            foreach (var carro in _context.Carros)
            {
                var carroDTO = new CarroDTO();
                carroDTO.Codigo = carro.Id;
                carroDTO.DescricaoCarro = carro.Nome;
                carroDTO.DataLocacao = carro.DataLocacao;
                ListacarroDTOs.Add(carroDTO);
            }
            return Ok(ListacarroDTOs);
        }
            
        [HttpGet("codigo/{codigo}")]
        public ActionResult<List<CarroDTO>> ObterCodigo([FromRoute] int codigo)
        {
            foreach(var item in _context.Carros)
            {
                if (item.Id == codigo)
                {
                    List<CarroDTO> listaCarroDTO = new List<CarroDTO>();
                    foreach (var carro in _context.Carros)
                    {
                        var carroDTO = new CarroDTO();
                        carroDTO.Codigo = carro.Id;
                        carroDTO.DescricaoCarro = carro.Nome;
                        carroDTO.DataLocacao = carro.DataLocacao;
                        listaCarroDTO.Add(carroDTO);

                    }
                    return Ok(listaCarroDTO);
                }
                else
                {
                    return BadRequest("Código não encontrado.");
                }
            }
            return Ok();
        }
        
    }

}
