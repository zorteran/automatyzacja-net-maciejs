using OpenQA.Selenium;
using System;
using System.Linq;

namespace PageObjectTests
{
    internal class DashboardPage
    {
        private const string PostsMenuItemText = "Posts";
        private const string DashboardText = "Dashboard";
        internal static void ClickPostsMenuItem()
        {
            var postsMenuItem = Browser.FindByXpath($"//div[contains(text(), '{PostsMenuItemText}')]").First();
            postsMenuItem.Click();
        }

        internal static void WaitForPageToLoad()
        {
            Browser.WaitForAppear(By.XPath($"//h1[contains(text(), '{DashboardText}')]"));
        }
    }
}