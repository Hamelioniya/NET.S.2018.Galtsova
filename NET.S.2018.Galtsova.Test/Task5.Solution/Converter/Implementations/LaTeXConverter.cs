namespace Task5.Solution
{
    public class LaTeXConverter : IConverter
    {
        public string Convert(BoldText boldText)
        {
            return "\\textbf{" + boldText.Text + "}";
        }

        public string Convert(Hyperlink hyperlink)
        {
            return "\\href{" + hyperlink.Url + "}{" + hyperlink.Text + "}";
        }

        public string Convert(PlainText planeText)
        {
            return planeText.Text;
        }
    }
}
