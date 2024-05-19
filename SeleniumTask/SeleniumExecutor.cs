using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTask
{
    public class SeleniumExecutor
    {
        private IWebDriver webDriver;

        public SeleniumExecutor(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void ClickLogin()
        {
            throw new NotImplementedException("Implement this");
        }
        public void FillAllFields()
        {
            throw new NotImplementedException("Implement this");
        }

        public string GetLoggedInText()
        {
            //"Implement this"
            return null;
        }

    }
}
