using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestWebProject.Utilities;

namespace TestWebProject.WebServiceTestScenarios
{
	
	[TestClass]
	public class BaseWebServiceTest
	{
		public static Dictionary<string, string> URLs = new Dictionary<string, string>();

		[TestInitialize]
		public void InitTest()
		{
			URLs.Add("GetUrl", Configuration.GetUserServiceUrl());
			URLs.Add("RefferUrl", Configuration.GetRefferUrl());
		}

		[TestCleanup]
		public void CleanTest()
		{
			URLs.Clear();
		}
	}
}
