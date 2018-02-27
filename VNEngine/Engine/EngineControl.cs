using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNEngine.Engine
{
	public class EngineControl
	{
		List<GameObject> gameObjects;
		MainForm display;
		Graphics displayGraphics;
		Thread renderThread;
		Dictionary<Keys, bool> keyDict;

		private short frameDuration;
		private bool gameRunning;

		int count;

		Graphics deferredImage;

		Stopwatch sw;
		Stopwatch sw2;

		private Bitmap background;

		public EngineControl(MainForm _display) {
			display = _display;
			Init();
		}

		public void Stop()
		{
			renderThread.Abort();
			Application.Exit();
		}

		public void Init()
		{
			display.setEngine(this);
			displayGraphics = display.CreateGraphics();
			gameObjects = new List<GameObject>();
			keyDict = new Dictionary<Keys, bool>();

			background = ResizeImage(Image.FromFile(Settings.BACKGROUND_IMAGE_LOCATION), Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);

			sw = new Stopwatch();
			sw.Start();
			sw2 = new Stopwatch();
			sw2.Start();

			gameRunning = true;

			frameDuration = 1000 / Settings.MAX_FPS;

			renderThread = new Thread(new ThreadStart(Render));
			renderThread.Start();
		}

		public void ReceiveInput(Keys keyCode, bool down)
		{
			if(!keyDict.ContainsKey(keyCode))
			{
				keyDict.Add(keyCode, down);
			} else {
				keyDict[keyCode] = down;
			}
		}

		private void HandleInput()
		{
			try
			{
				foreach(Keys key in keyDict.Keys)
				{
					if(keyDict[key])
					{
						foreach (GameObject go in gameObjects)
						{
							go.HandleInput(key);
						}
					}
				}
			} catch (Exception e) {
				//
			}

		}

		public void AddToGame(GameObject go) {
			gameObjects.Add(go);
		}

		public void Update()
		{
			HandleInput();
			foreach(GameObject go in gameObjects)
			{
				go.Update();
			}
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
					//var bmp = new Bitmap(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
					deferredImage = Graphics.FromImage(background);
					//deferredImage.ScaleTransform((float)background.Width / Settings.SCREEN_WIDTH, (float)background.Height / Settings.SCREEN_HEIGHT);
					Update();
					foreach (GameObject go in gameObjects)
					{
						go.Draw(deferredImage);
					}

					display.setImageToRender(background);
					//bmp.Dispose();
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

		/// <summary>
		/// Resize the image to the specified width and height.
		/// </summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="width">The width to resize to.</param>
		/// <param name="height">The height to resize to.</param>
		/// <returns>The resized image.</returns>
		public static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}
	}
}
