using OpenQA.Selenium;
using System;
using System.Linq;

namespace PageObjectTests
{
    internal class AddPostPage
    {
        private const string AddNewPostHeaderText = "Add New Post";
        private const string TitleInputId = "title";
        private const string TextButtonId = "content-html";
        private const string PostTextAreaId = "content";
        private const string EditButtonText = "Edit";
        private const string PublishButtonId = "publish";
        private const string ViewPostLinkText = "View post";

        private Browser browser;

        public AddPostPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }


        internal  void WaitForPageToLoad()
        {
            browser.WaitForAppear(By.XPath($"//h1[contains(text(), '{AddNewPostHeaderText}')]"));
        }

        internal  void PublishPost()
        {
            var publishButton = browser.FindById(PublishButtonId);
            WaitForEditButton();
            publishButton.Click();
        }

        private  void WaitForEditButton()
        {
            browser.WaitForAppear(By.XPath($"//button[contains(text(), '{EditButtonText}')]"));
        }

        internal  void FillPostContent(string title, string content)
        {
            var titleInput = browser.FindById(TitleInputId);
            var textButton = browser.FindById(TextButtonId);
            var postTextArea = browser.FindById(PostTextAreaId);

            titleInput.Click();
            titleInput.SendKeys(title);

            textButton.Click();

            postTextArea.Click();
            postTextArea.SendKeys(content);

        }

        internal  void ClickPostLink(NewPostPage newPostPage)
        {
            string xpath = $"//a[contains(text(), '{ViewPostLinkText}')]";
            WaitForPostLinkToAppear(xpath);
            var newPostLink = browser.FindByXpath(xpath).First();
            newPostLink.Click();
            newPostPage.SetNewUrl(browser.GetCurrentUrl());
        }

        private  void WaitForPostLinkToAppear(string xpath)
        {
            browser.WaitForAppear(By.XPath(xpath));
        }
    }
}