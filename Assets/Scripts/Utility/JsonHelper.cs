using System;
using UnityEngine;

namespace Utility
{
    public static class JsonHelper 
    {
        public static T[] FromJson<T>(string json)
        {
            json = AddItemsWrapperSignature(json);
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.items;
        }
        
        public static string ToJson<T>(T[] array, bool prettyPrint = false)
        {
            var wrapper = new Wrapper<T>
            {
                items = array
            };
            var json = JsonUtility.ToJson(wrapper, prettyPrint);
            json = RemoveItemsWrapperSignature(json);
            return json;
        }
        
        [Serializable]
        private class Wrapper<T>
        {
            public T[] items;
        }
        
        private static string RemoveItemsWrapperSignature(string s)
        {
            s = s.Substring(s.IndexOf(":", StringComparison.Ordinal) + 1);
            s = s.Remove(s.LastIndexOf("}", StringComparison.Ordinal));
            return s;
        }
        
        private static string AddItemsWrapperSignature(string s)
        {
            return "{\"items\":" + s + "}";
        }
    }
}