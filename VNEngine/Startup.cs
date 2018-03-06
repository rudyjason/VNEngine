using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
			Environment.CurrentDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "");

			using (StreamReader r = new StreamReader(Environment.CurrentDirectory + "/Resources/settings/settings.json"))
			{
				string json = r.ReadToEnd();
				Settings.ReadFromJson(json);
			}

			MainForm form = new MainForm();
			EngineControl engine = new EngineControl(form);
			//Game testGame = new Game(engine);
			Novel testNovel = new Novel(engine);
			Application.Run(form);
		}
	}
}
