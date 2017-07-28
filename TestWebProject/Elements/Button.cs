using System;
using OpenQA.Selenium;
using TestWebProject.webdriver;
using TestWebProject.WebdriverConfiguration;

namespace TestWebProject.Webdriver
{
	public class Button : BaseElement
	{
		protected Button ButtonElement;

		public Button(By locator) : base(locator)
		{

		}

		public override void Click()
		{
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
			executor.ExecuteScript("arguments[0].style.backgroundColor = 'red'", this.GetElement());

			base.Click();		
		}
	}
}
