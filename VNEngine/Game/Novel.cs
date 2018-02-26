using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEngine.Engine;

namespace VNEngine
{
	public class Novel
	{
		private List<StoryObject> story;
		private EngineControl engine;

		public Novel(EngineControl e)
		{
			engine = e;
			Init();
		}

		public void Init()
		{
			using (StreamReader r = new StreamReader("./Resources/json/story.json"))
			{
				string json = r.ReadToEnd();
				story = JsonConvert.DeserializeObject<List<StoryObject>>(json);
			}
			engine.AddToGame(new StoryBoard(story));
		}
	}
}
