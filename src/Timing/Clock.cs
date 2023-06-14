using System;
using Bubble.Library.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bubble.Library.Timing
{
    public class Clock : IClock, ITransientDependency
    {
        private ClockOptions Options { get; set; }

        public Clock(IOptions<ClockOptions> options) => this.Options = options.Value;

        public DateTime Now => this.Options.Kind != DateTimeKind.Utc ? DateTime.Now : DateTime.UtcNow;

        public DateTimeKind Kind => this.Options.Kind;
    }
}
