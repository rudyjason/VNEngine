namespace VNEngine
{
	public class StoryObject
	{
		public string chr;
		public string txt;
        public string pos;
        public string bg;
        public string[] exit;

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
            if (txt == null)
                return true;
			 return scrollingIndex >= txt.Length;
		}
	}
}