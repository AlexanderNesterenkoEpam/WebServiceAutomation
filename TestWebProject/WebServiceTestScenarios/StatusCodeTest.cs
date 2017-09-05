using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestWebProject.WebServiceTestScenarios
{
	using TestWebProject.Utilities;

	[TestClass]
	public class StatusCodeTest : BaseWebServiceTest
	{
		[TestMethod]
		public void TestHTTPStatusCode()
		{
			string requestType = "GET";
			HttpResponseUtil response = new HttpResponseUtil();
			var statusCode = response.GetStatusCode(requestType);
			Assert.AreEqual("OK", Convert.ToString(statusCode));
		}
	}
}
