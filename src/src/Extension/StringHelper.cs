using System;
using System.Diagnostics.CodeAnalysis;

#nullable enable
namespace Bubble.Library.Extension
{
    /// <summary>
    /// 字符串相关
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 生成一个新的Guid字符串
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetNewGuid(string? format = null) => Guid.NewGuid().ToString(format);

        /// <summary>
        /// 判断字符串是否为空或全是空格
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// 生成时间戳字符串
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GenerateTimeStamp(DateTime? time = null)
        {
            var timeStamp = (time ?? DateTime.Now) - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(timeStamp.TotalSeconds).ToString();
        }
    }
}
