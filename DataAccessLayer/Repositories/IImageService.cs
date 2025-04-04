using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IImageService
    {
        Tuple<int, string> SaveImage(IFormFile file, string folderPath);
        Task DeleteImage(string filePath);
    }
}
