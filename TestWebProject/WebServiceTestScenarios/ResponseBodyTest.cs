using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestWebProject.WebServiceTestScenarios
{
	using TestWebProject.Utilities;

	[TestClass]
	public class ResponseBodyTest : BaseWebServiceTest
	{
		[TestMethod]
		public void TestUsersAmountInResponse()
		{
			string requestType = "GET";
			HttpResponseUtil response = new HttpResponseUtil();
			var responseData = response.GetUsersData(requestType);
			int count = 0;
			foreach (Match m in Regex.Matches(responseData, "\"id\""))
			{
				count++;
			}
			Assert.AreEqual("10", Convert.ToString(count));
		}
	}
}
