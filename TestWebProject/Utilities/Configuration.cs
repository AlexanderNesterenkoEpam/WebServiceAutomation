using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebProject.Utilities
{
	using System.Configuration;

	public class Configuration
	{
		public static string GetEnviromentVar(string var, string defaultValue)
		{
			return ConfigurationManager.AppSettings[var] ?? defaultValue; ;
		}

		public static string GetRefferUrl()
		{
			return GetEnviromentVar("RefferUrl", "https://jsonplaceholder.typicode.com/");
		}

		public static string GetUserServiceUrl()
		{
			return GetRefferUrl() + "users";
		}
	}
}
