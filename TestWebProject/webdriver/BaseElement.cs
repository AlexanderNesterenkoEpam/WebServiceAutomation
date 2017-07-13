using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestWebProject.webdriver
{
	public class BaseElement : IWebElement
	{
		protected By Locator;
		protected IWebElement Element;


		public BaseElement(By locator)
		{
			this.Locator = locator;
		}

		public string GetText()
		{
			this.WaitForIsVisible();
			return this.Element.Text;
		}

		public IWebElement GetElement()
		{
			try
			{
				this.Element = Browser.GetDriver().FindElement(this.Locator);
				//this.Element = FindElement(this.Locator);
			}
			catch (Exception)
			{
				
				throw;
			}
			return this.Element;
		}

		public void WaitForIsVisible()
		{
			new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(ExpectedConditions.ElementIsVisible(this.Locator));
		}


		public IWebElement FindElement(By @by)
		{
			var element = Browser.GetDriver().FindElement(by);
			
			return element;

		}

		public ReadOnlyCollection<IWebElement> FindElements(By @by)
		{
			throw new System.NotImplementedException();
		}

		public void Clear()
		{
			this.WaitForIsVisible();
			Browser.GetDriver().FindElement(this.Locator).Clear();
		}

		public void SendKeys(string text)
		{
			this.WaitForIsVisible();
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
			executor.ExecuteScript("arguments[0].style.backgroundColor = 'green'", this.GetElement());
			Browser.GetDriver().FindElement(this.Locator).SendKeys(text);
		}

		public void Submit()
		{
			throw new System.NotImplementedException();
		}

		public void Click()
		{
			this.WaitForIsVisible();
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
			executor.ExecuteScript("arguments[0].style.backgroundColor = 'red'", this.GetElement());
			Browser.GetDriver().FindElement(this.Locator).Click();
		}

		public void JsClick()
		{
			this.WaitForIsVisible();
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
			executor.ExecuteScript("arguments[0].click();", this.GetElement());
		}

		public string GetAttribute(string attributeName)
		{
			throw new System.NotImplementedException();
		}

		public string GetCssValue(string propertyName)
		{
			throw new System.NotImplementedException();
		}

		public string TagName { get; set; }
		public string Text { get; set; }
		public bool Enabled { get; set; }
		public bool Selected { get; set; }
		public Point Location { get; set; }
		public Size Size { get; set; }
		public bool Displayed { get; set; }
	}
}