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
    public class Example : IDisposable

    {
        private const string SearchTextBoxId = "lst-ib";
        private const string GoogleUrl = "https://www.google.pl/";
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        //private bool acceptNextAlert = true;

        public Example()

        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            verificationErrors = new StringBuilder();

        }



        [Fact]
        public void TheExampleTest()
        {
            GoToGoogle();

            SearchInGoogle("codesprinters");
            ClickEntryByText("Code Sprinters -");

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

        [Fact]
        public void PacktPubTest()
        {
            driver.Navigate().GoToUrl("http://packtpub.com");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);
            var popup = driver.FindElement(By.ClassName("login-popup"));
            
            popup.Click();
            //driver.Manage().Window.Position = new System.Drawing.Point(0, 0);

            //driver.FindElement(By.Id("packt-user-login-form")).Clear();
            //driver.FindElement(By.Id("email")).SendKeys("codesprinters");
            var emailElement = driver.FindElement(By.Name("email"));
            var passElement = driver.FindElement(By.Id("password"));
            Actions action = new Actions(driver);
            action.Click(emailElement);
            emailElement.SendKeys("codesprinters");
            //action.SendKeys("zorteran@gmail.com");
            //
            ////waitForElementPresent(emailElement, 20, driver);
            ////emailElement.Click();
            //
            //var 
            ////passElement.Click();
            //passElement.SendKeys("codesprinters");
            driver.FindElement(By.Id("packt-user-login-form")).Submit();

            string d = "dd";
            d.ToUpper();
        }

        private void WaitUntilPopupInvisible(By by , IWebDriver driver, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"),"Akceptuję"));
        }

        //protected void waitForElementPresent(By by, int seconds, IWebDriver _driver)

        //{

        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));

        //    wait.Until(ExpectedConditions.ElementToBeClickable(by));

        //}



        //protected void waitForElementPresent(IWebElement by, int seconds, IWebDriver _driver)

        //{

        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));

        //    wait.Until(ExpectedConditions.ElementToBeClickable(by));

        //}

        //private bool IsElementPresent(By by)

        //{

        //    try

        //    {

        //        driver.FindElement(by);

        //        return true;

        //    }

        //    catch (NoSuchElementException)

        //    {

        //        return false;

        //    }

        //}



        //private bool IsAlertPresent()

        //{

        //    try

        //    {

        //        driver.SwitchTo().Alert();

        //        return true;

        //    }

        //    catch (NoAlertPresentException)

        //    {

        //        return false;

        //    }

        //}



        //private string CloseAlertAndGetItsText()

        //{

        //    try

        //    {

        //        IAlert alert = driver.SwitchTo().Alert();

        //        string alertText = alert.Text;

        //        if (acceptNextAlert)

        //        {

        //            alert.Accept();

        //        }

        //        else

        //        {

        //            alert.Dismiss();

        //        }

        //        return alertText;

        //    }

        //    finally

        //    {

        //        acceptNextAlert = true;

        //    }

        //}



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