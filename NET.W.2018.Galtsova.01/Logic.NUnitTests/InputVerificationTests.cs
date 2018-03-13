using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class InputVerificationTests
    {
        [Test]
        public void InputVerification_ArgumentNullExceptionTests()
        {
            Assert.Throws<ArgumentNullException>(() => InputVerification.VerifyInputCorrect(null));
        }

        [Test]
        public void InputVerification_ArgumentOutOfRangeExceptionTests()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => InputVerification.VerifyInputCorrect(new int[0]));
        }
    }
}
