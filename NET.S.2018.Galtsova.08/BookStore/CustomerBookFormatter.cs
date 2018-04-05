using System;
using System.Globalization;

namespace BookStore
{
    /// <summary>
    /// Represents a custom book formatter.
    /// </summary>
    public class CustomerBookFormatter : IFormatProvider, ICustomFormatter
    {
        #region ICustomFormatter implementation

        /// <summary>
        /// Gets a string representation of the <paramref name="arg"/> in <paramref name="format"/>
        /// using <paramref name="formatProvider"/>.
        /// </summary>
        /// <param name="format">A format of string.</param>
        /// <param name="arg">An object to convert to string.</param>
        /// <param name="formatProvider">A format provider.</param>
        /// <exception cref="FormatException">
        /// Thrown when <paramref name="format"/> is incorrect.
        /// </exception>
        /// <returns>A string representation of the <paramref name="arg"/> in passed format.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == string.Empty)
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException exception)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", exception);
                }
            }

            Book book = arg as Book;

            if (ReferenceEquals(book, null))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException exception)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", exception);
                }
            }

            switch (format.ToUpper())
            {
                case "IATP":
                    {
                        return "ISBN: " + book.ISBN + "\nAuthor: " + book.Author + "\nName: " + book.Name + "\nPrice: " + book.Price.ToString("c", CultureInfo.CurrentCulture);
                    }

                default:
                    {
                        try
                        {
                            return HandleOtherFormats(format, arg);
                        }
                        catch (FormatException exception)
                        {
                            throw new FormatException($"The format of '{format}' is invalid.", exception);
                        }
                    }
            }
        }

        #endregion !ICustomFormatter implementation.

        #region IFormatProvider implementation

        /// <summary>
        /// Gets an object type of custom formatter.
        /// </summary>
        /// <param name="formatType">A type of formatter.</param>
        /// <returns>An object type of custom formatter.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        #endregion !IFormatProvider implementation.

        #region Private methods

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else
            {
                if (!ReferenceEquals(arg, null))
                {
                    return arg.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #endregion !Private methods.
    }
}
