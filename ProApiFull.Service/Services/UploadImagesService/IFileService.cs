using ProApiFull.Domin.PublicEntities;

namespace HandlingFiles.Services;

public interface IFileService
{
    Task<bool> DeleteFile(List<string> files, string folderName);
    Task<bool> DeleteFile(string fileName, string folderName);
    Task<(byte[] fileContent, string contentType, string fileName)>
        DownloadAsync(string fileName,
        string contentType,
        string folderName,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<UploadFile>> UploadManyAsync(IFormFileCollection files, string folderName, CancellationToken cancellationToken = default!);
    Task<UploadFile> UploadImageAsync(IFormFile image, string folderName, CancellationToken cancellationToken = default);
}
