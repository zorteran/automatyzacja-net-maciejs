using OpenQA.Selenium;

namespace PageObjectTests
{
    internal class CommentPage
    {

        private Browser browser;

        public CommentPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        internal bool FindComment(string text)
        {
            var comments = browser.FindCommentByText(text);
            return (comments.Count > 0);
        }
    }
}