using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.DataModel
{
    public delegate string JumpListGroupKeyDelegate<T>(T item);

    public interface IJumpListDataModel<T>
    {
        string Key { get; }
    }

    public class JumpListDataModel<T> : List<T>, IJumpListDataModel<T>
    {
        public string Key { get; set; }

        public JumpListDataModel(string key) : base()
        {
            this.Key = key;
        }

        public static IList<JumpListDataModel<T>> CreateGroups(
            IEnumerable<T> items,
            JumpListGroupKeyDelegate<T> keyDelegate,
            Comparison<T> sortDelegate = null)
        {
            Dictionary<string, JumpListDataModel<T>> groups = new Dictionary<string, JumpListDataModel<T>>();
            foreach(var item in items)
            {
                string key = keyDelegate(item);
                if (!groups.ContainsKey(key)) { groups.Add(key, new JumpListDataModel<T>(key)); }
                groups[key].Add(item);
            }

            if (sortDelegate != null)
            {
                foreach(var group in groups.Values)
                    group.Sort(sortDelegate);
            }

            return groups.Values.ToList();
        }

        public override string ToString()
        {
            return this.Key;
        }
    }
}