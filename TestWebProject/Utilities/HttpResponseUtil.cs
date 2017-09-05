using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

using TestWebProject.WebServiceTestScenarios;

namespace TestWebProject.Utilities
{
	

	public class HttpResponseUtil
	{

		public HttpResponseUtil()
		{
			Url = BaseWebServiceTest.URLs["GetUrl"];
			Refferer = BaseWebServiceTest.URLs["RefferUrl"];
		}

		public string Url;

		public string Refferer;

		private const string accept
			= "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";

		private static string _longResponse;

		public static string header;

		public static HttpStatusCode statusCode;

		public static string responseData;


		public static string GetResponseBody(HttpWebRequest executeRequest)
		{
			using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
			{
				using (StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
				{
					_longResponse = myStreamReader.ReadToEnd();
				}
				return _longResponse;
			}
		}

		public static string GetResponseValue(HttpWebRequest executeRequest, string nameValue)
		{
			using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
			{
				return response.Headers.Get(nameValue);
			}
		}

		public static HttpStatusCode GetResponseStatusCode(HttpWebRequest executeRequest)
		{
			using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
			{
				return response.StatusCode;
			}
		}

		public static HttpWebResponse GetResponse(HttpWebRequest executeRequest)
		{
			using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
			{
				return response;
			}
		}

		public string GetUsersData(string requestType)
		{
			if (requestType == "GET")
			{
				responseData = GetResponseBody(HttpRequestUtil.ExecuteGetRequest(

				new Dictionary<string, string>
				 {
					{"Accept", accept},
					{"Url", Url},
					{"Referer", Refferer},
				 }));
			}
			else if (requestType == "POST")
			{
				throw new NotImplementedException();
			}
			return responseData;

		}

		public string GetResponseHeader(string headerName, string requestType)
		{
			if (requestType == "GET")
			{
				header = GetResponseValue(HttpRequestUtil.ExecuteGetRequest(

					new Dictionary<string, string>
					{
					{"Accept", accept},
					{"Url", Url},
					{"Referer", Refferer},
					}), headerName);

			}
			else if (requestType == "POST")
			{
				throw new NotImplementedException();
			}
			return header;
		}

		public HttpStatusCode GetStatusCode(string requestType)
		{
			if (requestType == "GET")
			{
				statusCode = GetResponseStatusCode(HttpRequestUtil.ExecuteGetRequest(

				new Dictionary<string, string>
				{
					{"Accept", accept},
					{"Url", Url},
					{"Referer", Refferer},
				}));

			}
			else if (requestType == "POST")
			{
				throw new NotImplementedException();
			}
			return statusCode;
		}
	}
}
