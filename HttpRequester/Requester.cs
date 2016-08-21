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
		private int interval = 60000; // Interval set to 60 seconds.

		public Requester()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			timerOne = new Timer();
			timerOne.Interval = interval;
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
			// Request the websites and log the results.
			try
			{
				WebRequest requestOne = WebRequest.Create(websiteOneUrl);
				requestOne.Timeout = 60000;		// timeout after 60 seconds.
				// Get the response, log the data and then discard the response at the end of the 'using' block.
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
						// Log the status code and response string on successful request.
						Logger.WriteErrorLog("responseOne Success:\nStatus Code: " + responseOne.StatusCode + ", " + responseOne);
					}
				}

				WebRequest requestTwo = WebRequest.Create(websiteTwoUrl);
				requestTwo.Timeout = 60000;		// timeout after 60 seconds.
				// Get the response, log the data and then discard the response at the end of the 'using' block.
				using (HttpWebResponse responseTwo = (HttpWebResponse)requestTwo.GetResponse())
				{
					if(responseTwo == null)
					{
						Logger.WriteErrorLog("Error: responseTwo is NULL");
					}
					else if (responseTwo.StatusCode != HttpStatusCode.OK)
					{
						Logger.WriteErrorLog("Error: responseTwo.StatusCode is not OK");
					}
					else
					{
						// Log the status code and response string on successful request.
						Logger.WriteErrorLog("reponseTwo Success:\nStatus Code: " + responseTwo.StatusCode + ", " + responseTwo);
					}
				}

				WebRequest requestThree= WebRequest.Create(websiteOneUrl);
				requestThree.Timeout = 60000;		// timeout after 60 seconds.
				// Get the response, log the data and then discard the response at the end of the 'using' block.
				using (HttpWebResponse responseThree = (HttpWebResponse)requestThree.GetResponse())
				{
					if(responseThree == null)
					{
						Logger.WriteErrorLog("Error: responseThree is NULL");
					}
					else if (responseThree.StatusCode != HttpStatusCode.OK)
					{
						Logger.WriteErrorLog("Error: responseThree.StatusCode is not OK");
					}
					else
					{
						// Log the status code and response string on successful request.
						Logger.WriteErrorLog("responseThree Success:\nStatus Code: " + responseThree.StatusCode + ", " + responseThree);
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
