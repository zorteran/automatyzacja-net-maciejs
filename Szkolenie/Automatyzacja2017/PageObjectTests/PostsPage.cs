using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PageObjectTests
{
    internal class PostsPage
    {
        private const string NewPostText = "Add New";
        private Browser browser;

        public PostsPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        internal  void ClickNewPost()
        {
            var newPostButton = browser.FindByXpath($"//a[contains(text(), '{NewPostText}')]").First();
            newPostButton.Click();
        }

        internal  void ClickPostByTitle(string title)
        {
            var post = FindPostByTitle(title).First();
            post.Click();
        }

        internal  bool CheckIfPostExists(string title)
        {
            return (FindPostByTitle(title).Count > 0);
        }

        private  ReadOnlyCollection<IWebElement> FindPostByTitle(string title)
        {
            return browser.FindByXpath($"//a[contains(text(), '{title}')]");
        }
    }
}