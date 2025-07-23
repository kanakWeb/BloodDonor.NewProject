namespace BloodDonor.NewProject.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
      
    }
}
