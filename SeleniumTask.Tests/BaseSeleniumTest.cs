using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace SeleniumTask.Tests
{
    public abstract class BaseSeleniumTest
    {
        protected IWebDriver webDriver;
        private WireMockServer Server;
        public string Port;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            CreateWireMockServer(TestContext.CurrentContext.TestDirectory + $@"{Path.DirectorySeparatorChar}resources{Path.DirectorySeparatorChar}__files");
            CreateWebDriver();
        }

        [SetUp]
        public void SetUp()
        {
            webDriver.Navigate().GoToUrl($"http://localhost:{Port}/index.html");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            webDriver?.Quit();
            Server?.Stop();
        }

        private void CreateWireMockServer(string pathToFiles)
        {
            Server = WireMockServer.Start();
            Port = Server.Ports.First().ToString();
            foreach (var file in Directory.GetFiles(pathToFiles))
            {
                Server
                  .Given(Request.Create().WithPath($"/{Path.GetFileName(file)}").UsingAnyMethod())
                  .RespondWith(
                  Response.Create()
                  .WithBodyFromFile(file));
            }
        }

        private void CreateWebDriver()
        {
            var chromeOpts = new ChromeOptions();
			chromeOpts.AddArguments("--no-sandbox");
			chromeOpts.AddArguments("--disable-dev-shm-usage");
            chromeOpts.AddArguments("--headless");
            webDriver = new ChromeDriver(".", chromeOpts);
        }
    }
}
