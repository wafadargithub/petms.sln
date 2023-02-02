using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PETMS
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
        int startp = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startp += 1;
            MyProgress.Value = startp;
            PercentageLbl.Text = startp + "%";
            if(MyProgress.Value == 99)
            {
                MyProgress.Value = 0;
                login Obj = new login();
                Obj.Show();
                this.Hide();
                timer1.Stop();
            }
        }
    }
}
