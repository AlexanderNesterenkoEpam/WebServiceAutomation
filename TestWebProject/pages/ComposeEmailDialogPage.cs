using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestWebProject.webdriver;

namespace TestWebProject.forms
{
	public class ComposeEmailDialogPage : BasePage
	{
		private static readonly By DialogBlock = By.XPath("//*[@role='dialog']");

		public ComposeEmailDialogPage() : base(DialogBlock)
		{
			PageFactory.InitElements(Browser.GetDriver(), this);
		}

		[FindsBy(How = How.Name, Using = "to")]
		private IWebElement RecepientsInput;

		[FindsBy(How = How.XPath, Using = ".//*[@name='subjectbox']")]
		private IWebElement SubjectInput;

		[FindsBy(How = How.XPath, Using = "//*[@name = 'subject']")]
		private IWebElement HiddenSubjectInput;

		[FindsBy(How = How.XPath, Using = ".//*[@role='textbox']")]
		private IWebElement BodyInput;

		[FindsBy(How = How.XPath, Using = ".//*[@alt='Close']")]
		private IWebElement CloseNewMessageWindowButton;

		[FindsBy(How = How.XPath, Using = ".//*[contains(@data-tooltip, 'Send')]")]
		private IWebElement SendButton;

		[FindsBy(How = How.XPath, Using = ".//*[@role='alert']//div[@class = 'vh']")]
		protected IWebElement MessageHasBeenSentMessage;

		public ComposeEmailDialogPage FillEmailFields(string emailTo, string subject, string body)
		{
			RecepientsInput.Clear();
			RecepientsInput.SendKeys(emailTo);
			SubjectInput.Clear();
			SubjectInput.SendKeys(subject);
			BodyInput.Clear();
			BodyInput.SendKeys(body);

			return this;
		}

		public bool CheckEmailFilling(string emailTo, string emailSubject, string emailBody)
		{
			bool isEmailFillingCorrect = true;

			if (!RecepientsInput.GetAttribute("Value").Equals(emailTo))
			{
				Console.WriteLine("Email adress is not as expected.");
				isEmailFillingCorrect = false;
			}

			if (!HiddenSubjectInput.GetAttribute("value").Equals(emailSubject))
			{
				Console.WriteLine("Email subject is not as expected.");
				isEmailFillingCorrect = false;
			}

			if (!BodyInput.Text.Equals(emailBody))
			{
				Console.WriteLine("Email body is not as expected.");
				isEmailFillingCorrect = false;
			}

			return isEmailFillingCorrect;
		}

		public BasePage SendEmail()
		{
			SendButton.Click();
			return this;
		}

		public BasePage SendEmailUsingKeys()
		{
			new Actions(Browser.GetDriver()).SendKeys(Keys.LeftControl + Keys.Enter).Build().Perform();

			isMailSentMessageAppear();

			return this;
		}

		private void isMailSentMessageAppear()
		{
			new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(3)).Until(
				ExpectedConditions.TextToBePresentInElement(MessageHasBeenSentMessage, "Your message has been sent. View message"));
		}

		public BasePage CloseComposeDialogWindow()
		{
			CloseNewMessageWindowButton.Click();
			return this;
		}
	}
}
