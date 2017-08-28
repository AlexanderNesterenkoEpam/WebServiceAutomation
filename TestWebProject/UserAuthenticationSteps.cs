

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestWebProject.Entities;
using TestWebProject.Enums;
using TestWebProject.forms;
using TestWebProject.webdriver;
using TestWebProject.WebdriverConfiguration;

namespace TestWebProject
{

	[Binding]
	public class UserAuthenticationSteps : BaseTest
	{
		private LoginPage loginPage;

		[Given(@"User goes to start url")]
		public void GivenUserGoesToStartUrl()
		{
			Browser = Browser.Instance;
			Browser.WindowMaximise();
			Browser.NavigateTo(Configuration.StartUrl);
		}

		[Given(@"User navigate to the Login page")]
		public void GivenUserNavigateToTheLoginPage()
		{
			loginPage = new LoginPage();
		}

		[When(@"User input (.*) and (.*)")]
		public void WhenUserInputMentoringqaGmail_ComAndMentoring(string email, string password)
		{
			var user = new User(email, password);
			loginPage.LogIn(user);
		}

		[Then(@"User goes to the Inbox page")]
		public void ThenUserGoesToTheInboxPage()
		{
			var isOnInboxPage = new InboxPage().IsOnPage(Pages.Inbox);

			Assert.IsTrue(isOnInboxPage);
		}

	}
}




