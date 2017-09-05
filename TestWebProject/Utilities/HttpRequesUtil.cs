using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebProject.Utilities
{
	using System.Net;

	public static class HttpRequestUtil
	{
		private const string accept
			= "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";

		public static HttpWebRequest ExecutePostRequest(string paramsToRequest,
		                                                Dictionary<string, string> headers, Dictionary<string, string> properties)
		{
			string formParams = paramsToRequest;
			string sQueryString = formParams;
			byte[] byteArr = Encoding.ASCII.GetBytes(sQueryString);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(properties["Url"]);
			request.Method = "POST";
			request.ContentType = properties["ContentType"];
			request.Referer = properties["Referer"];
			foreach (var header in headers)
			{
				request.Headers.Add(header.Key, header.Value);
			}
			request.AllowAutoRedirect = Convert.ToBoolean(properties["AllowAutoRedirect"]);
			request.ContentLength = byteArr.Length;
			request.GetRequestStream().Write(byteArr, 0, byteArr.Length);
			return request;
		}

		public static HttpWebRequest ExecuteGetRequest(
			Dictionary<string, string> properties)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(properties["Url"]);
			request.Accept = properties["Accept"];
			request.Method = "GET";
			request.Referer = properties["Referer"];
			return request;
		}

	}
}
