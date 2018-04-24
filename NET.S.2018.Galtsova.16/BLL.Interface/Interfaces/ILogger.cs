using System;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides logging interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        void Debug(Exception exception, string message);

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        void Debug(string message);

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        void Error(Exception exception, string message);

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        void Error(string message);

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        void Fatal(Exception exception, string message);

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        void Fatal(string message);

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        void Info(Exception exception, string message);

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        void Info(string message);

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        void Trace(Exception exception, string message);

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        void Trace(string message);

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        void Warn(Exception exception, string message);

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        void Warn(string message);
    }
}
