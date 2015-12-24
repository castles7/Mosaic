using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mosaic
{
    public class Main_menu
    {
        List<Button> buttons = new List<Button>();
        string[] NamesButton = new String[3] { "Новая игра", "Выбрать уровень сложности", "Выход" };

        public Form form;
        public PlayingZone playing_zone;
        PictureBox ImageMenu;
        Graphics _gr;
        Bitmap _bitmap;

        int active_window;
        public bool begin_menu = true;
        public bool begin_play_field = true;

        public int ActiveWindow
        {
            set { active_window = value; }
            get { return active_window; }
        }

        public Main_menu(Form form_)
        {

            form = form_;
            active_window = 0;

            ImageMenu = new PictureBox();
            ImageMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            ImageMenu.Location = new Point(0, 27);
        }

        void CreateListOfButton()
        {
            for (int i = 0; i < 3; i++)
            {
                Button newButton = new Button();

                newButton.Location = new Point(form.Width / 3 * 2 - 50, i * form.Height / 4 + 100);
                newButton.AutoSize = true;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.FlatStyle = FlatStyle.Flat;
                newButton.Text = NamesButton[i];
                newButton.Font = new Font("Comic sans ms", 16);
                newButton.UseVisualStyleBackColor = false;
                newButton.BackColor = Color.FromArgb(0);


                newButton.Image = Image.FromFile("C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\button.png");
                switch (i)
                {
                    case 0:
                        newButton.Click += new System.EventHandler(button1_Click);
                        break;
                    case 1:
                        newButton.Click += new System.EventHandler(button2_Click);
                        break;
                    case 2:
                        newButton.Click += new System.EventHandler(button3_Click); // button1_Click - функция обработчик события нажатия на кнопку
                        break;
                }
                buttons.Add(newButton);
            }
        }


        //public void ChangeLocation()
        //{
        //    picturebox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        //        | System.Windows.Forms.AnchorStyles.Left)
        //        | System.Windows.Forms.AnchorStyles.Right)));

        //    for (int i = 0; i < buttons.Count; i++)
        //    {
        //        buttons[i].Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        //        | System.Windows.Forms.AnchorStyles.Left)
        //        | System.Windows.Forms.AnchorStyles.Right)));
        //    }
        //}

        public void Draw()
        {
            ImageMenu.Image = Image.FromFile("C:\\Users\\Администратор\\Documents\\Александра\\Учеба\\3 курс\\5 семестр\\техн.программ\\Картинки\\menu.jpg");
            ImageMenu.SizeMode = PictureBoxSizeMode.StretchImage;

            ImageMenu.Width = form.Width - 16;
            ImageMenu.Height = form.Height - 65;
     //       picturebox1.Location = new Point(form.Location.X, form.Location.Y + 27);
          //         picturebox1.Layout = form.Layout;
            form.Controls.Add(ImageMenu);


            CreateListOfButton();
            for (int i = 0; i < buttons.Count; i++)
            {
                form.Controls.Add(buttons[i]);
                ImageMenu.Controls.Add(buttons[i]);
            }

            _bitmap = new Bitmap(ImageMenu.Width, ImageMenu.Height);
             
            _gr = Graphics.FromImage(_bitmap);
            _gr.Clear(Color.White);


            Label label = new Label();
            Font FontHead = new Font("Comic sans ms", 80);
            label.Location = new Point((int)(form.Width * 0.16), (int)(form.Height* 0.16));
            label.AutoSize = true;
            label.ForeColor = Color.Blue;
            label.Font = FontHead;
            label.Text = "Мозаика";
            label.FlatStyle = FlatStyle.Flat;

            label.BackColor = Color.FromArgb(0);


            form.Controls.Add(label);
            ImageMenu.Controls.Add(label);


        }

        public void Clear()
        {
            ImageMenu.Controls.Clear();
      //      picturebox1.Image = null;
            form.Controls.Remove(ImageMenu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            active_window = 1;
            if (begin_play_field == true)
            {
                Clear();
                begin_play_field = false;
            }

            playing_zone.Draw();
            form.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            active_window = 2;
            form.Close();
        }

    }
        
    
}
