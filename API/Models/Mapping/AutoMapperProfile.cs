using System.Reflection;
using AutoMapper;

namespace API.Models.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        LoadStandardMappings();
        LoadCustomMappings();
    }

    private void LoadStandardMappings()
    {
        var rootAssembly = Assembly.GetExecutingAssembly();
        var types = rootAssembly
            .GetExportedTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface);

        var mapsFrom = types
            .Select(t => new { type = t, interfaces = t.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)) })
            .SelectMany(agg => agg.interfaces.Select(i => new Map
            {
                Source = i.GetGenericArguments().FirstOrDefault(),
                Destination = agg.type
            }))
            .ToList();

        var mapsTo = types
            .Select(t => new { type = t, interfaces = t.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)) })
            .SelectMany(agg => agg.interfaces.Select(i => new Map
            {
                Source = agg.type,
                Destination = i.GetGenericArguments().FirstOrDefault()
            }))
            .ToList();

        var maps = mapsFrom.Union(mapsTo).ToList();
        foreach (var map in maps)
        {
            CreateMap(map.Source, map.Destination).ReverseMap();
        }
    }

    private void LoadCustomMappings()
    {
        var customMappingsType = typeof(IHaveCustomMapping);
        var maps = Assembly.GetExecutingAssembly()
            .GetExportedTypes()
            .Where(t => !t.IsAbstract
                        && !t.IsInterface
                        && customMappingsType.IsAssignableFrom(t))
            .Select(t => (IHaveCustomMapping)Activator.CreateInstance(t))
            .ToList();

        foreach (var map in maps)
        {
            map.CreateMappings(this);
        }
    }
}