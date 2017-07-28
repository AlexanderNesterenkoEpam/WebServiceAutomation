using System.Configuration;

namespace TestWebProject.WebdriverConfiguration
{
	public class Configuration
	{
		public static string GetEnviromentVar(string var, string defaultValue)
		{
			return ConfigurationManager.AppSettings[var] ?? defaultValue;
		}

		public static string ElementTimeout => GetEnviromentVar("ElementTimeout", "30");

		public static string Browser => GetEnviromentVar("Browser", "Firefox");

		public static string StartUrl => GetEnviromentVar("StartUrl", "https://mail.google.com");
	}
}