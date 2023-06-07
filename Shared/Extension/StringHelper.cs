﻿using System;

namespace Bubble.Library.Shared.Extension
{
    public static class StringHelper
    {
        /// <summary>
        /// 生成一个新的Guid字符串
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetNewGuid(string format = null)
        {
            return Guid.NewGuid().ToString(format);
        }
    }
}
