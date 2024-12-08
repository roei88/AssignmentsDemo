using System;
using System.Collections.Concurrent;

#nullable enable

namespace CommBox.Infra.Common
{
    public class InMemoryCache : IInMemoryCache
    {
        private readonly ConcurrentDictionary<string, object> _cache = new();

        public T? Get<T>(string key) => throw new NotImplementedException();

        public void Set<T>(string key, T value) => throw new NotImplementedException();

        public void Remove(string key) => throw new NotImplementedException();

        public void Clear() => throw new NotImplementedException();
    }
}
