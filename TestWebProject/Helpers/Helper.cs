using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestWebProject.webdriver;

namespace TestWebProject.Helpers
{
	public class Helper
	{
		public static string GetRandomString(int length = 5)
		{
			var text = new StringBuilder();
			var random = new Random();

			for (int i = 0; i < length; i++)
			{
				var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				text.Append(ch);
			}

			return text.ToString().ToLower();
		}

		public static string GetRandomEmail(int length = 5)
		{
			var text = new StringBuilder();
			var random = new Random();

			for (int i = 0; i < length; i++)
			{
				var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				text.Append(ch);
			}

			return text.ToString().ToLower() + "@gmail.com";
		}
	}
}
