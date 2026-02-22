using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using Trivo.Application.Interfaces.Services;
using Trivo.Domain.Configurations;

namespace Trivo.Infrastructure.Shared.Services;

public sealed class CloudinaryService(IOptions<CloudinarySetting> cloudinary) : ICloudinaryService
{
    private CloudinarySetting Cloudinary { get; } = cloudinary.Value;

    public async Task<string> UploadImageAsync(
        Stream file,
        string imageName,
        CancellationToken cancellationToken)
    {
        Cloudinary cloudinary = new(Cloudinary.CloudinaryUrl);

        ImageUploadParams image = new()
        {
            File = new FileDescription(imageName, file),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = true
        };

        var uploadResult = await cloudinary.UploadAsync(image, cancellationToken);

        return uploadResult.SecureUrl.ToString();
    }

    public async Task<string> UploadFileAsync(
        Stream file,
        string fileName,
        CancellationToken cancellationToken)
    {
        Cloudinary cloudinary = new(Cloudinary.CloudinaryUrl);

        RawUploadParams uploadFile = new()
        {
            File = new FileDescription(fileName, file),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = true
        };

        RawUploadResult uploadResult =
            await cloudinary.UploadAsync(uploadFile, "raw", cancellationToken);

        return uploadResult.SecureUrl.ToString();
    }
}