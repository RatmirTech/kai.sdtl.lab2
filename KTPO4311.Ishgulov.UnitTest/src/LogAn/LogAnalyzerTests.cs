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
            var analyzer = new LogAnalyzer(fakeMgr);
            bool result = analyzer.IsValidLogFileName("file.ishgulov");
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void IsValidFileName_NameUnsupportedExtension_ReturnsFalse()
        {
            var fakeMgr = new FakeExtensionManager { WillReturn = false };
            var analyzer = new LogAnalyzer(fakeMgr);
            bool result = analyzer.IsValidLogFileName("file.txt");
            Assert.That(result, Is.False);
        }
    }
    
    /// <summary>
    /// поддельный менеджер расширений
    /// </summary>
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillReturn { get; set; } = true;

        public bool IsValid(string fileName)
        {
            return WillReturn;
        }
    }
}
