namespace Task5.Solution
{
    public class PlainTextConverter : IConverter
    {
        public string Convert(BoldText boldText)
        {
            return "**" + boldText.Text + "**";
        }

        public string Convert(Hyperlink hyperlink)
        {
            return hyperlink.Text + " [" + hyperlink.Url + "]";
        }

        public string Convert(PlainText plainText)
        {
            return plainText.Text;
        }
    }
}
