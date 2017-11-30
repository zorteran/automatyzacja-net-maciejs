using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObjectTests
{
    internal class Browser
    {
        private  IWebDriver _driver;

        internal  IWebElement FindById(string id)
        {
            return _driver.FindElement(By.Id(id));
        }

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }
        

        internal  void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }



        internal  ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return _driver.FindElements(By.XPath(xpath));
        }

        internal  void Close()
        {
            _driver.Quit();
        }

        internal  ReadOnlyCollection<IWebElement> FindCommentByText(string text)
        {
            return _driver.FindElements(By.XPath($"//p[contains(text(), '{text}')]"));
        }

        internal  void WaitForInvisible(string xpath)
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

        }
        internal  void WaitForInvisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        internal  void WaitForAppear(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(by));
        }

        internal  string GetCurrentUrl()
        {
            return _driver.Url;
        }

        internal  IWebElement FindByClass(string classname)
        {
            return _driver.FindElement(By.ClassName(classname));
        }
    }
}