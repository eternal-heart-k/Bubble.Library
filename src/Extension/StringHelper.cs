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
    }
}
