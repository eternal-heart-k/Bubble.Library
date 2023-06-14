using System;

namespace Bubble.Library.Timing
{
    public interface IClock
    {
        DateTime Now { get; }

        DateTimeKind Kind { get; }
    }
}
