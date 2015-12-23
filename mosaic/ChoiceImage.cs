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
    public partial class ChoiceImage : Form
    {
        Main_menu menu;
        public ChoiceImage(Main_menu menu_)
        {
            InitializeComponent();
            menu = menu_;
        }

        private void button1_Click(object sender, EventArgs e)
        {

                menu.playing_zone.puzzle.ImagePuzzle = this.button1.BackgroundImage;
                menu.playing_zone.BaseImage.BackgroundImage = this.button1.BackgroundImage;
                menu.choice_image = true;

      //      this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

                menu.playing_zone.puzzle.ImagePuzzle = this.button2.BackgroundImage;
                menu.playing_zone.BaseImage.BackgroundImage = this.button2.BackgroundImage;
                menu.choice_image = true;

      //      this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            menu.playing_zone.puzzle.ImagePuzzle = this.button3.BackgroundImage;
            menu.playing_zone.BaseImage.BackgroundImage = this.button3.BackgroundImage;
            menu.choice_image = true;
      //      this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu.playing_zone.puzzle.ImagePuzzle = this.button4.BackgroundImage;
            menu.playing_zone.BaseImage.BackgroundImage = this.button4.BackgroundImage;
            menu.choice_image = true;
      //      this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu.playing_zone.puzzle.ImagePuzzle = this.button5.BackgroundImage;
            menu.playing_zone.BaseImage.BackgroundImage = this.button5.BackgroundImage;
            menu.choice_image = true;
     //       this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu.playing_zone.puzzle.ImagePuzzle = this.button6.BackgroundImage;
            menu.playing_zone.BaseImage.BackgroundImage = this.button6.BackgroundImage;
            menu.choice_image = true;
     //       this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            menu.playing_zone.puzzle.ImagePuzzle = this.button7.BackgroundImage;
            menu.playing_zone.BaseImage.BackgroundImage = this.button7.BackgroundImage;
            menu.choice_image = true;
     //       this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            menu.playing_zone.puzzle.ImagePuzzle = this.button8.BackgroundImage;
            menu.playing_zone.BaseImage.BackgroundImage = this.button8.BackgroundImage;
            menu.choice_image = true;
     //       this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
