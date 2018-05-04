using System;

namespace Task5.Solution
{
    public class BoldText : DocumentPart
    {
        public override string Convert(IConverter converter)
        {
            return converter.Convert(this);
        }
    }
}