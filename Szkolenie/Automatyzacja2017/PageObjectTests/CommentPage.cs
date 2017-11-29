using System;
using Xunit;

namespace PageObjectTests
{
    internal class CommentPage
    {
        internal static bool FindComment(string v)
        {
            var comments = Browser.FindByText(v);
            return (comments.Count > 0);
        }
    }
}