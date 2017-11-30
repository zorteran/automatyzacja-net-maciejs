using System;
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
    }
}