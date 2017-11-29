﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace PageObjectTests
{
    internal class FirstNote
    {
        private const string CommentTextAreaId = "comment";
        private const string EmailInputId = "email";
        private const string AuthorInputId = "author";
        private const string SendButtonId = "comment-submit";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Treść komentarza</param>
        /// <param name="email">Adres email</param>
        /// <param name="author">Autor</param>
        internal static void AddComment(string text, string email, string author)
        {
            EnterCommentText(text);
            EnterEmail(email);
            EnterAuthor(author);
            ClickSend();
        }

        private static void ClickSend()
        {
            var button = Browser.FindById(SendButtonId);
            button.Click();
        }

        private static void EnterAuthor(string author)
        {
            //var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            //nameLabel.Click();
            //Browser.WaitForInvisible("//label[@for='author']");
            //Thread.Sleep(5000);
            

            var authorInput = Browser.FindById(AuthorInputId);
            //authorInput.Click();
            authorInput.SendKeys(author);
        }

        private static void EnterEmail(string email)
        {
            var emailInput = Browser.FindById(EmailInputId);
            emailInput.Click();
            emailInput.SendKeys(email);
        }

        private static void EnterCommentText(string text)
        {
            var commentTextArea = Browser.FindById(CommentTextAreaId);
            commentTextArea.Click();
            commentTextArea.SendKeys(text);
        }


    }
}