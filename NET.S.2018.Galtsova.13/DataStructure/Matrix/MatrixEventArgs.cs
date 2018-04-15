using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class MatrixEventArgs<T>
    {
        public int I { get; set; }

        public int J { get; set; }

        public T OldValue { get; set; }

        public T NewValue { get; set; }
    }
}
