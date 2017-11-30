using System;
using System.Linq;

namespace PageObjectTests
{
    internal class EditPostPage
    {
        private const string DeletePostLinkText = "Move to Trash";
        private const string DeletedPostMessageText = "1 post moved to the Trash";

        internal static void DeletePost()
        {
            var deletePostLink = Browser.FindByXpath($"//a[contains(text(), '{DeletePostLinkText}')]").First();
            deletePostLink.Click();
        }

        internal static bool CheckIfPostIsDeleted()
        {
            return (Browser.FindByXpath($"//p[contains(text(), '{DeletedPostMessageText}')]").Count > 0);
        }
    }
}