using NUnit.Framework;
using Moq;
using System;

namespace Pronitor.UnitTests
{
    [TestFixture]
    public class RouterTests
    {

        // CallUI and CallConsole will be covered in integration tests, since it calls external componenets
        
        [TestCase(new object[] { "String", "Integer", "Integer" })]
        [TestCase(new object[] { "procsses", "2", "@" })]
        public void Main_InvalidThreeArguments_ThrowFormatException(params string[] args)
        {
            Assert.Throws<FormatException>(() => Router.Main(args));
        }

        [TestCase(new object[] { "s", "c" })]
        [TestCase(new object[] { "Any Arguments size other than zero and three" })]
        public void Main_WrongArgumentsPassed_ThrowMissingFieldException(params string[] args)
        {
            Assert.Throws<MissingFieldException>(() => Router.Main(args));
        }
    }
}