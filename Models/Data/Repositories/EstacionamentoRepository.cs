using Models.Data.Context;
using Models.Domain.Entities;
using Models.Domain.Interfaces;

public class EstacionamentoRepository : IEstacionamentoRepository
{
    private readonly DataContext context;

    public EstacionamentoRepository(DataContext context)
    {
        this.context = context;
    }

    public EstacionamentoRepository()
    {
    }

    public List<Vaga> ObterVagasOcupadas()
    {
        return context.Vagas.Where(v => v.Ocupada).ToList();
    }

    public List<Vaga> ObterVagasLivres()
    {
        return context.Vagas.Where(v => !v.Ocupada).ToList();
    }

    public void Estacionar(Veiculo veiculo)
    {
        var vaga = context.Vagas.FirstOrDefault(v => !v.Ocupada);

        if (vaga != null)
        {
            vaga.Ocupada = true;
            vaga.Veiculo = veiculo;
            context.SaveChanges();
        }
        else
        {
            throw new Exception("Não há vagas livres.");
        }
    }

    public void Desocupar(int id)
    {
        var vaga = context.Vagas.FirstOrDefault(v => v.Id == id);

        if (vaga != null)
        {
            vaga.Ocupada = false;
            vaga.Veiculo = null;
            context.SaveChanges();
        }
    }

    public Vaga GetById(int entityid)
    {
        return context.Vagas.FirstOrDefault(v => v.Id == entityid);
    }

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
        context.SaveChanges();
    }

    public static void InicializarEstacionamento(IEstacionamentoRepository estacionamentoRepository, int Numero)
    {
        for (int i = 1; i <= Numero; i++)
        {
            var vaga = new Vaga(i);
            estacionamentoRepository.AdicionarVaga(vaga);
        }
    }

    public void AdicionarVaga(Vaga vaga)
    {
        context.Vagas.Add(vaga);
        context.SaveChanges();
    }
}
