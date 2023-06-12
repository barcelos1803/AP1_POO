using Models.Domain.Entities;
using Models.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Data.Repositories;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProprietarioController : ControllerBase
    {
       private readonly IProprietarioRepository repository;

        public ProprietarioController()
        {
            this.repository = new ProprietarioRepository();
        }

        [HttpGet]
        public IEnumerable<Proprietario>Get()
        {
            return repository.GetAll();
        }
        [HttpGet("{id}")]
        public Proprietario Get(int id)
        {
            return repository.GetById (id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Proprietario item)
        {
            repository.Save(item);
            return Ok( new {
                statusCode=200,
                message = "Proprietario Cadastrado com sucesso",
                item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok( new {
                statusCode=200,
                message = "Proprietário excluído com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Proprietario item)
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