using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LRUCache
    {
        private const int NotFound = -1;
        private int _count;
        private readonly int _capacity;
        private readonly LinkedList<CacheItem> _items;
        private readonly Dictionary<int, LinkedListNode<CacheItem>> _keys;

        public LRUCache(int capacity)
        {
            _items = new LinkedList<CacheItem>();
            _keys = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
            _count = 0;
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_keys.ContainsKey(key))
            {
                return NotFound;
            }

            var cacheItem = _keys[key];

            PromoteToMRU(cacheItem);

            return cacheItem.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (!_keys.ContainsKey(key))
            {
                // add
                _keys[key] = _items.AddFirst(new CacheItem(key, value));

                if (_count == _capacity)
                {
                    // remove least recently used
                    var last = _items.Last;
                    _keys.Remove(last.Value.Key);
                    _items.RemoveLast();
                }
                else
                {
                    _count++;
                }
            }
            else
            {
                // update
                var cacheItem = _keys[key];
                cacheItem.Value.Value = value;

                PromoteToMRU(cacheItem);
            }
        }

        private void PromoteToMRU(LinkedListNode<CacheItem> cacheItem)
        {
            if (cacheItem != _items.First)
            {
                // promote to most recently used
                _items.Remove(cacheItem);
                _items.AddFirst(cacheItem);
            }
        }

        private class CacheItem
        {
            public CacheItem(int key, int value)
            {
                Key = key;
                Value = value;
            }

            public int Key { get; }

            public int Value { get; set; }
        }
    }
}
