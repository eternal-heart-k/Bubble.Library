using System;
using System.Threading.Tasks;
using Bubble.Library.DependencyInjection;
using Bubble.Library.Extension.Request;
using Bubble.Library.Foundation.Enum;
using Polly;

#nullable enable
namespace Bubble.Library.Extension.ResilientRequest
{
    /// <summary>
    /// 
    /// </summary>
    public class ResilientServiceClient : IResilientServiceClient, ITransientDependency
    {
        private readonly IServiceClient _serviceClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceClient"></param>
        public ResilientServiceClient(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task SendRequestAsync(string url, HttpRequestMethod method, object? requestParam)
        {
            await Policy.Handle<System.Exception>() // 捕获所有异常  
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(() => _serviceClient.SendRequestAsync(url, method, requestParam));
        }

        /// <summary>
        /// 发送Http请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<T> SendRequestAsync<T>(string url, HttpRequestMethod method, object? requestParam)
        {
            return await Policy.Handle<System.Exception>() // 捕获所有异常  
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(() => _serviceClient.SendRequestAsync<T>(url, method, requestParam));
        }
    }
}
