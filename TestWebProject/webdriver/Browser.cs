using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;

namespace TestWebProject.webdriver
{
	public class Browser
	{
		private static Browser _currentInstane;
		private static IWebDriver _driver;
		public static BrowserFactory.BrowserType CurrentBrowser;
		public static int ImplWait;
		public static double TimeoutForElement;
		private static string _browser;

		private Browser()
		{
			InitParamas();
			_driver = BrowserFactory.GetDriver(CurrentBrowser, ImplWait);   
		}

		private static void InitParamas()
		{
			ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
			TimeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
			_browser = Configuration.Browser;
			Enum.TryParse(_browser, out CurrentBrowser);
		}

		public static Browser Instance = _currentInstane ?? (_currentInstane = new Browser());

		public static void WindowMaximise()
		{
			_driver.Manage().Window.Maximize();
		}

		public static void NavigateTo(string url)
		{
			_driver.Navigate().GoToUrl(url);
		}

		public static IWebDriver GetDriver()
		{
			return _driver;
		}

		public static void Quit()
		{
			_driver.Quit();
			_currentInstane = null;
			_driver = null;
			_browser = null;
		}
	}
}