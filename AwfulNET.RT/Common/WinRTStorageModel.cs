using AwfulNET.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AwfulNET.Common
{
    public class WinRTStorageModel : IStorageModel
    {
        private WinRTStorageModel() { }

        static WinRTStorageModel() { Instance = new WinRTStorageModel(); }

        public async Task SaveToStorageAsync<T>(string path, T value)
        {
            MemoryStream sessionData = new MemoryStream();
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));
            dcs.WriteObject(sessionData, value);
            var appfolder = ApplicationData.Current.LocalFolder;
            var file = await appfolder.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenStreamForWriteAsync())
            {
                sessionData.Seek(0, SeekOrigin.Begin);
                await sessionData.CopyToAsync(stream);
            }
        }

        public async Task<T> LoadFromStorageAsync<T>(string path)
        {
            T data = default(T);
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(path);
            using (IInputStream inStream = await file.OpenSequentialReadAsync())
            {
                DataContractSerializer serializer =
                        new DataContractSerializer(typeof(T));
                data = (T)serializer.ReadObject(inStream.AsStreamForRead());
            }

            return data;
        }

        public static WinRTStorageModel Instance { get; private set; }
    }
}
