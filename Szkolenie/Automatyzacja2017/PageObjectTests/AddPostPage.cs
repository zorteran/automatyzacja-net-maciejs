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

        internal static void WaitForPageToLoad()
        {
            Browser.WaitForAppear(By.XPath($"//h1[contains(text(), '{AddNewPostHeaderText}')]"));
        }

        internal static void PublishPost()
        {
            var publishButton = Browser.FindById(PublishButtonId);
            WaitForEditButton();
            publishButton.Click();
        }

        private static void WaitForEditButton()
        {
            Browser.WaitForAppear(By.XPath($"//button[contains(text(), '{EditButtonText}')]"));
        }

        internal static void FillPostContent(string title, string content)
        {
            var titleInput = Browser.FindById(TitleInputId);
            var textButton = Browser.FindById(TextButtonId);
            var postTextArea = Browser.FindById(PostTextAreaId);

            titleInput.Click();
            titleInput.SendKeys(title);

            textButton.Click();

            postTextArea.Click();
            postTextArea.SendKeys(content);

        }

        internal static void ClickPostLink()
        {
            string xpath = $"//a[contains(text(), '{ViewPostLinkText}')]";
            WaitForPostLinkToAppear(xpath);
            var newPostLink = Browser.FindByXpath(xpath).First();
            newPostLink.Click();
            NewPostPage.SetNewUrl(Browser.GetCurrentUrl());
        }

        private static void WaitForPostLinkToAppear(string xpath)
        {
            Browser.WaitForAppear(By.XPath(xpath));
        }
    }
}