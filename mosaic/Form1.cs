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
        public PlayingZone playing_zone;

        public Form1()
        {          
            InitializeComponent();

            menu = new Main_menu(this);
            playing_zone = new PlayingZone(this);
            menu.playing_zone = playing_zone;
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
        






    }
}
