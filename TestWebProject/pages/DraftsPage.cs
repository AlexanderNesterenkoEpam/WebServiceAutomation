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
	
		public ComposeEmailDialogPage OpenFirstDraft()
		{
			DraftNotes.First().Click();

			return new ComposeEmailDialogPage();
		}

		public DraftsPage GetNumberOfDrafts(out int currentNumberOfDrafts)
		{			
			currentNumberOfDrafts = DraftNotes.Count();
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
