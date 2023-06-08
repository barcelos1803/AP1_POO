
using Microsoft.AspNetCore.Mvc;
using Models.Data.Context;
using Models.Domain.Entities;
using Models.Domain.Interfaces;

namespace Controllers.EstacionamentoController
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IEstacionamentoRepository repository;

        public EstacionamentoController()
        {
            this.repository = new EstacionamentoRepository();
        }

        [HttpGet]
        public IEnumerable<Vaga>Get()
        {
            return repository.GetAll();
        }
        [HttpGet("{id}")]
        public Vaga Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Vaga item)
        {
            repository.Save(item);
            return Ok( new {
                statusCode=200,
                message = "Estacionado com sucesso",
                item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok( new {
                statusCode=200,
                message = "Vaga excluída com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Vaga item)
        {
            repository.Update(item);
            return Ok( new {
                statusCode=200,
                message = item.Veiculo + " atualizado com sucesso",
                item
            });
        }
    }
}