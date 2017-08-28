using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebProject.Enums;
using TestWebProject.forms;
using TestWebProject.webdriver;
using TestWebProject.Entities;

namespace TestWebProject
{
	[TestClass]
	public class Tests : BaseTest
	{
		public User GetUserFromTestContext()
		{
			var userEmail = TestContext.DataRow["email"].ToString();
			var userPassword = TestContext.DataRow["pass"].ToString();

			return new User(userEmail, userPassword);
		}

		public Email GetEmailFromTestContext()
		{
			var emailTo = TestContext.DataRow["emailTo"].ToString();
			var emailSubject = TestContext.DataRow["subject"].ToString();
			var emailBody = TestContext.DataRow["body"].ToString();

			return new Email(emailTo, emailSubject, emailBody);
		}

		#region Tests


		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Resources\TestData.csv",
		"TestData#csv", DataAccessMethod.Sequential)]
		[TestMethod, TestCategory("Smoke")]
		public void TestLogin()
		{
			var user = GetUserFromTestContext();
 
			// Act
			bool isLoginCorrect = new LoginPage().LogIn(user)
				.IsOnPage(Pages.Inbox);

			// Assert
			Assert.IsTrue(isLoginCorrect);
		}

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Resources\TestData.csv",
		"TestData#csv", DataAccessMethod.Sequential)]
		[TestMethod, TestCategory("Smoke")]
		public void EmailPresentsInDraftFolder()
		{
			// Arrange
			int numberOfDrafts;
			var user = GetUserFromTestContext();
			var email = GetEmailFromTestContext();


			// Act
			bool isEmailPresentInDrafts = new LoginPage()
				.LogIn(user)
				.NavigateToDrafts()
				.GetNumberOfDrafts(out numberOfDrafts)
				.OpenComposeEmailDialog()
				.FillEmailFields(email)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.CheckEmailPresentsInDraft(numberOfDrafts);

			new DraftsPage().DiscardAllDrafts();

			// Assert
			Assert.IsTrue(isEmailPresentInDrafts);
		}

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Resources\TestData.csv",
		"TestData#csv", DataAccessMethod.Sequential)]
		[TestMethod, TestCategory("Smoke")]
		public void EmailFillingIsCorrect()
		{
			// Arrange 
			var user = GetUserFromTestContext();
			var email = GetEmailFromTestContext();

			// Act
			bool isEmailFillingCorrect = new LoginPage()
				.LogIn(user)
				.OpenComposeEmailDialog()
				.FillEmailFields(email)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.OpenFirstDraft()
				.CheckEmailFilling(email);

			new DraftsPage().DiscardAllDrafts();

			// Assert
			Assert.IsTrue(isEmailFillingCorrect);
		}

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Resources\TestData.csv",
		"TestData#csv", DataAccessMethod.Sequential)]
		[TestMethod, TestCategory("Smoke")]
		public void EmailDissapearedFromDraftsAfterSending()
		{
			// Arrange
			int numberOfDrafts;
			var user = GetUserFromTestContext();
			var email = GetEmailFromTestContext();

			// Act
			bool isEmailDisappearedFromDrafts = new LoginPage()
				.LogIn(user)
				.OpenComposeEmailDialog()
				.FillEmailFields(email)
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

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Resources\TestData.csv",
		"TestData#csv", DataAccessMethod.Sequential)]
		[TestMethod, TestCategory("Smoke")]
		public void EmailAppearInSentMailForlderAfterSending()
		{
			// Arrange
			int numberOfSentEmails;
			var user = GetUserFromTestContext();
			var email = GetEmailFromTestContext();

			// Act
			bool emailAppearInSentEmails = new LoginPage()
				.LogIn(user)
				.NavigateToSentMail()
				.GetNumberOfSentEmails(out numberOfSentEmails)
				.OpenComposeEmailDialog()
				.FillEmailFields(email)
				.CloseComposeDialogWindow()
				.NavigateToDrafts()
				.OpenFirstDraft()
				.SendEmail()
				.NavigateToSentMail()
				.CheckEmailPresentsInSentEmails(numberOfSentEmails);

			// Assert
			Assert.IsTrue(emailAppearInSentEmails);
		}

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Resources\TestData.csv",
		"TestData#csv", DataAccessMethod.Sequential)]
		[TestMethod, TestCategory("Smoke")]
		public void DeleteEmailUsingContextMenu()
		{
			// Arrange
			int numberOfSentEmails;
			var user = GetUserFromTestContext();
			var email = GetEmailFromTestContext();

			// Act
			bool isEmailDeleted = new LoginPage()
				.LogIn(user)
				.OpenComposeEmailDialog()
				.FillEmailFields(email)
				.SendEmailUsingKeys()
				.NavigateToSentMail()
				.GetNumberOfSentEmails(out numberOfSentEmails)
				.DeleteSentEmailFromListByContextMenu()
				.AcceptDeleteSentEmailDialog()
				.CheckEmailDissapearAfterDeleting(numberOfSentEmails);

			// Assert
			Assert.IsTrue(isEmailDeleted);
		}

		#endregion Tests
	}
}
