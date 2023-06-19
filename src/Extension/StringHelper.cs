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
        public static string GetNewGuid(string? format) => Guid.NewGuid().ToString(format);

        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value);
    }
}
