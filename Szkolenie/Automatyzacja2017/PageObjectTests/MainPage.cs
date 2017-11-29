using System;
using System.Linq;
using System.Threading;

namespace PageObjectTests
{
    internal class MainPage
    {
        private const string url = "https://autotestdotnet.wordpress.com";
        internal static void GoTo()
        {
            Browser.NavigateTo(url);
            
        }

        internal static void OpenFirstNote()
        {
            var articles = Browser.FindByXpath("//article/header");
            articles.First().Click();
        }
    }
}