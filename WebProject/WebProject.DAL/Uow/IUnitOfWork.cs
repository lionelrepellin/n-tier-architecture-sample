using System.Data.Entity;

namespace WebProject.DAL.Uow
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }

}