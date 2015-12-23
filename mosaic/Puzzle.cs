using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mosaic
{
    public class Puzzle
    {
        public int row_matrix;
        public int column_matrix;
        public Image ImagePuzzle;
        public List<Tile> ListTiles = new List<Tile>();
        public MatrixElem[,] matrix;
        public int AmountRightTiles;
        int widthTile;
        int heightTile;
        public Point LocationPuzzle;
        public Size SizePuzzle;
        Bitmap BitmapImage;

        public Puzzle()
        {
            SizePuzzle = new Size(649, 504);
            LocationPuzzle = new Point(323, 20);
            AmountRightTiles = 0;
        }

        public void CheckFinish()
        {
            for (int i=0;i<ListTiles.Count;i++)
            {
                if ((ListTiles[i].x_matrix_baseimage == ListTiles[i].x_matrix_current) &&
                    (ListTiles[i].y_matrix_baseimage == ListTiles[i].y_matrix_current))
                    AmountRightTiles++;
            }
            if (AmountRightTiles == row_matrix * column_matrix)
                Program.MainForm.menu.playing_zone.HappyEnd();
            else
            {
                AmountRightTiles = 0;
            }
        }

        public void DevideImageIntoTiles()
        {
            BitmapImage = new Bitmap(ImagePuzzle,SizePuzzle);

            widthTile = SizePuzzle.Width / column_matrix;
            heightTile = SizePuzzle.Height / row_matrix;
            matrix = new MatrixElem[row_matrix, column_matrix];

            for (int i=0;i<row_matrix;i++)
                for (int j = 0; j < column_matrix; j++)
                {
                    Tile tmp_tile = new Tile();
                    tmp_tile.x_matrix_baseimage = i;
                    tmp_tile.y_matrix_baseimage = j;
                    tmp_tile.DrawImageOfTiles((Image)BitmapImage, j * widthTile, i * heightTile, widthTile, heightTile);
                    tmp_tile.width_tile = widthTile;
                    tmp_tile.height_tile = heightTile;
                    tmp_tile.LocationPuzzle = LocationPuzzle;
                    tmp_tile.row_matrix = row_matrix;
                    tmp_tile.column_matrix = column_matrix;
                    matrix[i, j] = new MatrixElem();
                    ListTiles.Add(tmp_tile);
                }
            MixTiles();
            SetLocationTiles();
        }

        void MixTiles()
        {
            Random random = new Random();
            int n = ListTiles.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Tile tmp_tile = ListTiles[k];
                ListTiles[k] = ListTiles[n];
                ListTiles[n] = tmp_tile;
            }  
        }

        void SetLocationTiles()
        {
            int k = 0;
            for (int i=0;i<row_matrix;i++)
                for (int j = 0; j < column_matrix; j++)
                {
                    ListTiles[k].SetLocationTiles(LocationPuzzle.X + j * widthTile, LocationPuzzle.Y + i * heightTile);
                    ListTiles[k].x_matrix_current = i;
                    ListTiles[k].y_matrix_current = j;
                    ListTiles[k].prev_location_in_matrix = new Point(i, j);

            //        matrix[i, j].coord_x_tile = ListTiles[k].x_matrix_baseimage;
           //         matrix[i, j].coord_y_tile = ListTiles[k].y_matrix_baseimage;
           //         if (i==)
                    k++;
                }
                          
        }
    }
}
