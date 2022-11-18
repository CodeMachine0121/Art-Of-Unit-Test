namespace ArtOfUnitTest;

[TestFixture]
public class LogAnalyzerTests
{
    private LogAnalyzer? _logAnalyzer;

    [SetUp]
    public void SetUp()
    {
        _logAnalyzer = new LogAnalyzer();
    }

    [TestCase("filewithbadextension.foo", false)]
    [TestCase("filewithgoodextension.slf", true)]
    [TestCase("filewithgoodextension.SLF", true)]
    public void IsValidLogFileName_GoodExtension_ReturnsTrue(string fileName, bool expected)
    {
        var result = _logAnalyzer.IsValidLogFileName(fileName);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void IsValidFillName_EmptyFileName_ThrowsException()
    {
        var result = Assert.Throws<ArgumentException>(() => _logAnalyzer.IsValidLogFileName(""));
        Assert.AreEqual("filename has to be provided", result.Message);
    }
    [TearDown]
    public void TearDown()
    {
        _logAnalyzer = null;
    }
}