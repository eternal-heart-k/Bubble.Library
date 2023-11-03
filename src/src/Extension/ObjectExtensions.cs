using System;
using System.Globalization;
using System.Linq;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// Object
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 类型转换：obj => class T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T As<T>(this object obj) where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// 类型转换：obj => struct T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T To<T>(this object obj) where T : struct
        {
            return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 判断item是否在list中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this T item, params object[] list)
        {
            return list.Contains(item);
        }
    }
}
