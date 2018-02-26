using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VNEngine.Engine;

namespace VNEngine
{
	static class Startup
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainForm form = new MainForm();
			EngineControl engine = new EngineControl(form);
			//Game testGame = new Game(engine);
			Novel testNovel = new Novel(engine);
			Application.Run(form);
		}
	}
}
