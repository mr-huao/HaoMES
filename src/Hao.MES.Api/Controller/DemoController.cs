using Hao.MES.IService;
using Hao.MES.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hao.MES.Api.Controller;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private readonly IBaseService<User, UserVo> _userService;
    public DemoController(IBaseService<User,UserVo> userService)
    {
        _userService = userService;
    }
    
    [HttpGet(Name = "GetDemo")]
    public async Task<List<UserVo>> Get()
    {
        var userList = await _userService.Query();
        return userList;
    }
}