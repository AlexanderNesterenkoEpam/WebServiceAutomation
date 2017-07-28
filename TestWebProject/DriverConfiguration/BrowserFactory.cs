using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace TestWebProject.WebdriverConfiguration
{
	public class BrowserFactory
	{
		public enum BrowserType
		{
			Chrome,
			Firefox,
			IEdge,
			PhantomJs, 
			RemoteFirefox,
			RemoteChrome,
		}

		public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
		{
			IWebDriver driver = null;

			switch (type)
			{
				case BrowserType.Chrome:
				{
					var service = ChromeDriverService.CreateDefaultService();
					var option = new ChromeOptions();
					option.AddArgument("disable-infobars");
					driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
					break;
				}
					case BrowserType.Firefox:
				{
					var service = FirefoxDriverService.CreateDefaultService();
					var options = new FirefoxOptions();
					driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
					break;
				}

					case BrowserType.RemoteFirefox:
				{
					var capability = DesiredCapabilities.Firefox();
					capability.SetCapability(CapabilityType.BrowserName, "firefox");
					capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
					driver = new RemoteWebDriver(new Uri("http://localhost:5525/wd/hub"), capability);
					break;
				}

					case BrowserType.RemoteChrome:
				{
					var capability = DesiredCapabilities.Chrome();
					capability.SetCapability(CapabilityType.BrowserName, "chrome");
					capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Vista));
					driver = new RemoteWebDriver(new Uri("http://localhost:5577/wd/hub"), capability);

					break;
				}
			}
			return driver;
		}
	}
}