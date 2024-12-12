using Microsoft.AspNetCore.Hosting;
using ProApiFull.Domin.PublicEntities;

namespace HandlingFiles.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment webHost;
    public FileService(IWebHostEnvironment webHost)
    {
        this.webHost = webHost;
    }
    public async Task<IEnumerable<UploadFile>> UploadManyAsync(IFormFileCollection files, string folderName, CancellationToken cancellationToken = default!)
    {
        List<UploadFile> uploadedFiles = [];
        if (files == null)
            return new List<UploadFile>();
        foreach (var file in files)
            uploadedFiles.Add(await SaveFile(file, folderName, cancellationToken));
        return uploadedFiles;
    }
    public async Task<UploadFile> UploadImageAsync(IFormFile image, string folderName, CancellationToken cancellationToken = default)
    {
        return await SaveFile(image, folderName, cancellationToken);
    }
    public async Task<(byte[] fileContent, string contentType, string fileName)>
        DownloadAsync(string fileName,
        string contentType,
        string folderName,
        CancellationToken cancellationToken = default)
    {
        if (fileName is null)
            return ([], string.Empty, string.Empty);
        var filePath = CheckExistOrCreateFolder(folderName);
        var path = Path.Combine(filePath, fileName);

        MemoryStream memoryStream = new();
        using FileStream fileStream = new(path, FileMode.Open);
        fileStream.CopyTo(memoryStream);

        memoryStream.Position = 0;

        return (memoryStream.ToArray(), contentType, fileName);
    }
    public async Task<bool> DeleteFile(string fileName, string folderName)
    {
        var path = Path.Combine($"{webHost.WebRootPath}/{folderName}/", fileName);
        if (!File.Exists(path))
            return false;

        File.Delete(path);
        return true;
    }
    public async Task<bool> DeleteFile(List<string> files, string folderName)
    {
        if (files == null)
            return false;
        foreach (var file in files)
            await DeleteFile(file, folderName);
        return true;
    }
    private async Task<UploadFile> SaveFile(IFormFile file, string folderName, CancellationToken cancellationToken = default!)
    {
        var uniqNumber = new Random().Next(1000, 9999);
        var uploadFile = new UploadFile
        {
            FileName = uniqNumber + file.FileName,
            ContentType = file.ContentType,
            FileExetension = Path.GetExtension(file.FileName)
        };
        var filePath = CheckExistOrCreateFolder(folderName);

        var path = Path.Combine(filePath, uploadFile.FileName);
        using var stream = File.Create(path);
        await file.CopyToAsync(stream, cancellationToken);
        return uploadFile;
    }
    private string CheckExistOrCreateFolder(string folderName)
    {
        var filePath = $"{webHost.WebRootPath}\\" + folderName;
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        return filePath;
    }
}
