using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PageObjectTests
{
    internal class PostsPage
    {
        private const string NewPostText = "Add New";

        internal static void ClickNewPost()
        {
            var newPostButton = Browser.FindByXpath($"//a[contains(text(), '{NewPostText}')]").First();
            newPostButton.Click();
        }

        internal static void ClickPostByTitle(string title)
        {
            var post = FindPostByTitle(title).First();
            post.Click();
        }

        internal static bool CheckIfPostExists(string title)
        {
            return (FindPostByTitle(title).Count > 0);
        }

        private static ReadOnlyCollection<IWebElement> FindPostByTitle(string title)
        {
            return Browser.FindByXpath($"//a[contains(text(), '{title}')]");
        }
    }
}