using System;
using Bubble.Library.Foundation.Dto.Common;

namespace Bubble.Library.Foundation.Attribute
{
    /// <summary>
    ///     用于对Controller层面的Action不对返回值自动附加<see cref="ApiResult"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class NotWarpApiResultAttribute : System.Attribute
    {
    }
}
