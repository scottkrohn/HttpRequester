using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HttpRequester
{
	public partial class Requester : ServiceBase
	{

		private Timer timerOne = null;
		private string websiteOneUrl = "http://www.personalgradebook.com";
		private string websiteTwoUrl = "http://www.personalgradebook.com/Account/Login";
		private string websiteThreeUrl = "http://www.krohndesigns.com";

		public Requester()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			timerOne = new Timer();
			timerOne.Interval = 60000;
			// Set the callback function for when the timer interval occurs.
			timerOne.Elapsed += new System.Timers.ElapsedEventHandler(this.timerOneElapsedEvent);
			timerOne.Enabled = true;
			Logger.WriteErrorLog("HttpRequester windows service started.");
		}

		protected override void OnStop()
		{
			Logger.WriteErrorLog("HttpRequester windows service stopped.");
		}

		// Callback function called by timerOne after the interval has elapsed.
		protected void timerOneElapsedEvent(object sender, ElapsedEventArgs eargs)
		{
			Logger.WriteErrorLog("Time elapsed event STARTED");
			try
			{
				WebRequest requestOne = WebRequest.Create(websiteOneUrl);
				using (HttpWebResponse responseOne = (HttpWebResponse)requestOne.GetResponse())
				{
					if(responseOne == null)
					{
						Logger.WriteErrorLog("Error: responseOne is NULL");
					}
					else if (responseOne.StatusCode != HttpStatusCode.OK)
					{
						Logger.WriteErrorLog("Error: responseOne.StatusCode is not OK");
					}
					else
					{
						Logger.WriteErrorLog("Success:\nStatus Code: " + responseOne.StatusCode + ", " + responseOne);
					}
				}
				Logger.WriteErrorLog("Time elapsed event COMPLETE");
			}
			catch(Exception ex)
			{

			}

		}
	}
}
