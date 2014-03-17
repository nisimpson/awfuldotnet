using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    public interface ISettingsModel
    {
        T GetValueOrDefault<T>(string key, T defaultValue);
        void AddOrUpdate<T>(string key, T value);

        void AddOrUpdateTable(string key, IDictionary<string, object> value);
        IDictionary<string, object> GetTableOrDefault(string key, IDictionary<string, object> defaultValue);

        void SaveSettings();
        void LoadSettings();

        bool ContainsKey(string key);
        bool Remove(string key);

        bool ContainsTable(string key);
        bool RemoveTable(string key);
    }
}
