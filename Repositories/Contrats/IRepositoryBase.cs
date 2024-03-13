using System.Linq.Expressions;

namespace Repositories.Contrats;

public interface IRepositoryBase<T> //Bir repository nin hangi methodlara sahip olmak zorunda olduğunu belirledik
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}