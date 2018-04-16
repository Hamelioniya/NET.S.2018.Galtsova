using System;

namespace DataStructure.Tests
{
    public class Book : IComparable<Book>, IComparable
    {
        private string _author;
        private string _name;

        public Book(string name, string author)
        {
            Author = author;
            Name = name;
        }

        #region Public properties

        public string Author
        {
            get
            {
                return _author;
            }

            private set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(Author));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("The book author must not be empty.", nameof(Author));
                }

                _author = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            private set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(Name));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("The book name must not be empty.", nameof(Name));
                }

                _name = value;
            }
        }

        #endregion !Public properties.

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException(nameof(other));
            }

            return this.Name.CompareTo(other.Name);
        }

        public int CompareTo(object other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (this.GetType() != other.GetType())
            {
                throw new ArgumentException("Types of parameters for compare must be equal.", nameof(other));
            }

            return this.CompareTo((Book)other);
        }
    }
}
