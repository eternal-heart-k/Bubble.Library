using System;
using Bubble.Library.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bubble.Library.Timing
{
    /// <summary>
    /// 时钟
    /// </summary>
    public class Clock : IClock, ITransientDependency
    {
        private ClockOptions Options { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public Clock(IOptions<ClockOptions> options) => this.Options = options.Value;

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime Now => this.Options.Kind != DateTimeKind.Utc ? DateTime.Now : DateTime.UtcNow;

        /// <summary>
        /// 时钟类型
        /// </summary>
        public DateTimeKind Kind => this.Options.Kind;
    }
}
