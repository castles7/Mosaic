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
        public int x_matrix_baseimage;
        public int y_matrix_baseimage;

        public int x_matrix_current;
        public int y_matrix_current;

        public PlayingZone playing_zone;
        //    public Puzzle puzzle;
        public Button picture;
        Bitmap _bitmap;
        Graphics _grMap;
        Point startPoint;
        public Point prev_location_in_matrix;
        Point prev_location_pixel;
        bool location_in_of_matrix;

        public int width_tile;
        public int height_tile;
        public Point LocationPuzzle;
        public int row_matrix;
        public int column_matrix;

        bool Mouse = false;

        public Tile()
        {
            picture = new Button();
            prev_location_pixel = new Point(0, 0);
           
     //       location_out_of_matrix = false;
         
            picture.MouseDown += new System.Windows.Forms.MouseEventHandler(Picture1_MouseDown);
            picture.MouseMove += new System.Windows.Forms.MouseEventHandler(Picture1_MouseMove);
            picture.MouseUp += new System.Windows.Forms.MouseEventHandler(Picture1_MouseUp);

        }



        void SetAffixment()
        {
            int x_pixel=picture.Location.X+width_tile/2;
            int y_pixel = picture.Location.Y + height_tile / 2;
            
            for (int i = 0; i < row_matrix; i++)
                for (int j = 0; j < column_matrix; j++)
                {

                    int location_tile_x=LocationPuzzle.X+width_tile*j;
                    int location_tile_y = LocationPuzzle.Y + height_tile * i;

                    if ((x_pixel >= location_tile_x) &&
                        (x_pixel <= location_tile_x + width_tile) &&
                        (y_pixel >= location_tile_y) &&
                        (y_pixel <= location_tile_y + height_tile))
                    {
                        location_in_of_matrix = true;
                        if (Program.MainForm.menu.playing_zone.puzzle.matrix[i, j].empty != false)
                        {             
                            prev_location_in_matrix = new Point(x_matrix_current, y_matrix_current);
                            x_matrix_current = i;
                            y_matrix_current = j;
                            picture.Location = new Point(location_tile_x, location_tile_y);
                        }
                        else
                        {
                            location_tile_x = LocationPuzzle.X + width_tile * y_matrix_current;
                            location_tile_y = LocationPuzzle.Y + height_tile * x_matrix_current;
                            picture.Location = new Point(location_tile_x, location_tile_y);
                        }

                        i = row_matrix;
                        j = column_matrix;
                    }

                }
        }


        void CheckNewLocationTile()
        {
           
         //   Program.MainForm.menu.playing_zone.puzzle.matrix[i, j].empty = false;
        //    int x=LocationPuzzle.X+width_tile*prev_location_in_matrix.Y;
        //    int y = LocationPuzzle.Y + height_tile * prev_location_in_matrix.X;
         //   Point p = new Point(prev_location_pixel.X, prev_location_pixel.Y);
            if (picture.Location != prev_location_pixel) 
            {
                if ((prev_location_pixel.X + 1 > LocationPuzzle.X) &&
                    (prev_location_pixel.X + 1 < LocationPuzzle.X + Program.MainForm.menu.playing_zone.puzzle.SizePuzzle.Width) &&
                    (prev_location_pixel.Y + 1 > LocationPuzzle.Y) &&
                    (prev_location_pixel.Y + 1 < LocationPuzzle.Y + Program.MainForm.menu.playing_zone.puzzle.SizePuzzle.Height))
                {
                    if ((picture.Location.X + 1 > LocationPuzzle.X) &&
                    (picture.Location.X + 1 < LocationPuzzle.X + Program.MainForm.menu.playing_zone.puzzle.SizePuzzle.Width) &&
                    (picture.Location.Y + 1 > LocationPuzzle.Y) &&
                    (picture.Location.Y + 1 < LocationPuzzle.Y + Program.MainForm.menu.playing_zone.puzzle.SizePuzzle.Height))
                        Program.MainForm.menu.playing_zone.puzzle.matrix[x_matrix_current, y_matrix_current].empty = false;
                    else
                        Program.MainForm.menu.playing_zone.puzzle.matrix[x_matrix_current, y_matrix_current].empty = true;
                    Program.MainForm.menu.playing_zone.puzzle.matrix[prev_location_in_matrix.X, prev_location_in_matrix.Y].empty = true;
                }
                else
                {
                    if (location_in_of_matrix == true)
                    {
                        Program.MainForm.menu.playing_zone.puzzle.matrix[x_matrix_current, y_matrix_current].empty = false;
                        location_in_of_matrix = false;
                    }
                }
            }
         
               
            //    Program.MainForm.menu.playing_zone.puzzle.matrix[prev_location_in_matrix.X, prev_location_in_matrix.Y].empty = true;
               // Program.MainForm.menu.playing_zone.puzzle.matrix[x_matrix_current,y_matrix_current]
        }

        public void SetLocationTiles(int x,int y)
        {
            picture.Location = new Point(x,y);
        }

        public void DrawImageOfTiles(Image image, int x, int y, int width, int heght)
        {
            picture.Width = width;
            picture.Height = heght;
            _bitmap = new Bitmap(picture.Width, picture.Height);
            _grMap = Graphics.FromImage(_bitmap);
            Rectangle rect = new Rectangle(x, y, width, heght);
            GraphicsUnit units = GraphicsUnit.Pixel;
            _grMap.DrawImage(image, 0, 0, rect, units);
            picture.BackgroundImage = _bitmap;
            picture.BackgroundImageLayout = ImageLayout.Stretch;
         //   picture.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void Picture1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse == true)
            {
                int top = picture.Top + e.Y - startPoint.Y;
                int left = picture.Left + e.X - startPoint.X;
                int bottom = picture.Bottom + e.Y - startPoint.Y;
                int right = picture.Right + e.X - startPoint.X;

                if ((top > 0) && (bottom < Program.MainForm.menu.playing_zone.Height))
                    picture.Top += e.Y - startPoint.Y;

                if ((left > 0) && (right < Program.MainForm.menu.playing_zone.Width))
                    picture.Left += e.X - startPoint.X;
            }
        }

        private void Picture1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            prev_location_pixel = picture.Location;
            Mouse = true;
        }

        private void Picture1_MouseUp(object sender, MouseEventArgs e)
        {
            Mouse = false;
            SetAffixment();
            CheckNewLocationTile();
            Program.MainForm.menu.playing_zone.puzzle.CheckFinish();
        }
    }
}
