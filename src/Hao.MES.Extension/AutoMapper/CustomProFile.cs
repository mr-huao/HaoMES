using AutoMapper;
using Hao.MES.Model;

namespace Hao.MES.Extension.AutoMapper;

public class CustomProFile:Profile
{
    /// <summary>
    /// 配置构造函数，创建映射关系
    /// </summary>
    public CustomProFile()
    {
        CreateMap<User, UserVo>()
            .ForMember(a => a.UserName, o => o.MapFrom(d => d.Name));
        CreateMap<UserVo, User>()
            .ForMember(a => a.Name, o => o.MapFrom(d => d.UserName));
    }
}