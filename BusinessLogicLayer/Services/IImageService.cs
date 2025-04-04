using Microsoft.AspNetCore.Http;


namespace BusinessLogicLayer.Services
{
    public interface IImageService
    {
        Tuple<int, string> SaveImage(IFormFile file, string folderPath);
        Task DeleteImage(string filePath);
    }
}
