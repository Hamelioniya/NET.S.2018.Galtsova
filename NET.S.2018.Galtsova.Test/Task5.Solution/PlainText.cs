using System;

namespace Task5.Solution
{
    public class PlainText : DocumentPart
    {
        public override string Convert(IConverter converter)
        {
            return converter.Convert(this);
        }
    }
}
