using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BlazaorWebAssembly.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadAsync(IFormFile file, string fileName);

        Task DeleteImage(Cloudinary cloudinary, string name);
    }
}
