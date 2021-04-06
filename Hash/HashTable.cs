using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.Hash
{
    public class HashTable
    {
        int _maxSize = 256;
        private Dictionary<int, List<Item>> items = null;

        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => items?.ToList()?.AsReadOnly();

        public HashTable()
        {
            items = new Dictionary<int, List<Item>>(_maxSize);
        }

        public void Insert(string key, string value)
        {
            var item = new Item(key, value);
            var hash = GetHash(item.Key);

            List<Item> hashTableItem = null;

            if (items.ContainsKey(hash))
            {
                hashTableItem = items[hash];
                if (hashTableItem.SingleOrDefault(i => i.Key == item.Key) != null)
                {
                    return;
                }

                items[hash].Add(item);
            }
            else
            {
                hashTableItem = new List<Item>{ item };
                items.Add(hash, hashTableItem);
            }
        }

        public void Delete(string key)
        {
            var hash = GetHash(key);

            if (items.ContainsKey(hash))
            {
                return;
            }

            var hashTableItem = items[hash];
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);

            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }

        public string Search(string key)
        {
            var hash = GetHash(key);

            if(!items.ContainsKey(hash))
            {
                return null;
            }

            var hashTableItem = items[hash];
            if (hashTableItem != null)
            {
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);

                if (item != null)
                {
                   return item.Value;
                }
            }
            return null;
        }

        private int GetHash(string value)
        {
            return value.Length;
        }
    }
}