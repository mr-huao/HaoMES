using Newtonsoft.Json;

namespace Hao.MES.Repository;

public class BaseRepository<TEntity> :IBaseRepository<TEntity> where TEntity : class,new()
{
    public async Task<List<TEntity>> Query()
    {
        await Task.CompletedTask;
        var data = "[{\"Id\":\"123123\",\"Name\":\"胡啊哦\"}]";
        return JsonConvert.DeserializeObject<List<TEntity>>(data) ?? new List<TEntity>();
    }
}