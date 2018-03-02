using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEngine
{
	public static class Settings
	{
		public const short SCREEN_WIDTH = 1280;
		public const short SCREEN_HEIGHT = 720;

		public const short MAX_FPS = 60;

		public const short TEXT_SIZE = 10;

        public const string BACKGROUND_IMAGE_LOCATION = "./Resources/images/bg/";
        public const string BACKGROUND_IMAGE_DEFAULT = "test_bg.png";
        public const string BACKGROUND_IMAGE_EXTENSION = ".png";

        public const string CHARACTER_IMAGE_FOLDER = "./Resources/images/char/";
		public const string CHARACTER_IMAGE_EXTENSION = ".png";

		public const short CHARACTER_WIDTH = 200;
		public const short CHARACTER_HEIGHT = 500;

        public const short CHARACTER_POS_LEFT = 0;
        public const short CHARACTER_POS_MIDDLE = 400;
        public const short CHARACTER_POS_RIGHT = 800;

        //TODO: Implement
        public const byte TEXT_SPEED = 10; //10 is fastest, 1 is slowest, 0 is instant
	}
}
