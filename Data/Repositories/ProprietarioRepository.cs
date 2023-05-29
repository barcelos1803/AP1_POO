
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly DataContext context;
        // //construtuor
        public ProprietarioRepository(DataContext context)
        {
            this.context = context;
        }
        public void Delete(int entityid)
        {
        var p = GetById(entityid);
        context.Proprietarios.Remove(p);
        context.SaveChanges();
        }

        public IList<Proprietario> GetAll()
        {
        return context.Proprietarios.ToList();
        }

        public Proprietario GetById(int entityid)
        {
        return context.Proprietarios.FirstOrDefault(v => v.Id == entityid);
        }

        public void Save(Proprietario entity)
        {
        context.Add(entity);
        context.SaveChanges();
        }

        public void Update(Proprietario entity)
        {
            context.Proprietarios.Update(entity);
        }
    }
}