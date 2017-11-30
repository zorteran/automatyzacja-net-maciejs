using System;

namespace PageObjectTests
{
    internal class AdminPage
    {
        private const string AdminPageUrl = "https://autotestdotnet.wordpress.com/wp-admin/";
        private const string UsernameInputId = "usernameOrEmail";
        private const string PasswordInputId = "password";

        internal static void GoTo()
        {
            Browser.NavigateTo(AdminPageUrl);

        }
        
        internal static void LogIn(string login, string password)
        {
            var loginInput = Browser.FindById(UsernameInputId);
            var passwordInput = Browser.FindById(PasswordInputId);
            var loginButton = Browser.FindByClass("login__form-action");

            loginInput.Click();
            loginInput.SendKeys(login);
            passwordInput.Click();
            passwordInput.SendKeys(password);
            loginButton.Click();
        }
    }
}