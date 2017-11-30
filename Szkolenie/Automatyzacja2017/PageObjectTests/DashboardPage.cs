using OpenQA.Selenium;
using System;
using System.Linq;

namespace PageObjectTests
{
    internal class DashboardPage
    {
        private const string PostsMenuItemText = "Posts";
        private const string DashboardText = "Dashboard";

        private Browser browser;

        public DashboardPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        internal  void ClickPostsMenuItem()
        {
            var postsMenuItem = browser.FindByXpath($"//div[contains(text(), '{PostsMenuItemText}')]").First();
            postsMenuItem.Click();
        }

        internal  void WaitForPageToLoad()
        {
            browser.WaitForAppear(By.XPath($"//h1[contains(text(), '{DashboardText}')]"));
        }
    }
}