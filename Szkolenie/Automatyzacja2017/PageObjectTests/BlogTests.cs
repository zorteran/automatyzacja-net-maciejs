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
            FirstNote.AddComment(commentText, email, authorText);
            

            //MainPage.GoTo();
            //MainPage.OpenFirstNote();
            FirstNote.ClickFirstReplyButton();
            

            FirstNote.AddComment(commentText, email, authorText);
            var result = CommentPage.FindComment(commentText);
            Assert.True(result);
        }
        [Fact]
        public void AddPostFromAdminPage()
        {
            LogIn();

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

        private static void LogIn()
        {
            AdminPage.GoTo();
            AdminPage.LogIn(login, password);
        }

        [Fact]
        public void AddPostAndCommentItAsGuest()
        {
            LogIn();

            DashboardPage.WaitForPageToLoad();
            DashboardPage.ClickPostsMenuItem();

            PostsPage.ClickNewPost();

            AddPostPage.WaitForPageToLoad();

            string title = "msz" + DateTime.Now;
            string content = "To jest testowy post" + DateTime.Now;
            AddPostPage.FillPostContent(title, content);
            AddPostPage.PublishPost();

            AddPostPage.ClickPostLink();

            bool result1 = NewPostPage.CheckIfNewPostExists(title, content);

            Assert.True(result1);

            NewPostPage.Logout();
            NewPostPage.GoTo();

            FillCommentData(out commentText, out email, out authorText);

            FirstNote.AddComment(commentText, email, authorText);
            bool result2 = CommentPage.FindComment(commentText);
            Assert.True(result2);
        }

        [Fact]
        public void AddPostAndCommentItAsGuestAndDeleteIt()
        {
            string title = "msz" + DateTime.Now;
            string content = "To jest testowy post" + DateTime.Now;

            // ADD
            LogIn();
            DashboardPage.WaitForPageToLoad();
            DashboardPage.ClickPostsMenuItem();

            PostsPage.ClickNewPost();

            bool newPostExists = AddPost(title, content);

            Assert.True(newPostExists);

            // COMMENT
            NewPostPage.Logout();
            NewPostPage.GoTo();

            FillCommentData(out commentText, out email, out authorText);

            FirstNote.AddComment(commentText, email, authorText);
            bool commentIsFound = CommentPage.FindComment(commentText);
            Assert.True(commentIsFound);

            //DELETE
            LogIn();
            DashboardPage.WaitForPageToLoad();
            DashboardPage.ClickPostsMenuItem();
            PostsPage.ClickPostByTitle(title);
            EditPostPage.DeletePost();

            // ASSERT
            var postIsDeletedMessage = EditPostPage.CheckIfPostIsDeleted();
            Assert.True(postIsDeletedMessage);

            DashboardPage.ClickPostsMenuItem();
            var postExists = PostsPage.CheckIfPostExists(title);
            Assert.False(postExists);

        }

        private static bool AddPost(string title, string content)
        {
            AddPostPage.WaitForPageToLoad();

            AddPostPage.FillPostContent(title, content);
            AddPostPage.PublishPost();

            AddPostPage.ClickPostLink();

            bool newPostExists = NewPostPage.CheckIfNewPostExists(title, content);
            return newPostExists;
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
