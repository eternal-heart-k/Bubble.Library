using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// Redis分布式缓存相关
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        /// 缓存默认过期时间
        /// </summary>
        private static TimeSpan DefaultExpireTime => TimeSpan.FromHours(1);

        /// <summary>
        /// 直接添加字符串类型缓存
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpireTime"></param>
        /// <param name="slidingExpireTime"></param>
        /// <returns></returns>
        public static async Task SetStringAsync(this IDistributedCache cache, string key, string value,
            TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? DefaultExpireTime,
                SlidingExpiration = slidingExpireTime
            };
            await cache.SetStringAsync(key, value, options);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpireTime"></param>
        /// <param name="slidingExpireTime"></param>
        /// <returns></returns>
        public static async Task SetAsync<T>(this IDistributedCache cache, string key, T value,
            TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? DefaultExpireTime,
                SlidingExpiration = slidingExpireTime
            };

            var jsonData = JsonSerializer.Serialize(value);
            await cache.SetStringAsync(key, jsonData, options);
        }
        
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key)
        {
            var jsonData = await cache.GetStringAsync(key);

            return jsonData is null ? default : JsonSerializer.Deserialize<T>(jsonData);
        }

        /// <summary>
        /// 获取缓存，若不存在则添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <param name="absoluteExpireTime"></param>
        /// <param name="slidingExpireTime"></param>
        /// <returns></returns>
        public static async Task<T> GetOrSetAsync<T>(this IDistributedCache cache, string key, Func<Task<T>> factory,
            TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
        {
            var result = await cache.GetAsync<T>(key);
            if (EqualityComparer<T>.Default.Equals(result, default))
            {
                T value = await factory();
                await cache.SetAsync(key, value, absoluteExpireTime, slidingExpireTime);
                result = value;
            }
            return result;
        }
    }
}
