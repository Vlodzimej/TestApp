using System;

namespace TestApp.Hash
{
    public class Item
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Item(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}