using AutoMapper;

namespace API.Models.Mapping;

public interface IHaveCustomMapping
{
    void CreateMappings(Profile configuration);
}