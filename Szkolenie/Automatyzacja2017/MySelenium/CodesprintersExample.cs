using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace SeleniumTests

{
    public class CodesprintersExample : IDisposable

    {
        private const string SearchTextBoxId = "lst-ib";
        private const string GoogleUrl = "https://www.google.pl/";
        private const string CodeSprintersPageTitle = "Code Sprinters -";
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        //private bool acceptNextAlert = true;

        public CodesprintersExample()

        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            verificationErrors = new StringBuilder();

        }



        [Fact]
        public void Enter_codesprinters_page_and_click_button()
        {
            GoToGoogle();

            SearchInGoogle("codesprinters");
            ClickEntryByText(CodeSprintersPageTitle);

            IWebElement poznajNaszePodejscieButton = FindButtonByText("Poznaj nasze podejście");

            ClickCookieePopupById("cookie_action_close_header");

            poznajNaszePodejscieButton.Click();

            Assert.Equal("Nasze podejście - Code Sprinters", driver.Title);
        }

        private void GoToGoogle()
        {
            driver.Navigate().GoToUrl(GoogleUrl + "");
        }

        private void ClickCookieePopupById(string id)
        {
            var cookieeIdFilterBy = By.Id(id);
            var popup = driver.FindElement(cookieeIdFilterBy);
            popup.Click();
            WaitUntilPopupInvisible(cookieeIdFilterBy, driver, 11);
        }

        private IWebElement FindButtonByText(string text)
        {
            By textFilterBy = By.LinkText(text);
            var element = driver.FindElement(textFilterBy);
            var elements = driver.FindElements(textFilterBy);
            Assert.NotNull(element);
            Assert.Single(elements);
            return element;
        }

        private void ClickEntryByText(string text)
        {
            driver.FindElement(By.LinkText(text)).Click();
        }

        private void SearchInGoogle(string arg)
        {
            IWebElement googleSearchBox = GetGoogleSearchBox();
            googleSearchBox.Clear();
            googleSearchBox.SendKeys(arg);
            googleSearchBox.Submit();
        }

        private IWebElement GetGoogleSearchBox()
        {
            return driver.FindElement(By.Id(SearchTextBoxId));
        }

        private void WaitUntilPopupInvisible(By by , IWebDriver driver, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"),"Akceptuję"));
        }

      


        public void Dispose()

        {

            try

            {

                driver.Quit();

            }

            catch (Exception)

            {

                // Ignore errors if unable to close the browser

            }

            Assert.Equal("", verificationErrors.ToString());

        }

    }

}