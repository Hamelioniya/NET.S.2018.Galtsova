using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using NLog;

namespace BLL.Repositories
{
    /// <summary>
    /// Provides logging methods.
    /// </summary>
    public class NLogger : BLL.Interface.Interfaces.ILogger
    {
        private NLog.Logger _logger;

        #region Public constructor

        /// <summary>
        /// Initializes an instance of the <see cref="NLogger"/> with the passed type of logger.
        /// </summary>
        /// <param name="type">The type of class that use log.</param>
        public NLogger(Type type)
        {
            if (ReferenceEquals(type, null))
            {
                throw new ArgumentNullException(nameof(type));
            }

            this._logger = LogManager.GetLogger(type.Name);
        }

        #endregion !Public constructor.

        #region ILogger implements

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        public void Debug(string message)
        {
           this._logger.Debug(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        public void Debug(Exception exception, string message)
        {
            this._logger.Debug(exception, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        public void Error(string message)
        {
            this._logger.Error(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        public void Error(Exception exception, string message)
        {
            this._logger.Error(exception, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        public void Fatal(string message)
        {
            this._logger.Fatal(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        public void Fatal(Exception exception, string message)
        {
            this._logger.Fatal(exception, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        public void Info(string message)
        {
            this._logger.Info(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        public void Info(Exception exception, string message)
        {
            this._logger.Info(exception, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        public void Trace(string message)
        {
            this._logger.Trace(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        public void Trace(Exception exception, string message)
        {
            this._logger.Trace(exception, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">The description of the problem.</param>
        public void Warn(string message)
        {
            this._logger.Warn(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The description of the problem.</param>
        public void Warn(Exception exception, string message)
        {
            this._logger.Warn(exception, message);
        }

        #endregion !ILogger implements.
    }
}
