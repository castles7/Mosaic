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
        public Form form;

        PictureBox BackGround;
        PictureBox BaseImage;
        PictureBox PuzzlesPlace;

        Panel panel;

        List<CheckBox> buttons = new List<CheckBox>();
        string[] ImageButton = new String[3] { "C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\масштаб(+).png",
                                               "C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\масштаб(-).png",
                                               "C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\рука.png"};

        public PlayingZone(Form form_)
        {
            InitializeComponent();

            form = form_;

            BackGround = new PictureBox();
            BaseImage = new PictureBox();
            PuzzlesPlace = new PictureBox();
            panel = new Panel();


            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));


            BackGround.Location = new Point(0, 27);

            PuzzlesPlace.Location = new Point((int)(BackGround.Width * 9), (int)(BackGround.Height * 5));
            PuzzlesPlace.Width = 20;
            PuzzlesPlace.Height = 20;

            panel.Location = new Point((int)(BackGround.Width * 9), (int)(BackGround.Height * 4.45));
            panel.Width = 415;
            panel.Height = 385;

            BaseImage.Location = new Point((int)(BackGround.Width * 9.60), (int)(BackGround.Height * 1));
            BaseImage.Width = 300;
            BaseImage.Height = 153;
            BaseImage.BorderStyle = BorderStyle.Fixed3D;
            this.Location = new Point((int)(BackGround.Width * 0.3), (int)(BackGround.Height * 1.3));

        }


        void CreateListOfButton()
        {
            for (int i = 0; i < 3; i++)
            {
                int delta = 60;
                CheckBox newButton = new CheckBox();

                newButton.Location = new Point((int)(BackGround.Width * 0.1) + i * delta, (int)(BackGround.Height * 0.1));
                newButton.AutoSize = true;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.FlatStyle = FlatStyle.Flat;
                newButton.Font = new Font("Comic sans ms", 16);
                newButton.UseVisualStyleBackColor = false;
                newButton.BackColor = Color.FromArgb(0);
                newButton.Appearance = Appearance.Button;

                newButton.Image =Image.FromFile(ImageButton[i]);

                buttons.Add(newButton);
            }
        }


        public void Draw()
        {
            if (begin==true)
            {
                CreateListOfButton();
                begin = false;

                for (int i = 0; i < buttons.Count; i++)
                {
                    form.Controls.Add(buttons[i]);
                    BackGround.Controls.Add(buttons[i]);
                }

                BackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)       
                | System.Windows.Forms.AnchorStyles.Right)));

                BaseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
               | System.Windows.Forms.AnchorStyles.Left)
               | System.Windows.Forms.AnchorStyles.Right)));

                PuzzlesPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

                panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

                BackGround.Image = Image.FromFile("C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\background_plaing zone.jpg");
                BackGround.SizeMode = PictureBoxSizeMode.StretchImage;

                this.BackColor = Color.LavenderBlush;
                this.BorderStyle = BorderStyle.Fixed3D;
                panel.BackColor = Color.LavenderBlush;
               // BaseImage.BackColor = Color.Coral;

                BackGround.Width = form.Width - 16;
                BackGround.Height = form.Height - 65;


                BackGround.Controls.Add(BaseImage);
                form.Controls.Add(BaseImage);

                VScrollBar vScroller = new VScrollBar();
                vScroller.Height = panel.Height;
                vScroller.Dock = DockStyle.Right;
                panel.BorderStyle = BorderStyle.Fixed3D;
                panel.Controls.Add(vScroller);

             //   BackGround.Controls.Add(PuzzlesPlace);
             //   form.Controls.Add(PuzzlesPlace);
             //   PuzzlesPlace.BackColor = Color.PaleGoldenrod;
                PuzzlesPlace.SizeMode = PictureBoxSizeMode.AutoSize;
           //     PuzzlesPlace.BorderStyle = BorderStyle.Fixed3D;
            //    panel.Controls.Add(PuzzlesPlace);

               


            //    form.Controls.Add(PuzzlesPlace);
              //  panel.Controls.Add(PuzzlesPlace);
               // panel.AutoScroll = true;
                form.Controls.Add(panel);
                BackGround.Controls.Add(panel);

             //   vScroller
           //     vScroller.AutoScrollOffset = true;

            //    PuzzlesPlace.BackColor = Color.Bisque;
            //    PuzzlesPlace.Image = Image.FromFile("C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\background_plaing zone.jpg");
              //  panel.
               // panel.ScrollBars = ScrollBars.Vertical;
                form.Controls.Add(this);
                BackGround.Controls.Add(this);

               // form.Controls.Ad
                //Tile tile = new Tile();
                //Image image = Image.FromFile("C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\7172758.jpg");
                //tile.DrawImageOfTiles(image,0,0,60,30);
         //       PuzzlesPlace.Controls.Add(tile.picture);
               // til
            }


        }

        private void PlayingZone_Load(object sender, EventArgs e)
        {

        }
    }
}
