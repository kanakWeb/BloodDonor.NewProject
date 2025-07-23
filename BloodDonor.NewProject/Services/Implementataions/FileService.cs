using BloodDonor.NewProject.Services.Interfaces;

namespace BloodDonor.NewProject.Services.Implementataions
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveFileAsync(IFormFile? file)
        {

            if (file != null && file.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, "profiles");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var fullPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Path.Combine("profiles", fileName); // Store the relative path to the profile picture   
            }
            return string.Empty; // Return an empty string if no file is provided
        }

    }


}
