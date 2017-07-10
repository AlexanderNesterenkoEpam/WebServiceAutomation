using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestWebProject.webdriver;

namespace TestWebProject.forms
{
	public class LoginForm : AbstractPage
	{
		private static readonly By _loginInput = By.Id("identifierId");

		public LoginForm() : base(_loginInput)
		{

		}

		private readonly BaseElement Login = new BaseElement(_loginInput);
		private readonly BaseElement NextButton = new BaseElement(By.Id("identifierNext"));
		private readonly BaseElement Password = new BaseElement(By.Name("password"));
		private readonly BaseElement PasswordNestButton = new BaseElement(By.Id("passwordNext"));


		public InboxPage InputLogin(string login, string password)
		{
			Login.Clear();
			Login.SendKeys(login);
			NextButton.Click();
			Password.SendKeys(password);
			PasswordNestButton.Click();

			return new InboxPage();
		}
	}
}
