namespace CommBox.Infra.Common
{
    public interface IInMemoryCache
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
        void Remove(string key);
        void Clear();
    }
}