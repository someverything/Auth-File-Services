using Business.Utilities.Storage.Abstract.Local;
using Entities.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Storage.Concrete.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IHostingEnvironment _environment;

        public LocalStorage(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
            => System.IO.File.Delete($"{pathOrContainerName}\\{fileName}");

        public Task<List<string>> GetAllFilesAsync(string? pathOrContainerName = null)
        {
            if (pathOrContainerName == null)
            {
                var wwwrootPath = Path.Combine(_environment.WebRootPath);
                var file = GetFilesFromDirectory(wwwrootPath);
                return Task.FromResult(file);
            }

            var path = Path.Combine(_environment.WebRootPath, pathOrContainerName);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            return Task.FromResult(directoryInfo.GetFiles().Select(x => x.Name).ToList());

        }

        private List<string> GetFilesFromDirectory(string directory)
        {
            var filesList = new List<string>();
            var files = Directory.GetFiles(directory);
            var directories = Directory.GetDirectories(directory);

            foreach ( var d in directories )
            {
                filesList.AddRange(GetFilesFromDirectory(d));
            }

            return filesList;
        }

        public async Task<Upload> UploadFileAsync(string containerName, IFormFile file)
        {
            string uploadPath = Path.Combine(_environment.WebRootPath, containerName);

            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var newFileName = Guid.NewGuid() + file.FileName;
            var path = Path.Combine(uploadPath, newFileName);

            if(Path.GetExtension(file.FileName).ToLower() == ".svg")
            {
                await CopyFileAsync(path, file);
            }
            else
            {
                await CopyFileAsync(path, file);
                await CompressSaveImageAsync(file, path);
            }

            return new Upload
            {
                FileName = newFileName,
                Path = uploadPath
            };
        }

        private static async Task CompressSaveImageAsync(IFormFile file, string outputPath)
        {
            try
            {
                using var image = await SixLabors.ImageSharp.Image.LoadAsync(file.OpenReadStream());
                var extension = Path.GetExtension(file.FileName).ToLower();

                IImageEncoder emcoder = extension switch
                {
                    ".jpg" or ".jpeg" => new JpegEncoder
                    {
                        // Adjust the quality to reduce the file size
                        Quality = 75
                    },
                    ".png" => new PngEncoder
                    {
                        // Adjust the compression level
                        CompressionLevel = PngCompressionLevel.BestCompression
                    },
                    ".bmp" => new BmpEncoder(),
                    ".gif" => new GifEncoder(),
                    _ => throw new InvalidOperationException("Unsupported image format."),
                };

                await image.SaveAsync(outputPath, emcoder);
            }
            catch (UnknownImageFormatException)
            {

                throw new InvalidOperationException("Unsupported image format");
            }
        }

        private async Task MinifySaveImageAsync(IFormFile file, string path)
        {
            try
            {
                using var image = await SixLabors.ImageSharp.Image.LoadAsync<Rgba32>(file.OpenReadStream());

                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Max,
                    Size = new Size(800, 800)
                }));

                var encoder = new JpegEncoder
                {
                    Quality = 75
                };

                await image.SaveAsync(path, encoder);
            }
            catch (UnknownImageFormatException)
            {

                throw new InvalidOperationException("Unsupported image format.");
            }
        }

        public async Task<List<Upload>> UploadFilesAsync(string containerName, IFormFileCollection files)
        {
            var uploadList = new List<Upload>();
            foreach (var file in files)
            {
                var uploadDTO = await UploadFileAsync(containerName, file);
                uploadList.Add(uploadDTO);
            }

            return uploadList;
        }

        static async Task<bool> CopyFileAsync(string filePath, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: true);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
