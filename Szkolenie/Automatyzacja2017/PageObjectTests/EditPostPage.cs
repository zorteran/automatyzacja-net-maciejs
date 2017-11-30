using OpenQA.Selenium;
using System;
using System.Linq;

namespace PageObjectTests
{
    internal class EditPostPage
    {
        private const string DeletePostLinkText = "Move to Trash";
        private const string DeletedPostMessageText = "1 post moved to the Trash";

        private Browser browser;

        public EditPostPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        internal  void DeletePost()
        {
            var deletePostLink = browser.FindByXpath($"//a[contains(text(), '{DeletePostLinkText}')]").First();
            deletePostLink.Click();
        }

        internal  bool CheckIfPostIsDeleted()
        {
            return (browser.FindByXpath($"//p[contains(text(), '{DeletedPostMessageText}')]").Count > 0);
        }
    }
}