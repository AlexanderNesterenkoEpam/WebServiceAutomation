using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestWebProject.webdriver;

namespace TestWebProject.forms
{
	public class BasePage : AbstractPage
	{
		public BasePage(By locator) : base(locator)
		{
			PageFactory.InitElements(Browser.GetDriver(), this);	
		}

		[FindsBy(How = How.XPath, Using = ".//*[@gh='cm']")]
		private IWebElement ComposeButon;

		[FindsBy(How = How.XPath, Using = ".//a[contains(@href, '#drafts')]")]
		private IWebElement DraftsLink;

		[FindsBy(How = How.XPath, Using = ".//a[contains(@href, '#sent')]")]
		private IWebElement SentMailLink;

		[FindsBy(How = How.XPath, Using = ".//*[@gh='tm']//*[@act='20' and @role='button']")]
		private IWebElement Refresh;

		public DraftsPage NavigateToDrafts()
		{
			DraftsLink.Click();
			Thread.Sleep(3000);
			return new DraftsPage();
		}

		public void WaitForDraftsListAppeared()
		{
			new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(3)).Until(
				ExpectedConditions.ElementIsVisible(By.XPath(".//*[@class='AO']//*[@role ='main']")));
		}


		public SentMailPage NavigateToSentMail()
		{
			SentMailLink.Click();

			return new SentMailPage();
		}

		public ComposeEmailDialogPage OpenComposeEmailDialog()
		{
			ComposeButon.Click();

			return new ComposeEmailDialogPage();
		}
	}
}
