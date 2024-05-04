namespace ASP_SPU221_HMW.Services.Upload
{
    public class UploadServiceV1 : IUploadService
    {
        public string SaveFormFile(IFormFile formFile)
        {
            return SaveFormFile(formFile, "wwwroot/upload");
        }

        public string SaveFormFile(IFormFile formFile, string path)
        {
            return SaveFormFile(formFile, path, []);
        }

        public string SaveFormFile(IFormFile formFile, string path, IEnumerable<string> extensionsAllowed)
        {
            ArgumentNullException.ThrowIfNull(formFile, nameof(formFile));
            ArgumentNullException.ThrowIfNull(path, nameof(path));

            String ext = Path.GetExtension(formFile.FileName);
            if (extensionsAllowed.Any() && !extensionsAllowed.Any(e => e == ext))
            {
                throw new Exception("extension not allowed");
            }
            String savedName = Guid.NewGuid().ToString() + ext;
            String location = Path.Combine(Directory.GetCurrentDirectory(),
                path,
                savedName);
            using var stream = System.IO.File.OpenWrite(location);
            formFile.CopyTo(stream);
            return savedName;
        }
    }
}
