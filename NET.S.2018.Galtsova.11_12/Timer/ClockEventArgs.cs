using System;

namespace Timer
{
    /// <summary>
    /// Represents clock event arguments.
    /// </summary>
    public class ClockEventArgs
    {
        /// <summary>
        /// Date of event.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Time interval in milliseconds.
        /// </summary>
        public int IntervalInMilliseconds { get; set; }
    }
}
