using OpenQA.Selenium;
using System;

namespace PageObjectTests
{
    internal class AdminPage
    {
        private const string AdminPageUrl = "https://autotestdotnet.wordpress.com/wp-admin/";
        private const string UsernameInputId = "usernameOrEmail";
        private const string PasswordInputId = "password";

        private Browser browser;

        public AdminPage(IWebDriver driver)
        {
            browser = new Browser(driver);
        }

        internal  void GoTo()
        {
            browser.NavigateTo(AdminPageUrl);

        }
        
        internal  void LogIn(string login, string password)
        {
            var loginInput = browser.FindById(UsernameInputId);
            var passwordInput = browser.FindById(PasswordInputId);
            var loginButton = browser.FindByClass("login__form-action");

            loginInput.Click();
            loginInput.SendKeys(login);
            passwordInput.Click();
            passwordInput.SendKeys(password);
            loginButton.Click();
        }
    }
}