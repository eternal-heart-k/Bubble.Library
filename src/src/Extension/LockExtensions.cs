﻿using System;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// 锁相关的扩展方法
    /// </summary>
    public static class LockExtensions
    {
        /// <summary>
        /// 执行加锁
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void Locking(this object source, Action action)
        {
            lock (source)
            {
                action();
            }
        }

        /// <summary>
        /// 执行加锁
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void Locking<T>(this T source, Action<T> action) where T : class
        {
            lock (source)
            {
                action(source);
            }
        }

        /// <summary>
        /// 执行加锁
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult Locking<TResult>(this object source, Func<TResult> func)
        {
            lock (source)
            {
                return func();
            }
        }

        /// <summary>
        /// 执行加锁
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult Locking<T, TResult>(this T source, Func<T, TResult> func) where T : class
        {
            lock (source)
            {
                return func(source);
            }
        }
    }
}
