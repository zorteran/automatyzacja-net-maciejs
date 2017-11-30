using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
        private IWebDriver _driver;

        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            IWebDriver driver = OpenBrowser();
            MainPage mainPage = new MainPage(driver);
            FirstNote firstNote = new FirstNote(driver);
            CommentPage commentPage = new CommentPage(driver);

            FillCommentData(out commentText, out email, out authorText);
            
            mainPage.GoTo();
            mainPage.OpenFirstNote();
            firstNote.AddComment(commentText, email, authorText);
            var result = commentPage.FindComment(commentText);
            Assert.True(result);
        }



        [Fact]
        public void CanAddCommentToTheComment()
        {
            IWebDriver driver = OpenBrowser();
            MainPage mainPage = new MainPage(driver);
            FirstNote firstNote = new FirstNote(driver);
            CommentPage commentPage = new CommentPage(driver);

            FillCommentData(out commentText, out email, out authorText);

            mainPage.GoTo();
            mainPage.OpenFirstNote();
            firstNote.AddComment(commentText, email, authorText);
            
            firstNote.ClickFirstReplyButton();

            firstNote.AddComment(commentText, email, authorText);
            var result = commentPage.FindComment(commentText);
            Assert.True(result);
        }

        [Fact]
        public void AddPostFromAdminPage()
        {
            IWebDriver driver = OpenBrowser();
            DashboardPage dashboardPage = new DashboardPage(driver);
            AddPostPage addPostPage = new AddPostPage(driver);
            PostsPage postsPage = new PostsPage(driver);
            NewPostPage newPostPage = new NewPostPage(driver);
            AdminPage adminPage = new AdminPage(driver);

            LogIn(adminPage);

            dashboardPage.WaitForPageToLoad();
            dashboardPage.ClickPostsMenuItem();

            postsPage.ClickNewPost();

            addPostPage.WaitForPageToLoad();

            string title = "msz" + DateTime.Now;
            string content = "To jest testowy post" + DateTime.Now;
            addPostPage.FillPostContent(title, content);
            addPostPage.PublishPost();

            addPostPage.ClickPostLink(newPostPage);

            bool result = newPostPage.CheckIfNewPostExists(title, content);

            Assert.True(result);

        }

        [Fact]
        public void AddPostAndCommentItAsGuest()
        {
            IWebDriver driver = OpenBrowser();
            DashboardPage dashboardPage = new DashboardPage(driver);
            AddPostPage addPostPage = new AddPostPage(driver);
            PostsPage postsPage = new PostsPage(driver);
            NewPostPage newPostPage = new NewPostPage(driver);
            FirstNote firstNote = new FirstNote(driver);
            CommentPage commentPage = new CommentPage(driver);
            AdminPage adminPage = new AdminPage(driver);

            LogIn(adminPage);

            dashboardPage.WaitForPageToLoad();
            dashboardPage.ClickPostsMenuItem();

            postsPage.ClickNewPost();

            addPostPage.WaitForPageToLoad();

            string title = "msz" + DateTime.Now;
            string content = "To jest testowy post" + DateTime.Now;
            addPostPage.FillPostContent(title, content);
            addPostPage.PublishPost();

            addPostPage.ClickPostLink(newPostPage);

            bool result1 = newPostPage.CheckIfNewPostExists(title, content);

            Assert.True(result1);

            newPostPage.Logout();
            newPostPage.GoTo();

            FillCommentData(out commentText, out email, out authorText);

            firstNote.AddComment(commentText, email, authorText);
            bool result2 = commentPage.FindComment(commentText);
            Assert.True(result2);
        }

        [Fact]
        public void AddPostAndCommentItAsGuestAndDeleteIt()
        {
            IWebDriver driver = OpenBrowser();
            DashboardPage dashboardPage = new DashboardPage(driver);
            AddPostPage addPostPage = new AddPostPage(driver);
            PostsPage postsPage = new PostsPage(driver);
            NewPostPage newPostPage = new NewPostPage(driver);
            FirstNote firstNote = new FirstNote(driver);
            CommentPage commentPage = new CommentPage(driver);
            EditPostPage editPostPage = new EditPostPage(driver);
            AdminPage adminPage = new AdminPage(driver);

            string title = "msz" + DateTime.Now;
            string content = "To jest testowy post" + DateTime.Now;

            // ADD
            LogIn(adminPage);
            dashboardPage.WaitForPageToLoad();
            dashboardPage.ClickPostsMenuItem();

            postsPage.ClickNewPost();

            addPostPage.WaitForPageToLoad();

            addPostPage.FillPostContent(title, content);
            addPostPage.PublishPost();

            addPostPage.ClickPostLink(newPostPage);

            bool newPostExists = newPostPage.CheckIfNewPostExists(title, content);

            Assert.True(newPostExists);

            // COMMENT
            newPostPage.Logout();
            newPostPage.GoTo();

            FillCommentData(out commentText, out email, out authorText);

            firstNote.AddComment(commentText, email, authorText);
            bool commentIsFound = commentPage.FindComment(commentText);
            Assert.True(commentIsFound);

            //DELETE
            LogIn(adminPage);
            dashboardPage.WaitForPageToLoad();
            dashboardPage.ClickPostsMenuItem();
            postsPage.ClickPostByTitle(title);
            editPostPage.DeletePost();

            // ASSERT
            var postIsDeletedMessage = editPostPage.CheckIfPostIsDeleted();
            Assert.True(postIsDeletedMessage);

            dashboardPage.ClickPostsMenuItem();
            var postExists = postsPage.CheckIfPostExists(title);
            Assert.False(postExists);

        }

        private static void LogIn(AdminPage adminPage)
        {
            adminPage.GoTo();
            adminPage.LogIn(login, password);
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
                _driver.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IWebDriver OpenBrowser()
        {
            var browser = new FirefoxDriver();
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            _driver = browser;
            return browser;
        }

    }
}
