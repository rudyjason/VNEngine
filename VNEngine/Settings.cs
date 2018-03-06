using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEngine
{
	public static class Settings
	{
		//TODO: Implement
		public const byte TEXT_SPEED = 10; //10 is fastest, 1 is slowest, 0 is instant


		public static short SCREEN_WIDTH { get; set; }
		public static short SCREEN_HEIGHT { get; set; }

		public static short MAX_FPS { get; set; }

		public static short TEXT_SIZE { get; set; }

		public static string BACKGROUND_IMAGE_LOCATION { get; set; }
		public static string BACKGROUND_IMAGE_DEFAULT { get; set; }
		public static string BACKGROUND_IMAGE_EXTENSION { get; set; }

		public static string CHARACTER_IMAGE_FOLDER { get; set; }
		public static string CHARACTER_IMAGE_EXTENSION { get; set; }

		public static short CHARACTER_WIDTH { get; set; }
		public static short CHARACTER_HEIGHT { get; set; }

		public static short CHARACTER_POS_LEFT { get; set; }
		public static short CHARACTER_POS_MIDDLE { get; set; }
		public static short CHARACTER_POS_RIGHT { get; set; }

		// DON'T FORGET TO ADD SETTINGS TO THE READFROMJSON FUNCTION AND THE SETTINGSJSONOBJECT WHEN ADDING TO THE CLASS
		public static void ReadFromJson(string json)
		{
			var jsonObject = JsonConvert.DeserializeObject<SettingsJsonObject>(json);

			SCREEN_WIDTH = jsonObject.SCREEN_WIDTH;
			SCREEN_HEIGHT = jsonObject.SCREEN_HEIGHT;

			MAX_FPS = jsonObject.MAX_FPS;

			TEXT_SIZE = jsonObject.TEXT_SIZE;

			BACKGROUND_IMAGE_LOCATION = jsonObject.BACKGROUND_IMAGE_LOCATION;
			BACKGROUND_IMAGE_DEFAULT = jsonObject.BACKGROUND_IMAGE_DEFAULT;
			BACKGROUND_IMAGE_EXTENSION = jsonObject.BACKGROUND_IMAGE_EXTENSION;

			CHARACTER_IMAGE_FOLDER = jsonObject.CHARACTER_IMAGE_FOLDER;
			CHARACTER_IMAGE_EXTENSION = jsonObject.CHARACTER_IMAGE_EXTENSION;

			CHARACTER_WIDTH = jsonObject.CHARACTER_WIDTH;
			CHARACTER_HEIGHT = jsonObject.CHARACTER_HEIGHT;

			CHARACTER_POS_LEFT = jsonObject.CHARACTER_POS_LEFT;
			CHARACTER_POS_MIDDLE = jsonObject.CHARACTER_POS_MIDDLE;
			CHARACTER_POS_RIGHT = jsonObject.CHARACTER_POS_RIGHT;
		}

		public static void SetDefault() 
		{
			SCREEN_WIDTH = 1280;
			SCREEN_HEIGHT = 720;

			MAX_FPS = 60;

			TEXT_SIZE = 10;

			BACKGROUND_IMAGE_LOCATION = "./Resources/images/bg/";
			BACKGROUND_IMAGE_DEFAULT = "test_bg.png";
			BACKGROUND_IMAGE_EXTENSION = ".png";

			CHARACTER_IMAGE_FOLDER = "./Resources/images/char/";
			CHARACTER_IMAGE_EXTENSION = ".png";

			CHARACTER_WIDTH = 200;
			CHARACTER_HEIGHT = 500;

			CHARACTER_POS_LEFT = 0;
			CHARACTER_POS_MIDDLE = 400;
			CHARACTER_POS_RIGHT = 800;
		}

	}

	public class SettingsJsonObject {	   
			   
		public short SCREEN_WIDTH { get; set; }
		public short SCREEN_HEIGHT { get; set; }

		public short MAX_FPS { get; set; }

		public short TEXT_SIZE { get; set; }

		public string BACKGROUND_IMAGE_LOCATION { get; set; }
		public string BACKGROUND_IMAGE_DEFAULT { get; set; }
		public string BACKGROUND_IMAGE_EXTENSION { get; set; }

		public string CHARACTER_IMAGE_FOLDER { get; set; }
		public string CHARACTER_IMAGE_EXTENSION { get; set; }

		public short CHARACTER_WIDTH { get; set; }
		public short CHARACTER_HEIGHT { get; set; }

		public short CHARACTER_POS_LEFT { get; set; }
		public short CHARACTER_POS_MIDDLE { get; set; }
		public short CHARACTER_POS_RIGHT { get; set; }
	}
}
