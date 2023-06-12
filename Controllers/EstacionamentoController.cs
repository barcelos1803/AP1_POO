
using Microsoft.AspNetCore.Mvc;
using Models.Data.Repositories;
using Models.Domain.Entities;
using Models.Domain.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IEstacionamentoRepository repository;
        private readonly IProprietarioRepository proprietarioRepository;
        private readonly IVeiculoRepository veiculoRepository;


        public EstacionamentoController()
        {
            this.repository = new EstacionamentoRepository();
            this.proprietarioRepository = new ProprietarioRepository();
            this.veiculoRepository = new  VeiculosRepository();
        }

        [HttpGet]
        public IEnumerable<Vaga> Get()
        {
            IEnumerable<Vaga> vagas = repository.GetAll();
            
            foreach (Vaga vaga in vagas)
            {
                vaga.Veiculo = veiculoRepository.GetById(vaga.Id);
                if (vaga.Veiculo != null)
                {
                    vaga.Veiculo.Proprietario = proprietarioRepository.GetById(vaga.Veiculo.Proprietario.Id);
                }
            }

            return vagas;
        }

        [HttpGet("{id}")]
        public Vaga Get(int id)
        {
            Vaga vaga = repository.GetById(id);

            if (vaga != null)
            {
                vaga.Veiculo = veiculoRepository.GetById(vaga.Id);
                if (vaga.Veiculo != null)
                {
                    vaga.Veiculo.Proprietario = proprietarioRepository.GetById(vaga.Veiculo.ProprietarioId);
                }
            }

            return vaga;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Vaga item)
        {
            var veiculo = veiculoRepository.GetById(item.Veiculo.Id);
            item.Veiculo = veiculo;
            repository.Save(item);
            return Ok( new {
                statusCode=200,
                message = "Vaga Cadastrada com sucesso",
                item
            });
        }

        [HttpPut]
        public IActionResult Put([FromBody]Vaga item)
        {
            repository.Update(item);
            return Ok( new {
                statusCode=200,
                message = " atualizado com sucesso",
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
    }
}