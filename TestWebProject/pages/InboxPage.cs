using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestWebProject.forms
{
	public class InboxPage : BasePage
	{
		private static readonly By MainContent = By.XPath(".//*[@role='main']");

		public InboxPage() : base(MainContent)
		{
				
		}
	}
}
