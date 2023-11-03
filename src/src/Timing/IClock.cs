using System;

namespace Bubble.Library.Timing
{
    /// <summary>
    /// 时钟接口
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// 时钟类型
        /// </summary>
        DateTimeKind Kind { get; }
    }
}
