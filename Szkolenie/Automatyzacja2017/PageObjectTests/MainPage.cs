using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace PageObjectTests
{
    internal class MainPage
    {
        private const string url = "https://autotestdotnet.wordpress.com";

        private Browser browser;

        public MainPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        internal  void GoTo()
        {
            browser.NavigateTo(url);
            
        }

        internal  void OpenFirstNote()
        {
            var articles = browser.FindByXpath("//article/header");
            articles.First().Click();
        }
    }
}