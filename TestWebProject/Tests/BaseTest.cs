using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebProject.WebdriverConfiguration;

namespace TestWebProject.webdriver
{
	[TestClass]
	public class BaseTest
	{
		public TestContext TestContext { get; set; }
		protected static Browser Browser = Browser.Instance;

		[TestInitialize]
		public virtual void InitTest()
		{
			Browser = Browser.Instance;
			Browser.WindowMaximise();
			Browser.NavigateTo(Configuration.StartUrl);
		}

		[TestCleanup]
		public virtual void CleanTest()
		{
			Browser.Quit();
		}
	}
}