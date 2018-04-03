using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BookStore.Tests
{
    [TestFixture]
    public class BookTests
    {
        private Book book = new Book("978-5-9985-0715-1", "Vladimir Nabokov", "Lolita", "Olympia Press", 1955, 480, 10);

        [TestCase("AT", ExpectedResult = "Author: Vladimir Nabokov\nName: Lolita")]
        [TestCase("ATH", ExpectedResult = "Author: Vladimir Nabokov\nName: Lolita\nPublishing house: Olympia Press")]
        [TestCase("ATHY", ExpectedResult = "Author: Vladimir Nabokov\nName: Lolita\nPublishing house: Olympia Press\nPublishing year: 1955")]
        [TestCase("IATHYN", ExpectedResult = "ISBN: 978-5-9985-0715-1\nAuthor: Vladimir Nabokov\nName: Lolita\nPublishing house: Olympia Press\nPublishing year: 1955\nNumber of pages: 480")]
        [TestCase("IATHYNP", ExpectedResult = "ISBN: 978-5-9985-0715-1\nAuthor: Vladimir Nabokov\nName: Lolita\nPublishing house: Olympia Press\nPublishing year: 1955\nNumber of pages: 480\nPrice: 10,00 \u20BD")]
        public string ToString_GetStringInFormatTests(string format)
        {
            return this.book.ToString(format);
        }

        [TestCase("IATHYNP", ExpectedResult = "ISBN: 978-5-9985-0715-1\nAuthor: Vladimir Nabokov\nName: Lolita\nPublishing house: Olympia Press\nPublishing year: 1955\nNumber of pages: 480\nPrice: 10,00 \u20BD")]
        public string ToString_GetStringTests(string format)
        {
            return this.book.ToString(format);
        }
    }
}
