using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Tests
{
    public class Handler
    {
        private string _result;

        public string Result
        {
            get
            {
                return _result;
            }
        }

        public void Message<T>(object sender, MatrixEventArgs<T> e)
        {
            _result = string.Format("The element of the matrix was changed!\nRow index: {0}\nColumn index: {1}\nOld value: {2}\nNew value: {3}", e.I, e.J,
                e.OldValue, e.NewValue);
        }
    }
}
