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
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        //private bool acceptNextAlert = true;

        public Example()

        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://www.google.pl/";

            verificationErrors = new StringBuilder();

        }



        [Fact]

        public void TheExampleTest()

        {

            driver.Navigate().GoToUrl(baseURL + "");

            driver.FindElement(By.Id("lst-ib")).Clear();
            driver.FindElement(By.Id("lst-ib")).SendKeys("codesprinters");
            driver.FindElement(By.Id("lst-ib")).Submit();
            driver.FindElement(By.LinkText("Code Sprinters -")).Click();
            var element = driver.FindElement(By.LinkText("Poznaj nasze podejście"));
            //Assert.Equal("Code Sprinters -", driver.Title);
            Assert.NotNull(element);
            var elements = driver.FindElements(By.LinkText("Poznaj nasze podejście"));
            Assert.Single(elements);

            var popup = driver.FindElement(By.Id("cookie_action_close_header"));
            popup.Click();

            wait(By.Id("cookie_action_close_header"), driver);
            //waitForElementPresent(element, 5, driver);
            Thread.Sleep(2000);
            element.Click();

            var d = driver.Title;

            Assert.Equal("Nasze podejście - Code Sprinters", driver.Title);
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

        void wait(By by , IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(by));
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