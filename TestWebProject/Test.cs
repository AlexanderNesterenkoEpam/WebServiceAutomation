using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebProject.Enums;
using TestWebProject.forms;
using TestWebProject.Helpers;
using TestWebProject.webdriver;

namespace TestWebProject
{
	[TestClass]
	public class Test : BaseTest
	{
		private readonly string email = "mentoringqa2017@gmail.com";
		private readonly string password = "mentoring2017";
		private readonly string emailTo = Helper.GetRandomEmail(3);
		private readonly string emailSubject = Helper.GetRandomString();
		private readonly string emailBody = Helper.GetRandomString();


		[TestMethod, TestCategory("Smoke")]
		public void TestLogin()
		{
			// Act
			bool isLoginCorrect = new LoginForm().InputLogin(email, password)
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
				.InputLogin(email, password)
				.NavigateToDrafts()
				.GetNumberOfDrafts(out numberOfDrafts)
				.OpenComposeEmailDialog()
				.FillEmailFields(emailTo, emailSubject, emailBody)
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
				.InputLogin(email, password)
				.OpenComposeEmailDialog()
				.FillEmailFields(emailTo, emailSubject, emailBody)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.OpenFirstDraft()
				.CheckEmailFilling(emailTo, emailSubject, emailBody);

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
				.InputLogin(email, password)
				.OpenComposeEmailDialog()
				.FillEmailFields(emailTo, emailSubject, emailBody)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.GetNumberOfDrafts(out numberOfDrafts)
				.OpenFirstDraft()
				.SendEmail()
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
				.InputLogin(email, password)
				.NavigateToSentMail()
				.GetNumberOfSentEmails(out numberOfSentEmails)
				.OpenComposeEmailDialog()
				.FillEmailFields(emailTo, emailSubject, emailBody)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.OpenFirstDraft()
				.SendEmail()
				.NavigateToSentMail()
				.CheckEmailPresentsInSentEmails(numberOfSentEmails);

			// Assert
			Assert.IsTrue(emailAppearInSentEmails);
		}
	}
}
