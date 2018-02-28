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
        private EngineControl engine;

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

        public void SetEngine(EngineControl e)
        {
            engine = e;
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
            //Exit Characters
            if(currentStory.exit != null && currentStory.exit.Length > 0)
            {
                foreach(string chr in currentStory.exit)
                {
                    characters[chr].Remove();
                    characters.Remove(chr);
                }
            }

            //Change background
            if(!String.IsNullOrWhiteSpace(currentStory.bg) && engine != null)
            {
                engine.SetBackground(currentStory.bg);
            }

            //Draw characters
			string c_char = currentStory.chr;

            //set all characters to inactive
			foreach(string key in characters.Keys)
			{
				characters[key].SetActive(false);
			}

            //no character interactions this round
			if(c_char == "")
			{
				return;
			}

            //add character to scene if not already present
			if(!characters.ContainsKey(c_char))
			{
				characters.Add(c_char, new Character(Settings.CHARACTER_IMAGE_FOLDER + c_char + Settings.CHARACTER_IMAGE_EXTENSION));
            }       

            //set character position
            if (!String.IsNullOrWhiteSpace(currentStory.pos))
            {
                switch (currentStory.pos)
                {
                    case "left":
                        characters[c_char].SetCharacterPosition(Settings.CHARACTER_POS_LEFT, 200);
                        break;
                    case "middle":
                        characters[c_char].SetCharacterPosition(Settings.CHARACTER_POS_MIDDLE, 200);
                        break;
                    case "right":
                        characters[c_char].SetCharacterPosition(Settings.CHARACTER_POS_RIGHT, 200);
                        break;
                }
            }

            //set character to active
            characters[c_char].SetActive(true);
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
