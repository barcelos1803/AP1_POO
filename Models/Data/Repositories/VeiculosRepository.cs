using Models.Data.Context;
using Models.Domain.Entities;
using Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class VeiculosRepository :IVeiculoRepository
{
    private readonly DataContext context;
    // //construtuor
    public VeiculosRepository(DataContext context)
    {
        this.context = context;
    }
    public void Delete(int entityid)
    {
        var v = GetById(entityid);
        context.Veiculos.Remove(v);
        context.SaveChanges();
    }
    // Retorna todos os veículos
    public IList<Veiculo> GetAll()
    {
        return context.Veiculos.Include(x=>x.Proprietario).ToList();
    }
    // Retorna um veículo por ID
    public Veiculo GetById(int entityid)
    {
        return context.Veiculos.Include(x=>x.Proprietario).SingleOrDefault(x=>x.Id == entityid);
    }

    // Retorna um veículo pela placa
    public Veiculo ObterPorPlaca(string placa)
    {
        return context.Veiculos.SingleOrDefault(x=>x.Placa == placa);
    }

    public void Save(Veiculo entity)
    {
        entity.Proprietario = context.Proprietarios.SingleOrDefault(x=>x.Id == entity.Proprietario.Id);
        context.Add(entity);
        context.SaveChanges();
    }

    public void Update(Veiculo entity)
    {
        entity.Proprietario = context.Proprietarios.SingleOrDefault(x=>x.Id == entity.Proprietario.Id);
        context.Veiculos.Update(entity);
        context.SaveChanges();
    }
}

