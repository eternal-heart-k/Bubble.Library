using System;

namespace Bubble.Library.Timing
{
    public class ClockOptions
    {
        public DateTimeKind Kind { get; set; }

        public ClockOptions() => this.Kind = DateTimeKind.Unspecified;
    }
}
