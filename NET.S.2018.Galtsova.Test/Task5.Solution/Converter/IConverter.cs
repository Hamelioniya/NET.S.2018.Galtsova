﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public interface IConverter
    {
        string Convert(PlainText text);

        string Convert(Hyperlink link);

        string Convert(BoldText text);
    }
}
