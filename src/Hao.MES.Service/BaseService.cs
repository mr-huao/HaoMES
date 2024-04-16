using AutoMapper;
using Hao.MES.IService;
using Hao.MES.Repository;

namespace Hao.MES.Service;

public class BaseService<TEntity,TVo>:IBaseService<TEntity,TVo> where TEntity : class,new()
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<TEntity> _baseRepository;
    public BaseService(IMapper mapper,IBaseRepository<TEntity> baseRepository)
    {
        _mapper = mapper;
        _baseRepository = baseRepository;
    }
    
    public async Task<List<TVo>> Query()
    {
        var entities = await _baseRepository.Query();
        var llout = _mapper.Map<List<TVo>>(entities);
        return llout;
    }
}