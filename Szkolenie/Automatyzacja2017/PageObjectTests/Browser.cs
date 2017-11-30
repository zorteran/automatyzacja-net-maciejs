using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObjectTests
{
    internal class Browser
    {
        private static IWebDriver _driver;

        internal static IWebElement FindById(string id)
        {
            return _driver.FindElement(By.Id(id));
        }

        static Browser()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }


        internal static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }



        internal static ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return _driver.FindElements(By.XPath(xpath));
        }

        internal static void Close()
        {
            _driver.Quit();
        }

        internal static ReadOnlyCollection<IWebElement> FindCommentByText(string text)
        {
            return _driver.FindElements(By.XPath($"//p[contains(text(), '{text}')]"));
        }

        internal static void WaitForInvisible(string xpath)
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

        }
        internal static void WaitForInvisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        internal static void WaitForAppear(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(by));
        }

        internal static IWebElement FindByClass(string classname)
        {
            return _driver.FindElement(By.ClassName(classname));
        }
    }
}