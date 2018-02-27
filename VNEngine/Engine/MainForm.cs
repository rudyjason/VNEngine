using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNEngine
{
	public partial class MainForm : Form
	{
		private Bitmap imageToRender;
		private bool newRenderImage;
		
		public MainForm()
		{
			InitializeComponent();
			newRenderImage = false;
			this.Paint += onPaint;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

		}

		public void setImageToRender(Bitmap bmp)
		{
			newRenderImage = true;
			imageToRender = bmp;
		}

		private void onPaint(object sender, PaintEventArgs e) {
			if(newRenderImage)
			{
				e.Graphics.Clear(Color.Black);
				e.Graphics.DrawImage(imageToRender, 0, 0);
			}
		}
	}
}
