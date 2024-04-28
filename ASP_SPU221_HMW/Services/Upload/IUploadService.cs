namespace ASP_SPU221_HMW.Services.Upload
{
    public interface IUploadService
    {
        String SaveFormFile(IFormFile formFile);
        String SaveFormFile(IFormFile formFile, String path);
        String SaveFormFile(IFormFile formFile,String path, IEnumerable<String> extensionsAllowed);

    }
}
