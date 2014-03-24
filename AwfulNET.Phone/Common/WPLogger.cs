using AwfulNET.Common;
using AwfulNET.Core;
using AwfulNET.Core.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AwfulNET.Phone.Common
{
    [DataContract]
    public class WPLogger : BindableBase, ILog
    {
        public WPLogger()
        {
            this.entries = new ObservableCollection<LogEntry>();
        }

        private static object lockObj = new object();
       
        private ObservableCollection<LogEntry> entries;
        [DataMember]
        public ObservableCollection<LogEntry> Entries
        {
            get { return this.entries; }
            set { SetProperty(ref this.entries, value); }
        }

        public void AddEntry(LogLevel level, string message)
        {
            LogEntry entry = new LogEntry() { Level = level, Message = message, Timestamp = DateTime.UtcNow };
            Deployment.Current.Dispatcher.BeginInvoke(() => { entries.Add(entry); });
        }

        public void AddEntry(LogLevel level, Exception ex)
        {
            string message = string.Format("<{0}> {1}", ex.GetType(), ex.Message);
            AddEntry(level, message);
        }

        public string WriteAsString()
        {
           StringBuilder result = new StringBuilder();
           lock (lockObj)
           {
               foreach (var entry in entries)
                   result.AppendLine(entry.ToString());
           }

           return result.ToString();
        }

        public async Task<bool> SaveLogToStorageAsync()
        {
            bool success = false;
            string snapshot = WriteAsString();
            string filename = string.Format("{0}.log", DateTime.Now.Date.ToString("{0:yyyyMMdd}"));
            var storage = ApplicationData.Current.LocalFolder;
            try
            {
                var file = await storage.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
                using (var stream = await file.OpenStreamForWriteAsync())
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(snapshot);
                }

                success = true;
            }
            catch (Exception ex) 
            {
                success = false;
            }

            return success;
        }
    }
}
