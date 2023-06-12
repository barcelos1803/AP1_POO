using Models.Domain.Entities;
using Models.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Data.Repositories;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository repository;

        public VeiculoController()
        {
            this.repository = new VeiculosRepository();
        }

        [HttpGet]
        public IEnumerable<Veiculo>Get()
        {
            return repository.GetAll();
        }
        [HttpGet("{id}")]
        public Veiculo Get(int id)
        {
            return repository.GetById (id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Veiculo item)
        {
            repository.Save(item);
            return Ok( new {
                statusCode=200,
                message = "Veiculo Cadastrado com sucesso",
                item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok( new {
                statusCode=200,
                message = "Veiculo excluído com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Veiculo item)
        {
            repository.Update(item);
            return Ok( new {
                statusCode=200,
                message = " atualizado com sucesso",
                item
            });
        }
    }
}