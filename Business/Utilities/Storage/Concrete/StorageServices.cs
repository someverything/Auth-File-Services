using Business.Utilities.Storage.Abstract;
using Entities.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Storage.Concrete
{
    public class StorageServices : IStorageServices
    {
        private readonly IStorage _storage;

        public StorageServices(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            await _storage.DeleteAsync(pathOrContainerName, fileName);
        }

        public async Task<List<string>> GetAllFilesAsync(string? pathOrContainerName = null)
        {
            return await _storage.GetAllFilesAsync(pathOrContainerName);
        }

        public async Task<Upload> UploadFileAsync(string containerName, IFormFile file)
        {
            return await _storage.UploadFileAsync(containerName, file);
        }

        public Task<List<Upload>> UploadFilesAsync(string containerName, IFormFileCollection files)
        {
            return _storage.UploadFilesAsync(containerName, files);
        }
    }
}
