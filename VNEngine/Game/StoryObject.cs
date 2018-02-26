namespace VNEngine
{
	public class StoryObject
	{
		public string chr;
		public string txt;

		public string GetText() {
			return chr + ": " + txt;
		}
	}
}