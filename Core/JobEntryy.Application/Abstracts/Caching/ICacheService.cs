using Microsoft.Extensions.Caching.Memory;

namespace JobEntryy.Application.Abstracts.Caching
{
    public interface ICacheService
    {
        public void Set<T>(string key, T value, int slidingExpirationMinutes, int AbsoluteExpirationRelativeToNowMinutes, CacheItemPriority priority);
        T? Get<T>(string key);
        void Remove(string key);
    }
}
