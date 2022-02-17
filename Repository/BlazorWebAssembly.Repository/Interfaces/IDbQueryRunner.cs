using System;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Repository.Interfaces
{
    public interface IDbQueryRunner : IDisposable
    {
        Task RunQueryAsync(string query, params object[] parameters);
    }
}
