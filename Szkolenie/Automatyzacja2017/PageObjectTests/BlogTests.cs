using System;
using System.Threading;
using Xunit;

namespace PageObjectTests
{
    public class BlogTests :IDisposable
    {
        string commentText, email, authorText;
        private const string login = "autotestdotnet@gmail.com";
        private const string password = "P@ssw0rd1";

        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            FillCommentData(out commentText, out email, out authorText);

            MainPage.GoTo();
            MainPage.OpenFirstNote();
            FirstNote.AddComment(commentText, email, authorText);
            var result = CommentPage.FindComment(commentText);
            Assert.True(result);
        }


        [Fact]
        public void CanAddCommentToTheComment()
        {
            FillCommentData(out commentText, out email, out authorText);


            MainPage.GoTo();
            MainPage.OpenFirstNote();
            FirstNote.ClickFirstReplyButton();

            FirstNote.AddComment(commentText, email, authorText);
            var result = CommentPage.FindComment(commentText);
            Assert.True(result);
        }
        [Fact]
        public void AddPostFromAdminPage()
        {
            AdminPage.GoTo();
            AdminPage.LogIn(login,password);

            DashboardPage.WaitForPageToLoad();
            DashboardPage.ClickPostsMenuItem();

            PostsPage.ClickNewPost();

            AddPostPage.WaitForPageToLoad();

            string title = "msz" + DateTime.Now;
            string content = "To jest testowy post" + DateTime.Now;
            AddPostPage.FillPostContent(title, content);
            AddPostPage.PublishPost();

            AddPostPage.ClickPostLink();

            bool result = NewPostPage.CheckIfNewPostExists(title, content);

            Assert.True(result);
            
        }

        private static void FillCommentData(out string commentText, out string email, out string authorText)
        {
            commentText = "To jest testowy komentarz" + DateTime.Now;
            email = "m@sz.pl";
            authorText = "msz";
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
