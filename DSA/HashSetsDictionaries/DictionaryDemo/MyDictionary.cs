using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDemo
{
    public class MyDictionary<K, V>
    {
        private HashSetDemo.HashSet<KeyValuePair<K, V>> set;

        public MyDictionary()
        {
            set = new HashSetDemo.HashSet<KeyValuePair<K, V>>();
        }

        public bool Add(K key, V value)
        {
            var item = new KeyValuePair<K, V>(key, value);
            return this.set.Add(item);
        }

        public bool ContainsKey(K key)
        {
            return this.set.Contains(new KeyValuePair<K, V>(key, default(V)));
        }

        public bool RemoveKey(K key)
        {
            return this.set.Remove(new KeyValuePair<K, V>(key, default(V)));
        }

        public KeyValuePair<K, V> Find(K key)
        {
            return this.set.Find(new KeyValuePair<K, V>(key, default(V)));
        }

        public int Count => set.Count;

        public V this[K key]
        {
            get
            {
                return this.Find(key).Value;
            }
            set
            {
                var found = this.Find(key);
                if (found == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    found.Value = value;
                }
            }
        }
    }
}
