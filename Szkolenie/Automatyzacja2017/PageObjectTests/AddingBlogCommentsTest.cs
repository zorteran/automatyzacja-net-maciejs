using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PageObjectTests
{
    public class AddingBlogCommentsTest :IDisposable
    {

        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            string commentText = "To jest testowy komentarz" + DateTime.Now;
            string email = "m@sz.pl";
            string authorText = "msz";


            MainPage.GoTo();
            MainPage.OpenFirstNote();
            FirstNote.AddComment(commentText, email, authorText);
            var result = CommentPage.FindComment(commentText);
            Assert.True(result);
        }

        public void Dispose()
        {
            try
            {
                Browser.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
