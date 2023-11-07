using System;
using System.Text.Encodings.Web;
using System.Text.Json;

#nullable enable
namespace Bubble.Library.Extension
{
    /// <summary>
    /// Json相关扩展
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        ///     转换指定的类型到Json字符串
        /// </summary>
        /// <returns></returns>
        public static string ToJsonString(this object obj, bool camelCase = false, bool indented = false, bool unicodeEncoder = false)
        {
            return JsonSerializer.Serialize(obj, GetJsonSerializerOptions(camelCase, indented, unicodeEncoder));
        }

        /// <summary>
        ///     转换指定的类型到Json字符串
        /// </summary>
        /// <returns></returns>
        public static string ToJsonString(this object obj, Type inputType, bool camelCase = false, bool indented = false, bool unicodeEncoder = false)
        {
            return JsonSerializer.Serialize(obj, inputType, GetJsonSerializerOptions(camelCase, indented, unicodeEncoder));
        }

        private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreReadOnlyProperties = true
        };

        private static JsonSerializerOptions GetJsonSerializerOptions(bool camelCase = false, bool indented = false, bool unicodeEncoder = false)
        {
            if (!camelCase && !indented && !unicodeEncoder)
            {
                return DefaultJsonSerializerOptions;
            }

            var options = new JsonSerializerOptions();

            if (camelCase)
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            if (indented) options.WriteIndented = true;

            options.Encoder = unicodeEncoder ? JavaScriptEncoder.Default : JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.IgnoreReadOnlyProperties = true;
            return options;
        }

        /// <summary>
        ///     使用默认的<see cref="JsonSerializerOptions" />返回反序列化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? FromJsonString<T>(this string value) where T : class
        {
            return value.FromJsonString<T>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        /// <summary>
        ///     使用自定义的<see cref="JsonSerializerOptions" />返回反序列化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T? FromJsonString<T>(this string? value, JsonSerializerOptions settings) where T : class
        {
            return value != null
                ? JsonSerializer.Deserialize<T>(value, settings)
                : default;
        }

        /// <summary>
        ///     使用自定义的<see cref="JsonSerializerOptions" />返回指定类型的反序列化的对象
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static object? FromJsonString(this string? value, Type type, JsonSerializerOptions settings)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return value != null
                ? JsonSerializer.Deserialize(value, type, settings)
                : null;
        }
    }
}
