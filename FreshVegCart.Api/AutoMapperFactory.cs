using System.Reflection;
using AutoMapper;

namespace FreshVegCart.Api;

public class AutoMapperFactory
{
    public static AutoMapper.IConfigurationProvider CreateMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            var assembly = Assembly.GetAssembly(typeof(AutoMapperFactory));

            cfg.AddMaps(assembly);
        });

        return config;
    }
}
