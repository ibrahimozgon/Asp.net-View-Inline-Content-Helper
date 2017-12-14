using System.Collections.Generic;

namespace InlineContentHelper.CacheManagers
{
    public class FirstLevelCacheManager : IFirstLevelCacheManager
    {
        private Dictionary<string, object> Data { get; set; }

        public FirstLevelCacheManager()
        {
            Data = new Dictionary<string, object>();
        }

        public bool IsSet(string key)
        {
            return Data.TryGetValue(key, out var data) && data != null;
        }

        public T Get<T>(string key)
        {
            return (T)Data[key];
        }

        public void Set<T>(string key, T data)
        {
            Data[key] = data;
        }

        public void Remove(string key)
        {
            if (IsSet(key))
                Data.Remove(key);
        }

        public void Dispose()
        {
            if (Data != null)
                Data = null;
        }
    }
}