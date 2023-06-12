
using Models.Data.Context;
using Models.Domain.Entities;
using Models.Domain.Interfaces;

namespace Models.Data.Repositories
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly DataContext context;
        // //construtuor
        public ProprietarioRepository()
        {
            this.context = new DataContext();
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