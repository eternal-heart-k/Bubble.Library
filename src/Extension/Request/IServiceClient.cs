using Bubble.Library.Foundation.Enum;
using System;
using System.Threading.Tasks;

namespace Bubble.Library.Extension.Request
{
    public interface IServiceClient
    {
        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task SendRequestAsync(string url, HttpRequestMethod method, object? requestParam);

        /// <summary>
        /// 发送Http请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task<T> SendRequestAsync<T>(string url, HttpRequestMethod method, object? requestParam);

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task GetAsync(string url, object? requestParam);

        /// <summary>
        /// Get请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task PostAsync(string url, object? requestParam);

        /// <summary>
        /// Post请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task<T> PostAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task PutAsync(string url, object? requestParam);

        /// <summary>
        /// Put请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task<T> PutAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task DeleteAsync(string url, object? requestParam);

        /// <summary>
        /// Delete请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task<T> DeleteAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Patch请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task PatchAsync(string url, object? requestParam);

        /// <summary>
        /// Patch请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public Task<T> PatchAsync<T>(string url, object? requestParam);
    }
}
