using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _environment;
        public  ImageService(IHostingEnvironment env)
        {
            _environment = env;
        }
        public Tuple<int, string> SaveImage(IFormFile imageFile, string imagePath)
        {
            try
            {
                var contentPath = _environment.ContentRootPath;
                
                var path = Path.Combine(contentPath, "UPLOADS");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extenstions
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                string uniqueString = Guid.NewGuid().ToString();

                // File Name
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                // Save the file
                imageFile.CopyTo(stream);
                stream.Close();

                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }

        public async Task DeleteImage(string imageFileName)
        {
            var contentPath = _environment.ContentRootPath;

            var path = Path.Combine(contentPath, $"Uploads", imageFileName);
            if (File.Exists(path))
                File.Delete(path);
        }
    }
 
}
