using AutoMapper;
using Hao.MES.Model;
using Hao.MES.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hao.MES.Api.Controller;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private readonly IMapper _mapper;

    public DemoController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet(Name = "GetDemo")]
    public async Task<List<UserVo>> Get()
    {
        var userService = new BaseService<User, UserVo>(_mapper);
        var userList = await userService.Query();
        return userList;
    }
}