using System;

namespace Bubble.Library.Timing
{
    /// <summary>
    /// 时钟参数选项
    /// </summary>
    public class ClockOptions
    {
        /// <summary>
        /// 时钟类型
        /// </summary>
        public DateTimeKind Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClockOptions() => this.Kind = DateTimeKind.Unspecified;
    }
}
