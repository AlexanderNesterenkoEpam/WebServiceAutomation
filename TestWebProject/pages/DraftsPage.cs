using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestWebProject.webdriver;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestWebProject.Enums;
using TestWebProject.Elements;
using TestWebProject.Webdriver;
using TestWebProject.WebdriverConfiguration;

namespace TestWebProject.forms
{
	public class DraftsPage : BasePage
	{
		private static readonly By _draftTable = By.XPath(".//*[@class='aeF']//*[@role = 'main']");

		public DraftsPage() : base(_draftTable)
		{
			PageFactory.InitElements(Browser.GetDriver(), this);
		}

		[FindsBy(How = How.XPath, Using = ".//*[@role='main']//tr[@jsmodel]")]
		private IList<IWebElement> DraftNotes;

		Checkbox SelectAllCheckbox = new Checkbox(By.XPath(".//*[@gh='mtb']//*[@role = 'presentation']"));

		Button DiscardDraftsButton = new Button(By.XPath(".//*[@gh='mtb']//div[@act='16']"));

		public ComposeEmailDialogPage OpenFirstDraft()
		{
			WaitForDraftsListVisible();

			DraftNotes.First().Click();

			return new ComposeEmailDialogPage();
		}

		public void WaitForDraftsDissapeared()
		{
			var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(5));

			wait.Until ((d) =>
			{
				return DraftNotes.Count.Equals(0);
			});
		}

		public void WaitForDraftsListVisible()
		{
			new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(5)).Until(
			ExpectedConditions.ElementIsVisible(By.XPath(".//*[@role='main']//tr[@jsmodel]//*[@role = 'link']")));
		}

		public DraftsPage GetNumberOfDrafts(out int currentNumberOfDrafts)
		{			
			currentNumberOfDrafts = DraftNotes.Count();
			return this;
		}

		public DraftsPage DiscardAllDrafts()
		{
			
			WaitForDraftsListVisible();

			if (!DraftNotes.Count.Equals(0))
			{
				SelectAllCheckbox.Click();
				DiscardDraftsButton.Click();
				WaitForDraftsDissapeared();
			}
			else
			{
				Console.WriteLine("There is no drafts to discard.");
			}

			return this;
		}

		public bool CheckEmailDisappearedFromDrafts(int numberOfDrafts)
		{
			return (DraftNotes.Count + 1).Equals(numberOfDrafts);
		}

		public bool CheckEmailPresentsInDraft(int numberOfDrafts)
		{
			return ((DraftNotes.Count - 1) == numberOfDrafts);
		}
		
	}
}
