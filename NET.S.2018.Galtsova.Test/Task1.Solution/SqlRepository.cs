using System;
using System.Collections.Generic;

namespace Task1.Solution
{
    public class SqlRepository : IRepository
    {
        List<string> _passwords;

        public SqlRepository()
        {
            _passwords = new List<string>();
        }

        public void Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password must not be empry or equal to null.", nameof(password));
            }

            _passwords.Add(password);
        }
    }
}
