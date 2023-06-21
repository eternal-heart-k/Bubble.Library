using System;
using Bubble.Library.Foundation.Enum;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Bubble.Library.DependencyInjection;

#nullable enable
namespace Bubble.Library.Extension.Request
{
    public class ServiceClient : IServiceClient, ITransientDependency
    {
        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task SendRequestAsync(string url, HttpRequestMethod method, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = method switch
            {
                HttpRequestMethod.Get => await client.GetAsync(FormatUrl(url, requestParam, HttpRequestMethod.Get)),
                HttpRequestMethod.Post => await client.PostAsync(FormatUrl(url, requestParam, HttpRequestMethod.Post),
                    FormatParameter(requestParam, HttpRequestMethod.Post)),
                HttpRequestMethod.Put => await client.PutAsync(FormatUrl(url, requestParam, HttpRequestMethod.Put),
                    FormatParameter(requestParam, HttpRequestMethod.Put)),
                HttpRequestMethod.Delete => await client.DeleteAsync(FormatUrl(url, requestParam, HttpRequestMethod.Delete)),
                HttpRequestMethod.Patch => await client.PatchAsync(FormatUrl(url, requestParam, HttpRequestMethod.Patch),
                    FormatParameter(requestParam, HttpRequestMethod.Patch)),
                _ => throw new InvalidOperationException("Http请求方式不正确"),
            };
            response.EnsureSuccessStatusCode();
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
        public async Task<T> SendRequestAsync<T>(string url, HttpRequestMethod method, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = method switch
            {
                HttpRequestMethod.Get => await client.GetAsync(FormatUrl(url, requestParam, HttpRequestMethod.Get)),
                HttpRequestMethod.Post => await client.PostAsync(FormatUrl(url, requestParam, HttpRequestMethod.Post),
                                        FormatParameter(requestParam, HttpRequestMethod.Post)),
                HttpRequestMethod.Put => await client.PutAsync(FormatUrl(url, requestParam, HttpRequestMethod.Put),
                                        FormatParameter(requestParam, HttpRequestMethod.Put)),
                HttpRequestMethod.Delete => await client.DeleteAsync(FormatUrl(url, requestParam, HttpRequestMethod.Delete)),
                HttpRequestMethod.Patch => await client.PatchAsync(FormatUrl(url, requestParam, HttpRequestMethod.Patch),
                                        FormatParameter(requestParam, HttpRequestMethod.Patch)),
                _ => throw new InvalidOperationException("Http请求方式不正确"),
            };
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task GetAsync(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(FormatUrl(url, requestParam, HttpRequestMethod.Get));
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Get请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(FormatUrl(url, requestParam, HttpRequestMethod.Get));
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task PostAsync(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.PostAsync(FormatUrl(url, requestParam, HttpRequestMethod.Post), FormatParameter(requestParam, HttpRequestMethod.Post));
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Post请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.PostAsync(FormatUrl(url, requestParam, HttpRequestMethod.Post), FormatParameter(requestParam, HttpRequestMethod.Post));
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task PutAsync(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.PutAsync(FormatUrl(url, requestParam, HttpRequestMethod.Put), FormatParameter(requestParam, HttpRequestMethod.Put));
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Put请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task<T> PutAsync<T>(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.PutAsync(FormatUrl(url, requestParam, HttpRequestMethod.Put), FormatParameter(requestParam, HttpRequestMethod.Put));
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync(FormatUrl(url, requestParam, HttpRequestMethod.Delete));
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Delete请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task<T> DeleteAsync<T>(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync(FormatUrl(url, requestParam, HttpRequestMethod.Delete));
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Patch请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task PatchAsync(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.PatchAsync(FormatUrl(url, requestParam, HttpRequestMethod.Patch), FormatParameter(requestParam, HttpRequestMethod.Patch));
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Patch请求（有返回值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <returns></returns>
        public async Task<T> PatchAsync<T>(string url, object? requestParam = null)
        {
            using var client = new HttpClient();
            var response = await client.PatchAsync(FormatUrl(url, requestParam, HttpRequestMethod.Patch), FormatParameter(requestParam, HttpRequestMethod.Patch));
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// 格式化请求链接Url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestParam"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public virtual string FormatUrl(string url, object? requestParam, HttpRequestMethod method)
        {
            if (method != HttpRequestMethod.Get && method != HttpRequestMethod.Delete || requestParam is null)
            {
                return url;
            }

            var properties = requestParam.GetType().GetProperties()
                .Where(x => x.GetValue(requestParam, null) is not null)
                .Select(x => $"{x.Name}={HttpUtility.UrlEncode(x.GetValue(requestParam, null).ToString())}");
            var collectString = string.Join("&", properties);
            return url.Contains('?') ? url + "&" + collectString : url + "?" + collectString;
        }

        /// <summary>
        /// 格式化请求入参
        /// </summary>
        /// <param name="requestParam"></param>
        /// <param name="method"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public virtual StringContent? FormatParameter(object? requestParam, HttpRequestMethod method, string contentType = "application/json")
        {
            if (method == HttpRequestMethod.Get || method == HttpRequestMethod.Delete)
            {
                return null;
            }

            if (requestParam is null)
            {
                return new StringContent(string.Empty);
            }

            return new StringContent(JsonSerializer.Serialize(requestParam), Encoding.UTF8, contentType);
        }
    }
}
