using AutoMapper;

namespace Hao.MES.Extension.AutoMapper;

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
