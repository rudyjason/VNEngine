using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEngine.Engine;

namespace VNEngine.Game
{
	public class Character : GameObject
	{
		private string source;
		private Bitmap image;
		private Rectangle charRect;

		public Character(string s)
		{
			source = s;
			Init();
		}

		public override void Draw(Graphics g)
		{
			g.DrawImage(image, charRect);
		}

		public override void Init()
		{
			image = (Bitmap)Image.FromFile(source);
			charRect = new Rectangle(0, 0, Settings.CHARACTER_WIDTH, Settings.CHARACTER_HEIGHT);
		}

		public void MoveCharacter(int x, int y)
		{
			charRect.X = x;
			charRect.Y = y;
		}

		public override void Update()
		{
		}
	}
}
