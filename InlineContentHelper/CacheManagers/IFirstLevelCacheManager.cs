namespace InlineContentHelper.CacheManagers
{
    public interface IFirstLevelCacheManager
    {
        bool IsSet(string key);
        T Get<T>(string key);
        void Set<T>(string key, T data);
        void Remove(string key);
    }
}