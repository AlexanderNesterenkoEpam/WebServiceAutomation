using OpenQA.Selenium;
using System;
using TestWebProject.webdriver;
using TestWebProject.WebdriverConfiguration;

namespace TestWebProject.Elements
{
	public class Checkbox : BaseElement
	{
		protected By ButtonLocator;
		protected Checkbox CheckBoxElement;

		public Checkbox(By locator) : base(locator)
		{
			ButtonLocator = locator;
		}

		public override void Click()
		{
			var button = Browser.GetDriver().FindElement(this.Locator);
			button.Click();
		}
	}
}
