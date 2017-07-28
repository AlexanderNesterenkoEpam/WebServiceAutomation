using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.webdriver;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestWebProject.pages;
using TestWebProject.WebdriverConfiguration;

namespace TestWebProject.forms
{
	public class SentMailPage : BasePage
	{
		private static readonly By _sentMailTable = By.XPath(".//*[@class='AO']//*[@role ='main']");
		
		public SentMailPage() : base(_sentMailTable)
		{
			PageFactory.InitElements(Browser.GetDriver(), this);
		}

		[FindsBy(How = How.XPath, Using = ".//*[@gh='tl']//tr[@jsmodel]")]
		private IList<IWebElement> SentEmailsList;

		[FindsBy(How = How.XPath, Using = ".//*[@role ='menu']/div[7]")]
		private IWebElement ContextMenuItemDelete;


		public SentMailPage GetNumberOfSentEmails(out int currentNumberOfSentEmail)
		{
			//isMailSentMessageAppear();
			currentNumberOfSentEmail = SentEmailsList.Count();
			return this;
		}

	
		public bool CheckEmailPresentsInSentEmails(int numberOfSentEmails)
		{
			return ((SentEmailsList.Count - 1) == numberOfSentEmails);
		}

		public bool CheckEmailDissapearAfterDeleting(int numberOfSentEmails)
		{
			return ((SentEmailsList.Count + 1) == numberOfSentEmails);
		}

		public DeleteSentEmailDialogPage DeleteSentEmailFromListByContextMenu()
		{
			new Actions(Browser.GetDriver()).ContextClick(SentEmailsList.First()).Build().Perform();

			ContextMenuItemDelete.Click();

			return new DeleteSentEmailDialogPage();
		}
	}
}
