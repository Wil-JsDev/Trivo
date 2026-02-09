namespace Trivo.Application.Interfaces.Services;

public interface ICloudinaryService
{
    Task<string> UploadImageAsync(
        Stream file,
        string imageName,
        CancellationToken cancellationToken);

    Task<string> UploadFileAsync(
        Stream file,
        string fileName,
        CancellationToken cancellationToken);
}