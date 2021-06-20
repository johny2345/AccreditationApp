using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccreditationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnArea1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VMGO showArea1 = new VMGO();
            showArea1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Faculty showArea2 = new Faculty();
            showArea2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Curriculum_and_Insruction showArea3 = new Curriculum_and_Insruction();
            showArea3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Support_to_Students showArea4 = new Support_to_Students();
            showArea4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Extension_and_community_involvement showArea5 = new Extension_and_community_involvement();
            showArea5.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Laboratories showArea8 = new Laboratories();
            showArea8.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administration showArea9 = new Administration();
            showArea9.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Physical_Plant_and_Facilities showArea7 = new Physical_Plant_and_Facilities();
            showArea7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Research showArea6 = new Research();
            showArea6.Show();
        }
    }
}
