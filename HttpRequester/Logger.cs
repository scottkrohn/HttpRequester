using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequester
{
	class Logger
	{
		public static void WriteErrorLog(Exception ex)
		{
			StreamWriter swriter = null;
			try
			{
				swriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
				swriter.WriteLine(DateTime.Now.ToString() + ": " + ex.Message);
				swriter.Flush();
				swriter.Close();
			}
			catch
			{
			}
		}

		public static void WriteErrorLog(string text)
		{
			StreamWriter swriter = null;
			try
			{
				swriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
				swriter.WriteLine(DateTime.Now.ToString() + ": " + text);
				swriter.Flush();
				swriter.Close();
			}
			catch
			{
			}
		}
	}
}
