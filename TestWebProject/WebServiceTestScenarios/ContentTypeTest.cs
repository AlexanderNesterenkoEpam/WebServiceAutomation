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
	public class ContentTypeTest : BaseWebServiceTest
	{
		[TestMethod]
		public void TestHTTPHeader()
		{
			string requestType = "GET";
			string headerFiledName = "Content-Type";
			string expected_contentType = "application/json; charset=utf-8";
			HttpResponseUtil response = new HttpResponseUtil();
			var contentType = response.GetResponseHeader(headerFiledName, requestType);
			Assert.AreEqual(expected_contentType, contentType);
		}
	}
}
