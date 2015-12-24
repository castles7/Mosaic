using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mosaic
{
    public class Tile
    {
        Form form;
    //    public Puzzle puzzle;
        public PictureBox picture;
        Bitmap _bitmap;
        Graphics _grMap;
        bool Mouse = false;

        public Tile()
        {
            picture = new PictureBox();
            picture.MouseDown += new System.Windows.Forms.MouseEventHandler(Picture1_MouseDown);
            picture.MouseMove += new System.Windows.Forms.MouseEventHandler(Picture1_MouseMove);
            picture.MouseUp += new System.Windows.Forms.MouseEventHandler(Picture1_MouseUp);
            
        }

        public void DrawImageOfTiles(Image image, int x, int y, int width, int heght)
        {
           
            _bitmap = new Bitmap(picture.Width,picture.Height);
            _grMap = Graphics.FromImage(_bitmap);
             Rectangle rect = new Rectangle(x,y,width,heght);
             GraphicsUnit units = GraphicsUnit.Pixel;
            _grMap.DrawImage(image,0,0,rect,units);
            picture.Image = _bitmap;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void Picture1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse == true)
            {
                picture.Location = new Point((Cursor.Position.X - form.Location.X), (Cursor.Position.Y - form.Location.Y));
             //   picture.Invalidate();
            }
        }

        private void Picture1_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse = true;
        }

        private void Picture1_MouseUp(object sender, MouseEventArgs e)
        {
            Mouse = false;
        }
    }
}
