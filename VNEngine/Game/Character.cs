using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
		private Bitmap darkImage;
		private Rectangle charRect;

        private bool removed;

		private bool isActive;

		public Character(string s)
		{
			source = s;
			Init();
		}

		public override void Draw(Graphics g)
		{
            if(removed)
            {
                return;
            }
			if(isActive)
			{
				g.DrawImage(image, charRect);
			} 
			else
			{
				g.DrawImage(darkImage, charRect);
			}
		}

		public override void Init()
		{
			isActive = false;
            removed = false;
			image = (Bitmap)Image.FromFile(source);
			darkImage = AdjustBrightness(image, 0.5f);
			float widthAdjust = Settings.CHARACTER_HEIGHT / (float)image.Height;
			//charRect = new Rectangle(0, 0, Settings.CHARACTER_WIDTH, Settings.CHARACTER_HEIGHT);
			charRect = new Rectangle(0, 0, (int)(widthAdjust * image.Width), Settings.CHARACTER_HEIGHT);
		}

		public void SetCharacterPosition(int x, int y)
		{
			charRect.X = x;
			charRect.Y = y;
		}

		public void SetActive(bool active)
		{
			isActive = active;
		}

        public void Remove()
        {
            removed = true;
        }


        public override void Update()
		{
		}


		// Adjust the image's brightness.
		private Bitmap AdjustBrightness(Image image, float brightness)
		{
			// Make the ColorMatrix.
			float b = brightness;
			ColorMatrix cm = new ColorMatrix(new float[][]
				{
			new float[] {b, 0, 0, 0, 0},
			new float[] {0, b, 0, 0, 0},
			new float[] {0, 0, b, 0, 0},
			new float[] {0, 0, 0, 1, 0},
			new float[] {0, 0, 0, 0, 1},
				});
			ImageAttributes attributes = new ImageAttributes();
			attributes.SetColorMatrix(cm);

			// Draw the image onto the new bitmap while applying
			// the new ColorMatrix.
			Point[] points =
			{
				new Point(0, 0),
				new Point(image.Width, 0),
				new Point(0, image.Height),
			};
			Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

			// Make the result bitmap.
			Bitmap bm = new Bitmap(image.Width, image.Height);
			using (Graphics gr = Graphics.FromImage(bm))
			{
				gr.DrawImage(image, points, rect,
					GraphicsUnit.Pixel, attributes);
			}

			// Return the result.
			return bm;
		}
	}
}
