using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

		public DraftsPage NavigateToDrafts()
		{
			DraftsLink.Click();
			//Thread.Sleep(2000);
			return new DraftsPage();
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
