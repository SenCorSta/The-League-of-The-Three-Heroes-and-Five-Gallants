using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ICeRPGgame
{
    public partial class info : Form
    {
        public info(ArrayList al)
        {
            InitializeComponent();
            this.richTextBox1.Text = Convert.ToString(al[11]);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
