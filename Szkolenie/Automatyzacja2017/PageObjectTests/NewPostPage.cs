using OpenQA.Selenium;
using System;

namespace PageObjectTests
{
    internal class NewPostPage
    {
        private  string postPageUrl = "";
        private const string LogoutButtonText = "Sign Out";

        private Browser browser;

        public NewPostPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        internal  bool CheckIfNewPostExists(string title, string content)
        {
            var titleElement = browser.FindByXpath($"//h1[contains(text(), '{title}')]");
            var contentElement = browser.FindByXpath($"//p[contains(text(), '{content}')]");
            return (titleElement.Count > 0 && contentElement.Count > 0);
        }

        internal  void Logout()
        {
            var avatarIcon = browser.FindById("wp-admin-bar-my-account");
            avatarIcon.Click();


            var logoutButton = browser.FindByClass("ab-sign-out");
            waitForLogoutButtonToAppear();
            logoutButton.Click();
        }

        private  void waitForLogoutButtonToAppear()
        {
            browser.WaitForAppear(By.XPath($"//button[contains(text(), '{LogoutButtonText}')]"));
        }

        internal  void SetNewUrl(string SetNewUrl)
        {
            postPageUrl = SetNewUrl;
        }

        internal  void GoTo()
        {
            browser.NavigateTo(postPageUrl);
        }
    }
}