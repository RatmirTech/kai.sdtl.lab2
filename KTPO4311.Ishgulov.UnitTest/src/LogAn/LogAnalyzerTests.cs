using NUnit.Framework;
using KTPO4311.Ishgulov.Lib.LogAn;

namespace KTPO4311.Ishgulov.UnitTest.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            var fakeMgr = new FakeExtensionManager { WillReturn = true };
            ExtensionManagerFactory.SetManager(fakeMgr);

            var analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("file.ishgulov");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidFileName_NameUnsupportedExtension_ReturnsFalse()
        {
            var fakeMgr = new FakeExtensionManager { WillReturn = false };
            ExtensionManagerFactory.SetManager(fakeMgr);

            var analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("file.txt");
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            var fakeMgr = new FakeExtensionManager 
            { 
                WillThrow = new Exception("Ошибка при проверке расширения") 
            };
            ExtensionManagerFactory.SetManager(fakeMgr);

            var analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("file.ishgulov");
            Assert.That(result, Is.False);
        }

        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
        }
    }

    /// <summary>
    /// Поддельный менеджер расширений
    /// </summary>
    public class FakeExtensionManager : IExtensionManager
    {
        public bool WillReturn { get; set; } = true;
        public Exception WillThrow { get; set; }

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
                throw WillThrow;

            return WillReturn;
        }
    }
}