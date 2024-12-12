namespace ProApiFull.Service.Contract.Products.Images;
public record DownloadImageResponse
    (
    byte[]? FileContent,
    string FileName,
    string ContentType
    );
