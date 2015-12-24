using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mosaic
{
    public partial class PlayingZone : UserControl
    {
        bool begin=true;
        public PictureBox BackGround;

        public PictureBox BaseImage;
        public Puzzle puzzle;
        public List<CheckBox> buttons = new List<CheckBox>();
        string[] ImageButton = new String[2] { "C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\масштаб(+).png",
                                               "C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\масштаб(-).png"};

        public PlayingZone()
        {
            InitializeComponent();
            BackGround = new PictureBox();

            BaseImage = new PictureBox();
            BaseImage.BackgroundImageLayout = ImageLayout.Stretch;
            puzzle = new Puzzle();
            this.AutoScroll = true;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            BackGround.Location = new Point(0, 27);

            BaseImage.Location = new Point((int)(BackGround.Width * 0.3), (int)(BackGround.Height * 1.9));
            BaseImage.Width = 300;
            BaseImage.Height = 153;
            BaseImage.BorderStyle = BorderStyle.Fixed3D;
            this.Location = new Point((int)(BackGround.Width * 0.3), (int)(BackGround.Height * 1.3));
        }


        //void CreateListOfButton()
        //{
        //    for (int i = 0; i < 2; i++)
        //    {
        //        int delta = 60;
        //        CheckBox newButton = new CheckBox();

        //        newButton.Location = new Point((int)(BackGround.Width * 0.1) + i * delta, (int)(BackGround.Height * 0.1));
        //        newButton.AutoSize = true;
        //        newButton.FlatAppearance.BorderSize = 0;
        //        newButton.FlatStyle = FlatStyle.Flat;
        //        newButton.Font = new Font("Comic sans ms", 16);
        //        newButton.UseVisualStyleBackColor = false;
        //        newButton.BackColor = Color.FromArgb(0);
        //        newButton.Appearance = Appearance.Button;

        //        newButton.Image =Image.FromFile(ImageButton[i]);

        //        switch (i)
        //        {
        //            case 0:
        //                newButton.Click += new System.EventHandler(button1_Click);
        //                break;
        //            case 1:
        //                newButton.Click += new System.EventHandler(button2_Click);
        //                break;                    
        //        }

        //        buttons.Add(newButton);
        //    }
        //}


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i <puzzle.ListTiles.Count; i++)
        //    {
        //        puzzle.ListTiles[i].picture.Width = (int)(puzzle.ListTiles[i].picture.Width * 2);
        //        puzzle.ListTiles[i].picture.Width = (int)(puzzle.ListTiles[i].picture.Height * 2);
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
        }


        public void Draw()
        {
            if (begin==true)
            {
               // CreateListOfButton();
                begin = false;

                for (int i = 0; i < buttons.Count; i++)
                {
                    Program.MainForm.Controls.Add(buttons[i]);
                    BackGround.Controls.Add(buttons[i]);
                }

                BackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)       
                | System.Windows.Forms.AnchorStyles.Right)));

                BackGround.BackgroundImage = Image.FromFile("C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\background_plaing zone.jpg");
                BackGround.SizeMode = PictureBoxSizeMode.StretchImage;

                this.BackColor = Color.LavenderBlush;
                this.BorderStyle = BorderStyle.Fixed3D;

                BackGround.Width = Program.MainForm.Width - 16;
                BackGround.Height = Program.MainForm.Height - 65;


                BackGround.Controls.Add(BaseImage);
                Program.MainForm.Controls.Add(BaseImage);
               
             //   VScrollBar vScroller = new VScrollBar();
            //    vScroller.Dock = DockStyle.Right;
            //    this.Controls.Add(vScroller);

                puzzle.DevideImageIntoTiles();
                for (int i = 0; i < puzzle.ListTiles.Count; i++)
                    this.Controls.Add(puzzle.ListTiles[i].picture);

             //   Tile tile = new Tile();
               // Image image = Image.FromFile("C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\7172758.jpg");
               // tile.DrawImageOfTiles(image, 0, 0, 60, 30);

                BackGround.Controls.Add(this);
                //this.Controls.Add(tile.picture);
                Program.MainForm.Controls.Add(BackGround);

            }


        }

        public void HappyEnd()
        {        
            //      picturebox1.Image = null;
            for (int i = 0; i < puzzle.ListTiles.Count; i++)
                this.Controls.Remove(puzzle.ListTiles[i].picture);
            PictureBox PuzzlePicture = new PictureBox();
            PuzzlePicture.Size = puzzle.SizePuzzle;
            PuzzlePicture.Location = puzzle.LocationPuzzle;
            PuzzlePicture.BackgroundImage = puzzle.ImagePuzzle;
            PuzzlePicture.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(PuzzlePicture);

        }


        private void PlayingZone_Load(object sender, EventArgs e)
        {

        }
    }
}
