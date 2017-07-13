using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.forms;
using TestWebProject.webdriver;

namespace TestWebProject.pages
{
	public class DeleteSentEmailDialogPage : AbstractPage
	{
		private static readonly By titleLocator = By.XPath(".//*[@role='alertdialog']");

		public DeleteSentEmailDialogPage() : base(titleLocator)
		{
			PageFactory.InitElements(Browser.GetDriver(), this);
		}

		[FindsBy(How = How.XPath, Using = "	//*[@name='ok']")]
		private IWebElement Ok;
	

	

		public SentMailPage AcceptDeleteSentEmailDialog()
		{
			 Ok.Click();

			return new SentMailPage();
		}
	}
}
