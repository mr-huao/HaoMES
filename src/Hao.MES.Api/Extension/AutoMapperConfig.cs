using AutoMapper;

namespace Hao.MES.Api.Extension;

public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CustomProFile());
        });
    }
}
