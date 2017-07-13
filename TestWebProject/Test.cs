using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TestWebProject.Enums;
using TestWebProject.forms;
using TestWebProject.Helpers;
using TestWebProject.webdriver;

namespace TestWebProject
{
	[TestClass]
	public class Test : BaseTest
	{
		private readonly string _email = "mentoringqa2017@gmail.com";
		private readonly string _password = "mentoring2017";
		private readonly string _emailTo = "Hello@mail.ru";
		private readonly string _emailSubject = Helper.GetRandomString();
		private readonly string _emailBody = "HI";


		[TestMethod, TestCategory("Smoke")]
		public void TestLogin()
		{
			// Act
			bool isLoginCorrect = new LoginForm().InputLogin(_email, _password)
				.inOnPage(Pages.Inbox);

			// Assert
			Assert.IsTrue(isLoginCorrect);
		}

		[TestMethod, TestCategory("Smoke")]
		public void EmailPresentsInDraftFolder()
		{
			// Arrange
			int numberOfDrafts;

			// Act
			bool isEmailPresentInDrafts = new LoginForm()
				.InputLogin(_email, _password)
				.NavigateToDrafts()
				.GetNumberOfDrafts(out numberOfDrafts)
				.OpenComposeEmailDialog()
				.FillEmailFields(_emailTo, _emailSubject, _emailBody)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.CheckEmailPresentsInDraft(numberOfDrafts);

			// Assert
			Assert.IsTrue(isEmailPresentInDrafts);
		}

		[TestMethod, TestCategory("Smoke")]
		public void EmailFillingIsCorrect()
		{
			// Act
			bool isEmailFillingCorrect = new LoginForm()
				.InputLogin(_email, _password)
				.OpenComposeEmailDialog()
				.FillEmailFields(_emailTo, _emailSubject, _emailBody)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.OpenFirstDraft()
				.CheckEmailFilling(_emailTo, _emailSubject, _emailBody);

			// Assert
			Assert.IsTrue(isEmailFillingCorrect);
		}

		[TestMethod, TestCategory("Smoke")]
		public void EmailDissapearedFromDraftsAfterSending()
		{
			// Arrange
			int numberOfDrafts;

			// Act
			bool isEmailDisappearedFromDrafts = new LoginForm()
				.InputLogin(_email, _password)
				.OpenComposeEmailDialog()
				.FillEmailFields(_emailTo, _emailSubject, _emailBody)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.GetNumberOfDrafts(out numberOfDrafts)
				.OpenFirstDraft()
				.SendEmailUsingKeys()
				.NavigateToDrafts()
				.CheckEmailDisappearedFromDrafts(numberOfDrafts);

			// Assert
			Assert.IsTrue(isEmailDisappearedFromDrafts);
		}

		[TestMethod, TestCategory("Smoke")]
		public void EmailAppearInSentMailForlderAfterSending()
		{
			// Arrange
			int numberOfSentEmails;

			// Act
			bool emailAppearInSentEmails = new LoginForm()
				.InputLogin(_email, _password)
				.NavigateToSentMail()
				.GetNumberOfSentEmails(out numberOfSentEmails)
				.OpenComposeEmailDialog()
				.FillEmailFields(_emailTo, _emailSubject, _emailBody)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.OpenFirstDraft()
				.SendEmail()
				.NavigateToSentMail()
				.CheckEmailPresentsInSentEmails(numberOfSentEmails);

			// Assert
			Assert.IsTrue(emailAppearInSentEmails);
		}

		[TestMethod, TestCategory("Smoke")]
		public void DeleteEmailUsingContextMenu()
		{
			// Arrange
			int numberOfSentEmails;

			// Act
			bool isEmailDeleted = new LoginForm()
				.InputLogin(_email, _password)
				.OpenComposeEmailDialog()
				.FillEmailFields(_emailTo, _emailSubject, _emailBody)
				.SendEmailUsingKeys()
				.NavigateToSentMail()
				.GetNumberOfSentEmails(out numberOfSentEmails)
				.DeleteSentEmailFromListByContextMenu()
				.AcceptDeleteSentEmailDialog()
				.CheckEmailDissapearAfterDeleting(numberOfSentEmails);

			// Assert
			Assert.IsTrue(isEmailDeleted);
		}
	}
}
