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
    public partial class uyeEkle : Form
    {
        // Sunucu bilgilerini burada tanımlayın
        private string server = "localhost";
        private string database = "spordb";
        private string username = "root";
        private string password = "";

        public uyeEkle()
        {
            InitializeComponent();
        }

        // MySQL bağlantısını kontrol eden fonksiyon
        public void CheckMySQLConnection()
        {
            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Bağlantı başarılı!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message);
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            // Bağlantı kontrolünü burada yapın
            CheckMySQLConnection();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            // Bu işleyici boş görünüyor, işlevsellik ekleyebilirsiniz
        }

        private void uyeEkle_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (adsoyad.Text == "" || telefon.Text == "" || yas.Text == "" || cinsiyet.Text == "" || tutar.Text == "" || zamanlama.Text == "")
            {
                MessageBox.Show("Eksik bilgi");
            }
            else
            {
                string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        string query = "INSERT INTO user (Uadsoyad, Utelefon, Ucinsiyet, Uyas, Uodeme, Uzamanlama) VALUES (@Uadsoyad, @Utelefon, @Ucinsiyet, @Uyas, @Uodeme, @Uzamanlama)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Parametreleri ekle
                            cmd.Parameters.AddWithValue("@Uadsoyad", adsoyad.Text);
                            cmd.Parameters.AddWithValue("@Utelefon", telefon.Text);
                            cmd.Parameters.AddWithValue("@Ucinsiyet", cinsiyet.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Uyas", yas.Text);
                            cmd.Parameters.AddWithValue("@Uodeme", tutar.Text);
                            cmd.Parameters.AddWithValue("@Uzamanlama", zamanlama.SelectedItem.ToString());

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Üye başarıyla eklendi!");
                            adsoyad.Text = "";
                            telefon.Text = "";
                            yas.Text = "";
                            cinsiyet.Text = "";
                            tutar.Text = "";
                            zamanlama.Text = "";
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Bağlantı hatası: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bilinmeyen hata: " + ex.Message);
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            adsoyad.Text = "";
            telefon.Text = "";
            yas.Text = "";
            cinsiyet.Text = "";
            tutar.Text = "";
            zamanlama.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}




