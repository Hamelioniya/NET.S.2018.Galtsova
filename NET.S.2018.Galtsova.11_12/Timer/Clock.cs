using System;
using System.Threading;

namespace Timer
{
    /// <summary>
    /// Represents a clock with a countdown.
    /// </summary>
    public class Clock
    {
        #region Private const fields

        private const int MillisecInSec = 1000;

        #endregion !Private const fields.

        #region Private fields

        private int _interval;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="Clock"/>.
        /// </summary>
        public Clock()
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="Clock"/> with the passed time interval.
        /// </summary>
        /// <param name="interval">A time interval.</param>
        public Clock(int interval)
        {
            Interval = interval;
        }

        #endregion !Public constructor.

        #region Event

        public event EventHandler<ClockEventArgs> TimeElapsed;

        #endregion !Event.

        #region Public properties

        /// <summary>
        /// Time interval.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the passed interval less than or equal to 0.
        /// </exception>
        public int Interval
        {
            private get
            {
                return _interval;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Interval must be greater than 0.", nameof(Interval));
                }

                _interval = value * MillisecInSec;
            }
        }

        #endregion !Public properties.

        #region Public methods

        /// <summary>
        /// Starts clock and after the end of time calls an event.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <see cref="Clock.Interval"/> less than or equal to 0.
        /// </exception>
        public void Start()
        {
            if (Interval <= 0)
            {
                throw new ArgumentOutOfRangeException("Interval must be greater than null.", nameof(Interval));
            }

            Thread.Sleep(Interval);

            ClockEventArgs eventArgs = new ClockEventArgs() { Date = DateTime.Now, IntervalInMilliseconds = Interval };

            OnTimeElapsed(eventArgs);
        }

        #endregion !Public methods.

        #region Protected methods

        /// <summary>
        /// Invokes a delegate when time elapsed.
        /// </summary>
        /// <param name="e">Arguments of event.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <see cref="Clock.TimeElapsed"/> equal to null.
        /// </exception>
        protected virtual void OnTimeElapsed(ClockEventArgs e)
        {
            if (ReferenceEquals(TimeElapsed, null))
            {
                throw new ArgumentNullException(nameof(TimeElapsed));
            }

            TimeElapsed(this, e);
        }

        #endregion !Protected methods.
    }
}
