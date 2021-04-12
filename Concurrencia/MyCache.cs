using System;
using System.Collections.Generic;
using System.Text;

namespace Concurrencia.Console
{
    public class MyCache: IMyCache
    {
        private int _length;
        private Dictionary<int, int> _cache;

        public MyCache()
        {

        }

        public int Length()
        {
            return _cache.Count;
        }

        public void Add(KeyValuePair<int, int> keyItem)
        {
            if (_cache.ContainsKey(keyItem.Key))
            {
                throw new ArgumentException("Item already exists");
            }

            _cache.Add(keyItem.Key, keyItem.Value);
        }

        public int Get(int key)
        {
            if (_cache.ContainsKey(key))
            {
                return _cache[key];
            }

            return -1;
        }
    }
}
