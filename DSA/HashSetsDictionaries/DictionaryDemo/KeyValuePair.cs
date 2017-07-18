using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDemo
{
    public class KeyValuePair<K, V>
    {
        private readonly K key;

        public KeyValuePair(K key, V value)
        {
            this.key = key;
            this.Value = value;
        }

        public K Key => key; // grtter
        public V Value { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as KeyValuePair<K, V>;
            return this.key.Equals(other.key);
        }

        public override int GetHashCode()
        {
            return this.key.GetHashCode();
        }
    }
}
