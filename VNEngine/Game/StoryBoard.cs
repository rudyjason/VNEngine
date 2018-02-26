using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VNEngine.Engine;

namespace VNEngine
{
	public class StoryBoard : GameObject
	{
		private List<StoryObject> fullStory;
		private StoryObject currentStory;
		private Pen textPen;
		private Rectangle outlineBox;
		private Rectangle textBox;
		private short currentStoryIndex;
		private bool canContinueStory;

		private Stopwatch storyTimer;

		public StoryBoard(List<StoryObject> story) {
			fullStory = story;
			Init();
		}

		public override void Draw(Graphics g)
		{
			g.DrawRectangle(textPen, outlineBox);
			g.DrawString(fullStory[currentStoryIndex].GetText(), new Font(FontFamily.GenericMonospace, Settings.TEXT_SIZE), Brushes.Blue, textBox);
		}

		public override void Init()
		{
			currentStoryIndex = 0;
			canContinueStory = true;
			storyTimer = new Stopwatch();
			textPen = new Pen(Color.White);
			outlineBox = new Rectangle(20, (int)(Settings.SCREEN_HEIGHT * 0.8), (Settings.SCREEN_WIDTH - 40), (int)(Settings.SCREEN_HEIGHT * 0.2 - 20));
			textBox = new Rectangle(40, (int)(Settings.SCREEN_HEIGHT * 0.8 + 20), (Settings.SCREEN_WIDTH - 80), (int)(Settings.SCREEN_HEIGHT * 0.2 - 40));
		}

		public override void HandleInput(Keys key)
		{
			switch (key)
			{
				case Keys.Space: TellStory();
				break;
			}
		}

		public void TellStory()
		{
			if (storyTimer.ElapsedMilliseconds > 1000)
			{
				canContinueStory = true;
				storyTimer.Reset();
			}

			if (canContinueStory)
			{
				if (currentStoryIndex < fullStory.Count - 1)
				{
					currentStoryIndex++;
					canContinueStory = false;
					storyTimer.Start();
				}
				else
				{
					Debug.WriteLine("STORY OVER");
				}
			} 
			else
			{
				canContinueStory = true;
				storyTimer.Reset();
			}
		}

		public override void Update()
		{
		}
	}
}
