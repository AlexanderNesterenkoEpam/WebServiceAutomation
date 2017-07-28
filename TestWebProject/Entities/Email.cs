using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebProject.Entities
{
	public class Email
	{
		public string emailTo { get; private set; }
		public string emailSubject { get; private set; }
		public string emailBody { get; private set; }


		public Email(string emailTo, string emailSubject, string emailBody)
		{
			this.emailTo = emailTo;
			this.emailSubject = emailSubject;
			this.emailBody = emailSubject;
		} 
	}
}
