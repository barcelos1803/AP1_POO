

namespace Models.Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Entity GetById(int entityid);
        IList<Entity> GetAll();
        void Save (Entity entity);
        void Delete (int entityid);
        void Update (Entity entity);
        
    }
}