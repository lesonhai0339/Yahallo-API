using Microsoft.AspNetCore.Http;

namespace YAHALLO.Infrastructure.Files.Functions;

public interface ISafeFileStorage
{
    Task<StoredFile> SaveImageAsync(IFormFile file, string relativeFolder, CancellationToken cancellationToken);
    bool DeleteFile(string relativePath);
}

public sealed record StoredFile(string FileName, string RelativePath, long Size);

public sealed class SafeFileStorage : ISafeFileStorage
{
    private static readonly HashSet<string> AllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".webp"
    };

    private const long MaxImageBytes = 5 * 1024 * 1024;
    private readonly string _storageRoot;

    public SafeFileStorage(IWebHostEnvironment environment)
    {
        _storageRoot = Path.GetFullPath(Path.Combine(environment.ContentRootPath, "Data"));
        Directory.CreateDirectory(_storageRoot);
    }

    public async Task<StoredFile> SaveImageAsync(
        IFormFile file,
        string relativeFolder,
        CancellationToken cancellationToken)
    {
        if (file.Length <= 0)
        {
            throw new InvalidOperationException("Uploaded file is empty.");
        }

        if (file.Length > MaxImageBytes)
        {
            throw new InvalidOperationException("Uploaded image exceeds the 5 MB limit.");
        }

        var extension = Path.GetExtension(file.FileName);
        if (!AllowedExtensions.Contains(extension))
        {
            throw new InvalidOperationException("Unsupported image extension.");
        }

        var safeFolder = NormalizeRelativePath(relativeFolder);
        var targetFolder = EnsureInsideRoot(Path.Combine(_storageRoot, safeFolder));
        Directory.CreateDirectory(targetFolder);

        var storedName = $"{Guid.NewGuid():N}{extension.ToLowerInvariant()}";
        var targetPath = EnsureInsideRoot(Path.Combine(targetFolder, storedName));

        await using var stream = new FileStream(
            targetPath,
            FileMode.CreateNew,
            FileAccess.Write,
            FileShare.None,
            bufferSize: 81920,
            useAsync: true);

        await file.CopyToAsync(stream, cancellationToken);

        var relativePath = Path.Combine(safeFolder, storedName).Replace('\\', '/');
        return new StoredFile(storedName, relativePath, file.Length);
    }

    public bool DeleteFile(string relativePath)
    {
        var safePath = NormalizeRelativePath(relativePath);
        var fullPath = EnsureInsideRoot(Path.Combine(_storageRoot, safePath));
        if (!File.Exists(fullPath))
        {
            return false;
        }

        File.Delete(fullPath);
        return true;
    }

    private string NormalizeRelativePath(string relativePath)
    {
        if (string.IsNullOrWhiteSpace(relativePath))
        {
            throw new InvalidOperationException("Relative path is required.");
        }

        var normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
        if (Path.IsPathRooted(normalized) || normalized.Contains(".."))
        {
            throw new InvalidOperationException("Invalid relative path.");
        }

        return normalized;
    }

    private string EnsureInsideRoot(string path)
    {
        var fullPath = Path.GetFullPath(path);
        if (!fullPath.StartsWith(_storageRoot, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Resolved path is outside storage root.");
        }

        return fullPath;
    }
}

