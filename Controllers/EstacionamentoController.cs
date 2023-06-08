
using Microsoft.AspNetCore.Mvc;
using Models.Domain.Entities;
using Models.Domain.Interfaces;

namespace Controllers.EstacionamentoController
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IEstacionamentoRepository repositiory;

        public EstacionamentoController()
        {
            this.repositiory = new EstacionamentoRepository();
        }

        [HttpGet]
        public IEnumerable<Vaga>Get()
        {
            return repositiory.GetAll();
        }
        [HttpGet("{id}")]
        public Vaga Get(int id)
        {
            return repositiory.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Vaga item)
        {
            repositiory.Save(item);
            return Ok( new {
                statusCode=200,
                message = "Estacionado com sucesso",
                item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repositiory.Delete(id);
            return Ok( new {
                statusCode=200,
                message = "Vaga excluída com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Vaga item)
        {
            repositiory.Update(item);
            return Ok( new {
                statusCode=200,
                message = item.Veiculo + " atualizado com sucesso",
                item
            });
        }
    }
}