using System;

namespace PageObjectTests
{
    internal class NewPostPage
    {
        internal static bool CheckIfNewPostExists(string title, string content)
        {
            var titleElement = Browser.FindByXpath($"//h1[contains(text(), '{title}')]");
            var contentElement = Browser.FindByXpath($"//p[contains(text(), '{content}')]");
            return (titleElement.Count > 0 && contentElement.Count > 0);
        }
    }
}