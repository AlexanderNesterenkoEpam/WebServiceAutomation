using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestWebProject.webdriver
{
	public class BaseTest
	{
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