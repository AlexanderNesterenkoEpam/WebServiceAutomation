using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestWebProject.webdriver;

namespace TestWebProject.forms
{
	public class SentMailPage : BasePage
	{
		private static readonly By _sentMailTable = By.XPath(".//*[@class='AO']");

		public SentMailPage() : base(_sentMailTable)
		{
			PageFactory.InitElements(Browser.GetDriver(), this);
		}

		[FindsBy(How = How.XPath, Using = ".//*[@gh='tl']//tr[@jsmodel]")]
		private IList<IWebElement> SentEmailsList;

		public SentMailPage GetNumberOfSentEmails(out int currentNumberOfDrafts)
		{
			currentNumberOfDrafts = SentEmailsList.Count();
			return this;
		}

		public bool CheckEmailPresentsInSentEmails(int numberOfSentEmails)
		{
			return ((SentEmailsList.Count - 1) == numberOfSentEmails);
		}
	}
}
