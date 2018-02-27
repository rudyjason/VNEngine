using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VNEngine.Engine;

namespace VNEngine
{
	public partial class MainForm : Form
	{
		private Bitmap imageToRender;
		private bool newRenderImage;
		private EngineControl engine;
		
		public MainForm()
		{
			InitializeComponent();
			newRenderImage = false;
			this.Paint += onPaint;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			engine.Stop();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if(engine != null)
			{
				engine.ReceiveInput(e.KeyCode, true);
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if (engine != null)
			{
				engine.ReceiveInput(e.KeyCode, false);
			}
		}
		public void setImageToRender(Bitmap bmp)
		{
			newRenderImage = true;
			imageToRender = bmp; 
			if (InvokeRequired)
			{
				Invoke(new Action(() => Refresh()));
			}
		}

		public void setEngine(EngineControl e)
		{
			engine = e;
		}

		private void onPaint(object sender, PaintEventArgs e) 
		{
			e.Graphics.Clear(Color.Black);
			e.Graphics.DrawImage(imageToRender, 0, 0);
		}
	}
}
