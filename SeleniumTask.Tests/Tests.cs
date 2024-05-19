using NUnit.Framework;
using System.Linq;

namespace SeleniumTask.Tests
{
    [TestFixture]
    public class Tests : BaseSeleniumTest
    {

        [Test]
        public void CandidateTest_Postitive()
        {
            SeleniumExecutor executor = new SeleniumExecutor(webDriver);

            executor.FillAllFields();
            executor.ClickLogin();

            var text = executor.GetLoggedInText();
            Assert.AreEqual(SeleniumExecutorExtension.GetTextToAssert_Positive(), text);
        }

        [Test]
        public void CandidateTest_Negative()
        {
            SeleniumExecutor executor = new SeleniumExecutor(webDriver);

            executor.ClickLogin();

            var text = executor.GetLoggedInText();
            Assert.AreEqual(SeleniumExecutorExtension.GetTextToAssert_Negative(), text);
        }
    }
}