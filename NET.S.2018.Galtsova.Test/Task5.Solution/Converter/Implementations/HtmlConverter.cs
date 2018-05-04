namespace Task5.Solution
{
    public class HtmlConverter : IConverter
    {
        public string Convert(BoldText boldText)
        {
            return "<b>" + boldText.Text + "</b>";
        }

        public string Convert(Hyperlink hyperlink)
        {
            return "<a href=\"" + hyperlink.Url + "\">" + hyperlink.Text + "</a>";
        }

        public string Convert(PlainText plainText)
        {
            return plainText.Text;
        }
    }
}
