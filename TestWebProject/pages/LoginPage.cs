using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestWebProject.webdriver;
using TestWebProject.Entities;
using TestWebProject.Webdriver;

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
		private readonly Button PasswordNext = new Button(By.Id("passwordNext"));


		public InboxPage InputLogin(User user)
		{
			Login.Clear();
			Login.SendKeys(user.email); 
			NextButton.Click();
			Password.SendKeys(user.password);
			PasswordNext.Click();

			return new InboxPage();
		}
	}
}
