using KTPO4311.Ishgulov.Lib.LogAn;
using NUnit.Framework.Legacy;

namespace KTPO4311.Ishgulov.UnitTest.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.That(result,  Is.False);
        }
        
        
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new();
            bool result = analyzer.IsValidLogFileName("file.ISHGULOV");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new();
            bool result = analyzer.IsValidLogFileName("file.ishgulov");
            Assert.That(result, Is.True);
        }
        
        [TestCase("filewithgoodextension.ISHGULOV")]
        [TestCase("filewithgoodextension.ishgulov")]
        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new();
            bool result = analyzer.IsValidLogFileName(file);
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void IsValidLogFileName_emptyFileName_Throws()
        {
            LogAnalyzer analyzer = new();

            var ex = Assert.Catch<ArgumentException>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("Имя файла не может быть пустым", ex.Message);
        }
        
        [TestCase("file.ISHGULOV", true)]
        [TestCase("file.txt", false)]
        public void IsValidLogFileName_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer analyzer = new();
            analyzer.IsValidLogFileName(fileName);

           Assert.That(analyzer.WasLastFileNameValid, Is.EqualTo(expected));
        }
    }
}