namespace VNEngine
{
	public class StoryObject
	{
		public string chr;
		public string txt;

		private string scrollingText;
		private int scrollingIndex;

		public StoryObject() {
			scrollingIndex = 0;
			scrollingText = "";
		}

		public string GetText() {
			return chr + ": " + txt;
		}

		public string GetScrollingText()
		{
			Scroll();
			return chr + ": " + scrollingText;
		}

		public void Scroll()
		{
			if(!TextDone())
			{
				scrollingText += txt[scrollingIndex];
				scrollingIndex++;
			}
		}

		public bool TextDone()
		{
			return scrollingIndex >= txt.Length;
		}
	}
}