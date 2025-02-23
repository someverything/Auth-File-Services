using Entities.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Storage.Abstract
{
    public interface IStorageServices : IStorage
    {
        public string StorageName { get; }
    }
}
