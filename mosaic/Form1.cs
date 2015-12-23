using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mosaic
{
    public partial class Form1 : Form
    {
        public Main_menu menu;

        public Form1()
        {          
            InitializeComponent();
            menu = new Main_menu();
        }   
        
        private void Form1_Load(object sender, EventArgs e)
        {                      
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            switch (menu.ActiveWindow)
            {
                case 0:
                    {
                        if (menu.begin_menu== true)
                        {
                            menu.Draw();
                            menu.begin_menu = false;
                        }
                      
                    }
                    break;

                case 1:
                    {
                      
                    }
                    break;

                case 2:
          //          this.Close();
                    break;
            }
           
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //switch (menu.ActiveWindow)
            //{
            //case 0:
            //        {
            //         //   menu.ChangeLocation();
                      
            //        }
            //        break;

            //    case 1:
            //        {
            //           menu.Draw();
            //        }
            //        break;

            //    case 2:
            //        this.Close();
            //        break;
            //}
        }

        private void выбратьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.MainForm.menu.ActiveWindow != 1)
            {
                ChoiceImage choice_image = new ChoiceImage(menu);
                choice_image.Owner = Program.MainForm;
                choice_image.ShowDialog();
            }
        }

        private void загрузитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.MainForm.menu.ActiveWindow != 1)
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                string FileName = OFD.FileName;
                if (FileName != "")
                {
                    menu.playing_zone.puzzle.ImagePuzzle = Image.FromFile(FileName);
                    menu.playing_zone.BaseImage.BackgroundImage = Image.FromFile(FileName);
                    menu.choice_image = true;
                }
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void начатьНовуюИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Controls.Remove(menu.playing_zone.BackGround);
            this.Controls.Remove(menu.playing_zone.BaseImage);
            this.Controls.Remove(menu.playing_zone);
            for (int i = 0; i < menu.playing_zone.buttons.Count;i++)
                this.Controls.Remove(menu.playing_zone.buttons[i]);
            menu = new Main_menu();
            menu.begin_menu = true;
        
        }
        






    }
}
