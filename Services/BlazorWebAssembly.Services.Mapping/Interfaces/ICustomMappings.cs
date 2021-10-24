using AutoMapper;

namespace BlazorWebAssembly.Services.Mapping.Interfaces
{
    public interface ICustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
