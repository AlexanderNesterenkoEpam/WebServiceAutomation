using OpenQA.Selenium;
using TestWebProject.Enums;

namespace TestWebProject.webdriver
{
	public abstract class AbstractPage
	{
		protected By TitleLocator;

		protected AbstractPage(By titleLocator)
		{
			this.TitleLocator = titleLocator;
			WaitForTitleToBeVisible();
		}

		public void WaitForTitleToBeVisible()
		{
			var label = new BaseElement(this.TitleLocator);
			label.WaitForIsVisible();
		}

		public bool inOnPage(Pages page)
		{
			bool isOnPage = false;

			switch (page)
			{
				case Pages.Inbox:
					 isOnPage = Browser.GetDriver().Url.Contains("#inbox");
					 break;
			}

			return isOnPage;
		}
	}
}