namespace Hao.MES.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> Query();
}