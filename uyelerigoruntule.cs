using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gym_managmentsystem
{
    public partial class uyelerigoruntule : Form
    {
        private string server = "localhost";
        private string database = "spordb";
        private string username = "root";
        private string password = "";
        public uyelerigoruntule()
        {
            InitializeComponent();
        }

        private void uyelerigoruntule_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        private void uyeler()
        {
            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            string query = "SELECT * FROM user";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds); // Veri çekme işlemi
                    uyegoruntule.DataSource = ds.Tables[0]; // DataGridView kontrolünü doldur
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }
        private void adfilter()
        {
            if (textbox.Text.Length == 0)
            {
                MessageBox.Show("Arama metni giriniz");
                return;
            }

            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            string query = "SELECT * FROM user WHERE Uadsoyad LIKE @searchValue"; // Uadsoyad sütununda filtreleme

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchValue", "%" + textbox.Text + "%"); // LIKE kullanarak arama

                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds); // Veri çekme işlemi
                    uyegoruntule.DataSource = ds.Tables[0]; // DataGridView kontrolünü doldur
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            adfilter();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void uyegoruntule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


