using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEngine.Engine;

namespace VNEngine.Game
{
	public class Background : GameObject
	{
		private Bitmap bg;
		private Rectangle screenRect;

		public Background()
		{
			Init();
		}

		public override void Draw(Graphics g)
		{
			g.DrawImage(bg, screenRect);
		}

		public override void Init()
		{
			screenRect = new Rectangle(0, 0, Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
			bg = (Bitmap)Image.FromFile("./Resources/images/bg/test_bg.jpg");
		}

		public override void Update()
		{
		}
	}
}
