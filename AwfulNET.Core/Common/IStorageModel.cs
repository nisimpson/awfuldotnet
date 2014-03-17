using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core
{
    public interface IStorageModel
    {
        Task SaveToStorageAsync<T>(string path, T value);
        Task<T> LoadFromStorageAsync<T>(string path);
    }
}