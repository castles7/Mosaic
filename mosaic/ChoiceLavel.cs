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
    public partial class ChoiceLavel : Form
    {
        Main_menu main_form;
        
        public ChoiceLavel(Main_menu menu_)
        {
            InitializeComponent();
            main_form = menu_;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            main_form.playing_zone.puzzle.row_matrix = 4;
            main_form.playing_zone.puzzle.column_matrix = 5;
            main_form.choice_level = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            main_form.playing_zone.puzzle.row_matrix = 5;
            main_form.playing_zone.puzzle.column_matrix = 6;
            main_form.choice_level = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            main_form.playing_zone.puzzle.row_matrix = 5;
            main_form.playing_zone.puzzle.column_matrix = 8;
            main_form.choice_level = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
