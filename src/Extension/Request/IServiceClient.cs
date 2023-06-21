using Bubble.Library.Foundation.Enum;
using System;
using System.Net.Http;
using System.Threading.Tasks;

#nullable enable
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
        Task SendRequestAsync(string url, HttpRequestMethod method, object? requestParam);

        /// <summary>
        /// 发送Http请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<T> SendRequestAsync<T>(string url, HttpRequestMethod method, object? requestParam);

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task GetAsync(string url, object? requestParam);

        /// <summary>
        /// Get请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task PostAsync(string url, object? requestParam);

        /// <summary>
        /// Post请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task PutAsync(string url, object? requestParam);

        /// <summary>
        /// Put请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task<T> PutAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task DeleteAsync(string url, object? requestParam);

        /// <summary>
        /// Delete请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task<T> DeleteAsync<T>(string url, object? requestParam);

        /// <summary>
        /// Patch请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task PatchAsync(string url, object? requestParam);

        /// <summary>
        /// Patch请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        Task<T> PatchAsync<T>(string url, object? requestParam);

        /// <summary>
        /// 格式化请求链接Url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        string FormatUrl(string url, object? requestParam, HttpRequestMethod method);

        /// <summary>
        /// 格式化请求入参
        /// </summary>
        /// <param name="requestParam"></param>
        /// <param name="method"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        StringContent? FormatParameter(object? requestParam, HttpRequestMethod method,
            string contentType = "application/json");
    }
}
