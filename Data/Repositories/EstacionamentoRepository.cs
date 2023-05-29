using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

public class EstacionamentoRepository:IEstacionamentoRepository
{
    private readonly DataContext context;
    // //construtuor
    public EstacionamentoRepository(DataContext context)
    {
        this.context = context;
    }

    // Retorna as vagas ocupadas
    public List<Vaga> ObterVagasOcupadas()
    {
        return context.Vagas.Where(v => v.Ocupada == true).ToList();
    }

    // Retorna as vagas livres
    public List<Vaga> ObterVagasLivres()
    {
        return context.Vagas.Where(v => v.Ocupada == false).ToList();

    }

    // Estaciona um veículo em uma vaga livre
    public void Estacionar(Veiculo veiculo)
    {
        var vaga = context.Vagas.FirstOrDefault(v => v.Ocupada == false);

        if (vaga != null)
        {
            vaga.Ocupar(veiculo);
            context.SaveChanges();
        }
        else
        {
            throw new Exception("Não há vagas livres.");
        }
    }

    // Desocupa uma vaga
    public void Desocupar(int id)
    {
        var vaga = context.Vagas.FirstOrDefault(v => v.Id == id);

        if (vaga != null)
        {
            vaga.Desocupar();
        }
    }
    // Retorna uma vaga pelo ID
    public Vaga GetById(int entityid)
    {
        return context.Vagas.FirstOrDefault(v => v.Id == entityid);
    }

    // Retorna todas as vagas
    public IList<Vaga> GetAll()
    {
        return context.Vagas.ToList();
    }

    public void Save(Vaga entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public void Delete(int entityid)
    {
        var vg = GetById(entityid);
        context.Vagas.Remove(vg);
        context.SaveChanges();
    }

    public void Update(Vaga entity)
    {
        context.Vagas.Update(entity);
    }
} 
