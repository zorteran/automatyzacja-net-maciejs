using OpenQA.Selenium;
using System;

namespace PageObjectTests
{
    internal class NewPostPage
    {
        private static string postPageUrl = "";
        private const string LogoutButtonText = "Sign Out";

        internal static bool CheckIfNewPostExists(string title, string content)
        {
            var titleElement = Browser.FindByXpath($"//h1[contains(text(), '{title}')]");
            var contentElement = Browser.FindByXpath($"//p[contains(text(), '{content}')]");
            return (titleElement.Count > 0 && contentElement.Count > 0);
        }

        internal static void Logout()
        {
            var avatarIcon = Browser.FindById("wp-admin-bar-my-account");
            avatarIcon.Click();


            var logoutButton = Browser.FindByClass("ab-sign-out");
            waitForLogoutButtonToAppear();
            logoutButton.Click();
        }

        private static void waitForLogoutButtonToAppear()
        {
            Browser.WaitForAppear(By.XPath($"//button[contains(text(), '{LogoutButtonText}')]"));
        }

        internal static void SetNewUrl(string SetNewUrl)
        {
            postPageUrl = SetNewUrl;
        }

        internal static void GoTo()
        {
            Browser.NavigateTo(postPageUrl);
        }
    }
}