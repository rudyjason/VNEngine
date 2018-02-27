using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VNEngine.Engine;

namespace VNEngine.Game
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
		private Dictionary<string, Character> characters;

		int test = 0;

		private Stopwatch storyTimer;

		public StoryBoard(List<StoryObject> story) {
			fullStory = story;
			Init();
		}

		public override void Draw(Graphics g)
		{
			//Draw characters
			foreach(string key in characters.Keys)
			{
				characters[key].Draw(g);
			}

			//Draw text
			g.FillRectangle(Brushes.LightGray, outlineBox);
			g.DrawString(currentStory.GetScrollingText(), new Font(FontFamily.GenericMonospace, Settings.TEXT_SIZE), Brushes.Blue, textBox);
		}

		public override void Init()
		{
			currentStoryIndex = 0;
			characters = new Dictionary<string, Character>();
			canContinueStory = true;
			storyTimer = new Stopwatch();
			textPen = new Pen(Color.White);
			outlineBox = new Rectangle(20, (int)(Settings.SCREEN_HEIGHT * 0.8), (Settings.SCREEN_WIDTH - 40), (int)(Settings.SCREEN_HEIGHT * 0.2 - 20));
			textBox = new Rectangle(40, (int)(Settings.SCREEN_HEIGHT * 0.8 + 20), (Settings.SCREEN_WIDTH - 80), (int)(Settings.SCREEN_HEIGHT * 0.2 - 40));

			currentStory = fullStory[currentStoryIndex];
			runStoryElements();
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
			if (storyTimer.ElapsedMilliseconds > 100)
			{
				canContinueStory = true;
				storyTimer.Reset();
			}

			if (canContinueStory)
			{
				if (currentStoryIndex < fullStory.Count - 1)
				{
					currentStoryIndex++;
					currentStory = fullStory[currentStoryIndex];
					runStoryElements();
					canContinueStory = false;
				}
				else
				{
					Debug.WriteLine("STORY OVER");
				}
			} 
		}

		private void runStoryElements() 
		{
			string c_char = currentStory.chr;

			foreach(string key in characters.Keys)
			{
				characters[key].SetActive(false);
			}

			if(c_char == "")
			{
				return;
			}

			if(characters.ContainsKey(c_char))
			{
				characters[c_char].SetActive(true);
			}
			else
			{
				characters.Add(c_char, new Character(Settings.CHARACTER_IMAGE_FOLDER + c_char + Settings.CHARACTER_IMAGE_EXTENSION));

				characters[c_char].SetCharacterPosition(100, 200); 
				if (test == 1)
				{
					characters[c_char].SetCharacterPosition(800, 200);

				}
				test++;
				characters[c_char].SetActive(true);
			}
		}

		public override void Update()
		{
			if (currentStory.TextDone() && !storyTimer.IsRunning)
			{
				storyTimer.Start();
			}
		}
	}
}
