namespace VNEngine
{
	public class StoryObject
	{
		private string chr;
		private string txt;

		public string GetText() {
			return chr + ": " + txt;
		}
	}
}