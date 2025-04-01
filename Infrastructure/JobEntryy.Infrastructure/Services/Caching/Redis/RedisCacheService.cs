using System.Text.Json;
using JobEntryy.Application.Abstracts.Caching;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobEntryy.Infrastructure.Services.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly StackExchange.Redis.IDatabase database;
        public RedisCacheService(IConnectionMultiplexer multiplexer)
        {
            database = multiplexer.GetDatabase();
        }

        public T? Get<T>(string key)
        {
            var data = database.StringGet(key);
            return data.HasValue ? JsonSerializer.Deserialize<T>(data!) : default;
        }

        public void Remove(string key)
        {
            database.KeyDelete(key);
        }

        public void Set<T>(string key, T value, int slidingExpirationMinutes, int AbsoluteExpirationRelativeToNowMinutes, CacheItemPriority priority)
        {
            var jsonData = JsonSerializer.Serialize(value);
            var expiry = TimeSpan.FromMinutes(AbsoluteExpirationRelativeToNowMinutes);
            database.StringSet(key, jsonData, expiry);
        }
    }
}
