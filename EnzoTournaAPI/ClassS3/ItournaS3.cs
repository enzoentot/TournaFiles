using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EnzoTournaAPI.ClassS3
{
    public interface ItournaS3
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<byte[]> DownloadFileAsync(string fileKey);
    }
}