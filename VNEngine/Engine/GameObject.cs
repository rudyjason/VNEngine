using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNEngine.Engine
{
	public abstract class GameObject
	{
		public abstract void Init();
		public abstract void Draw(Graphics g);
		public abstract void Update();

		public virtual void HandleInput(Keys key) { }
	}
}
