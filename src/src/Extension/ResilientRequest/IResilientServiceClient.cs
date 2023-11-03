using Bubble.Library.Foundation.Enum;
using System.Threading.Tasks;
using System;

#nullable enable
namespace Bubble.Library.Extension.ResilientRequest
{
    /// <summary>
    /// 会重试的请求
    /// </summary>
    public interface IResilientServiceClient
    {
        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task SendRequestAsync(string url, HttpRequestMethod method, object? requestParam = null);

        /// <summary>
        /// 发送Http请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<T> SendRequestAsync<T>(string url, HttpRequestMethod method, object? requestParam = null);
    }
}
