using AwfulNET.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AwfulNET.WinRT.Common
{
    public class WinRTSettingsModel : ISettingsModel
    {
        protected virtual ApplicationDataContainer settings { get { return ApplicationData.Current.LocalSettings; } }

        public T GetValueOrDefault<T>(string key, T defaultValue)
        {
            if (settings.Values.ContainsKey(key))
                return (T)settings.Values[key];

            return defaultValue;
        }

        public void AddOrUpdate<T>(string key, T value)
        {
            if (settings.Values.ContainsKey(key))
                settings.Values[key] = value;

            else
                settings.Values.Add(new KeyValuePair<string, object>(key, value));
        }

        public void AddOrUpdateTable(string key, IDictionary<string, object> value)
        {
            var container = settings.CreateContainer(key, ApplicationDataCreateDisposition.Always);
            container.Values.Clear();
            var pairs = value.ToList();
            foreach(var pair in pairs)
                container.Values.Add(pair);
        }

        public IDictionary<string, object> GetTableOrDefault(string key, IDictionary<string, object> defaultValue)
        {
            try
            {
                var container = settings.CreateContainer(key, ApplicationDataCreateDisposition.Existing);
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (var pair in container.Values)
                    result.Add(pair.Key, pair.Value);

                return result;
            }
            catch (Exception) { }
            return defaultValue;
        }

        public void SaveSettings() { }

        public void LoadSettings() { }

        public bool ContainsKey(string key)
        {
            return settings.Values.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return settings.Values.Remove(key);
        }

        public bool ContainsTable(string key)
        {
            try
            {
                var container = settings.CreateContainer(key, ApplicationDataCreateDisposition.Existing);
                return container != null;
            }
            catch (Exception) { }
            return false;
        }

        public bool RemoveTable(string key)
        {
            settings.DeleteContainer(key);
            return true;
        }
    }

    public class WinRTRoamingSettingsModel : WinRTSettingsModel
    {
        protected override ApplicationDataContainer settings
        {
            get
            {
                return ApplicationData.Current.RoamingSettings;
            }
        }
    }
}
