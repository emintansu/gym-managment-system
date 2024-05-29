using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_managmentsystem
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uyeEkle uye = new uyeEkle();
            uye.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            uyelerigoruntule uyelerigoruntule = new uyelerigoruntule();
            uyelerigoruntule.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guncellesil guncellesil = new guncellesil();
            guncellesil.Show();
            this.Hide();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
