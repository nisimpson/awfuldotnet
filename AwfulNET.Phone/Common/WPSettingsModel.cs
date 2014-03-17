using AwfulNET.Core.Common;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public class WPSettingsModel : ISettingsModel
    {
        private IsolatedStorageSettings settings;

        public WPSettingsModel()
        {
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        public T GetValueOrDefault<T>(string key, T defaultValue)
        {
            if (settings.Contains(key))
                return (T)settings[key];

            return defaultValue;
        }

        public void AddOrUpdate<T>(string key, T value)
        {
            if (!settings.Contains(key))
                settings.Add(key, value);
            else
                settings[key] = value;
        }

        public void AddOrUpdateTable(string key, IDictionary<string, object> value)
        {
            AddOrUpdate(key, value);
        }

        public IDictionary<string, object> GetTableOrDefault(string key, IDictionary<string, object> defaultValue)
        {
            return GetValueOrDefault<IDictionary<string, object>>(key, defaultValue);
        }

        public void SaveSettings()
        {
            settings.Save();
        }

        public void LoadSettings()
        {
            
        }

        public bool ContainsKey(string key)
        {
            return settings.Contains(key);
        }

        public bool Remove(string key)
        {
            return settings.Remove(key);
        }

        public bool ContainsTable(string key)
        {
            return settings.Contains(key);
        }

        public bool RemoveTable(string key)
        {
            return settings.Remove(key);
        }
    }
}
