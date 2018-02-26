using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VNEngine.Engine
{
	public class EngineControl
	{
		List<GameObject> gameObjects;
		MainForm display;
		Graphics displayGraphics;
		Thread renderThread;

		private short frameDuration;
		private bool gameRunning;

		int count;

		Stopwatch sw;
		Stopwatch sw2;

		public EngineControl(MainForm _display) {
			display = _display;
			Init();
		}

		public void Init() 
		{
			displayGraphics = display.CreateGraphics();
			gameObjects = new List<GameObject>();

			sw = new Stopwatch();
			sw.Start();
			sw2 = new Stopwatch();
			sw2.Start();

			gameRunning = true;

			frameDuration = 1000 / Settings.MAX_FPS;

			renderThread = new Thread(new ThreadStart(Render));
			renderThread.Start();
		}

		public void AddToGame(GameObject go) {
			gameObjects.Add(go);
		}

		public void Render()
		{
			while(gameRunning)
			{
				short sleepyTime = (short)(frameDuration - sw.ElapsedMilliseconds);
				if (sleepyTime < 1)
				{
					count++;
					sw.Restart();
					displayGraphics.Clear(Color.Black);
					foreach (GameObject go in gameObjects)
					{
						go.Update();
						go.Draw(displayGraphics);
					}
				}
				else
				{
					Thread.Sleep(sleepyTime);
				}

				if (sw2.ElapsedMilliseconds > 1000)
				{
					Debug.WriteLine("FPS: " + count);
					count = 0;
					sw2.Restart();
				}
			}
		}
	}
}
