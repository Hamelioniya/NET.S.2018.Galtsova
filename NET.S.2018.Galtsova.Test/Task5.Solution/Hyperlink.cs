using System;

namespace Task5.Solution
{
    public class Hyperlink : DocumentPart
    {
        public string Url { get; set; }

        public override string Convert(IConverter converter)
        {
            return converter.Convert(this);
        }
    }
}
