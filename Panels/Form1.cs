using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Panels.Views;

namespace Panels
{
    public partial class Form1 : Form
    {
        private Zeitarbeit register;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bt_registration_Click(object sender, EventArgs e)
        {
            register = new Zeitarbeit();
            register.Show();
            this.Hide();
        }
    }
}
