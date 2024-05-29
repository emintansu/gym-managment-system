namespace gym_managmentsystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            kullanicitext.Text = "";
            kullanicisifre.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(kullanicitext.Text == ""|| kullanicisifre.Text == "")
            {
                MessageBox.Show("bos alan var");
            }
            else if(kullanicitext.Text == "admin"&& kullanicisifre.Text=="123")
            {
                anasayfa anasayfa = new anasayfa(); 
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("yanlis kullanici adi veya sifre");
            }
        }
    }
}
