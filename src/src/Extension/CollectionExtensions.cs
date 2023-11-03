using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// Collection扩展
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 是否为空的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection is null || collection.Count <= 0;
        }

        /// <summary>
        /// 不存在则添加并返回true，否则返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool AddIfNotContains<T>([NotNull] this ICollection<T> collection, T item)
        {
            CheckHelper.NotNull(collection, nameof(collection));

            if (collection.Contains(item))
            {
                return false;
            }

            collection.Add(item);
            return true;
        }

        /// <summary>
        /// 对于列表中不存在的则添加
        /// 返回添加的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> AddIfNotContains<T>([NotNull] this ICollection<T> collection, IEnumerable<T> items)
        {
            CheckHelper.NotNull(collection, nameof(collection));

            var addedItems = new List<T>();
            foreach (var item in items)
            {
                if (collection.Contains(item))
                {
                    continue;
                }

                addedItems.Add(item);
                collection.Add(item);
            }

            return addedItems;
        }

        /// <summary>
        /// 不存在则添加并返回true，否则返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <param name="itemFactory"></param>
        /// <returns></returns>
        public static bool AddIfNotContains<T>([NotNull] this ICollection<T> collection,
            [NotNull] Func<T, bool> predicate, [NotNull] Func<T> itemFactory)
        {
            CheckHelper.NotNull(collection, nameof(collection));
            CheckHelper.NotNull(predicate, nameof(predicate));
            CheckHelper.NotNull(itemFactory, nameof(itemFactory));

            if (collection.Any(predicate))
            {
                return false;
            }

            collection.Add(itemFactory());
            return true;
        }

        /// <summary>
        /// 移除包含的所有元素，并返回需要移除的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IList<T> RemoveAll<T>([NotNull] this IList<T> collection, Func<T, bool> predicate)
        {
            var items = collection.Where(predicate).ToList();

            foreach (var item in items)
            {
                collection.Remove(item);
            }

            return items;
        }

        /// <summary>
        /// 移除包含的所有元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        public static void RemoveAll<T>([NotNull] this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Remove(item);
            }
        }
    }
}
