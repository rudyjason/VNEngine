using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEngine.Engine
{
	public class EngineControl
	{
		List<GameObject> gameObjects;
		MainForm display;
		Graphics displayGraphics;

		public EngineControl(MainForm _display) {
			display = _display;
		}

		public void Init() 
		{
			displayGraphics = display.CreateGraphics();
			gameObjects = new List<GameObject>();
		}

		public void AddToGame(GameObject go) {
			gameObjects.Add(go);
		}

		public void Render() {
			foreach(GameObject go in gameObjects) {
				go.Update();
				go.Draw(displayGraphics);
			}
		}
	}
}
