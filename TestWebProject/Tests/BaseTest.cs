using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestWebProject.WebdriverConfiguration;

namespace TestWebProject.webdriver
{
	[TestClass]
	[Binding]
	public class BaseTest
	{
		public TestContext TestContext { get; set; }
		protected static Browser Browser = Browser.Instance;

		[TestInitialize]
		public static void InitTest()
		{
			Browser = Browser.Instance;
			Browser.WindowMaximise();
			Browser.NavigateTo(Configuration.StartUrl);
		}

		[TestCleanup]
		[AfterFeature()]
		public static void CleanTest()
		{
			Browser.Quit();
		}
	}
}