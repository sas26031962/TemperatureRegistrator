/*
 * Created by Andy Subbotin
 * Framework: SharpDevelop
 * Date: 30.07.2019
 * Time: 9:23
 * 
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace ExportToExelApp0
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
