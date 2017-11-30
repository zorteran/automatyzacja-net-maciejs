using OpenQA.Selenium;

namespace PageObjectTests
{
    internal class FirstNote
    {
        private const string CommentTextAreaId = "comment";
        private const string EmailInputId = "email";
        private const string AuthorInputId = "author";
        private const string SendButtonId = "comment-submit";
        private const string CommentReplyLinkClassname = "comment-reply-link";

        private Browser browser;

        public FirstNote(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Treść komentarza</param>
        /// <param name="email">Adres email</param>
        /// <param name="author">Autor</param>
        internal  void AddComment(string text, string email, string author)
        {
            EnterCommentText(text);
            EnterEmail(email);
            EnterAuthor(author);
            ClickSend();
        }

        private  void ClickSend()
        {
            var button = browser.FindById(SendButtonId);
            button.Click();
        }

        private  void EnterAuthor(string author)
        {
            //var nameLabel = browser.FindByXpath("//label[@for='author']").First();
            //nameLabel.Click();
            //browser.WaitForInvisible("//label[@for='author']");
            //Thread.Sleep(5000);


            var authorInput = browser.FindById(AuthorInputId);
            authorInput.Clear();
            authorInput.Click();
            authorInput.SendKeys(author);
        }

        internal  void ClickFirstReplyButton()
        {
            browser.WaitForAppear(By.ClassName(CommentReplyLinkClassname));
            IWebElement replyButton = browser.FindByClass(CommentReplyLinkClassname);
            replyButton.Click();

            browser.WaitForInvisible(By.Id(CommentTextAreaId));
        }

        private  void EnterEmail(string email)
        {
            var emailInput = browser.FindById(EmailInputId);
            emailInput.Clear();
            emailInput.Click();
            emailInput.SendKeys(email);
        }

        private  void EnterCommentText(string text)
        {
            var commentTextArea = browser.FindById(CommentTextAreaId);
            commentTextArea.Clear();
            commentTextArea.Click();
            commentTextArea.SendKeys(text);
        }


    }
}