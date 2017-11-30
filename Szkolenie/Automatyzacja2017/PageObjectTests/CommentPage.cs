using System;
using Xunit;

namespace PageObjectTests
{
    internal class CommentPage
    {
        internal static bool FindComment(string text)
        {
            var comments = Browser.FindCommentByText(text);
            return (comments.Count > 0);
        }
    }
}