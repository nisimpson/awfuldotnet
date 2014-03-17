using AwfulNET.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AwfulNET.Common
{
    internal class WPStorageModel : IStorageModel
    {
        public static readonly WPStorageModel Instance;
        static WPStorageModel() { Instance = new WPStorageModel(); }

        private WPStorageModel() { }

        public async Task SaveToStorageAsync<T>(string path, T value)
        {
            var storage = ApplicationData.Current.LocalFolder;
            var file = await storage.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenStreamForWriteAsync())
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                dcs.WriteObject(stream, value);
            }
        }

        public async Task<T> LoadFromStorageAsync<T>(string path)
        {
            T result = default(T);
            var storage = ApplicationData.Current.LocalFolder;
            var file = await storage.CreateFileAsync(path, CreationCollisionOption.OpenIfExists);
            using (var stream = await file.OpenStreamForReadAsync())
            {
                
                    DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                    object data = dcs.ReadObject(stream);
                    if (data != null)
                        result = (T)data;

                    else { throw new Exception("data missing, not of specified type, or corrupted."); }
            }

            return result;
        }
    }
}
