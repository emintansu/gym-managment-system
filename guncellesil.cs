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
    public partial class guncellesil : Form

    {
        public guncellesil()
        {
            InitializeComponent();
        }
        private string server = "localhost";
        private string database = "spordb";
        private string username = "root";
        private string password = "";
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
                    uyegoruntule1.DataSource = ds.Tables[0]; // DataGridView kontrolünü doldur
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek öğeyi seçiniz.");
            }
            else
            {
                // Bağlantı dizgisini oluşturma
                string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // MySQL bağlantısını aç
                    try
                    {
                        string query = "DELETE FROM user WHERE iduser = @Key";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Key", key);  // SQL Injection önlemi
                        cmd.ExecuteNonQuery();  // Sorguyu çalıştır ve veritabanını etkileyen satır sayısını döndür
                        MessageBox.Show("Üye başarıyla silindi.");
                        uyeler(); // Listeyi güncelle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }

        private void guncellesil_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }
        int key = 0;
        private void uyegoruntule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(uyegoruntule1.SelectedRows[0].Cells[0].Value.ToString());
            adsoyad.Text = uyegoruntule1.SelectedRows[0].Cells[1].Value.ToString();
            telefon.Text = uyegoruntule1.SelectedRows[0].Cells[2].Value.ToString();
            cinsiyet.Text = uyegoruntule1.SelectedRows[0].Cells[3].Value.ToString();
            yas.Text = uyegoruntule1.SelectedRows[0].Cells[4].Value.ToString();
            tutar.Text = uyegoruntule1.SelectedRows[0].Cells[5].Value.ToString();
            zamanlama.Text = uyegoruntule1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            adsoyad.Text = "";
            telefon.Text = "";
            cinsiyet.Text = "";
            yas.Text = "";
            tutar.Text = "";
            zamanlama.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (key == 0|| adsoyad.Text == "" || telefon.Text == "" || yas.Text == "" || cinsiyet.Text == "" || tutar.Text == "" || zamanlama.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                // Bağlantı dizgisini oluşturma
                string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // MySQL bağlantısını aç
                    try
                    {
                        string query = "update user set Uadsoyad='"+adsoyad.Text+ "',Utelefon='"+telefon.Text+"',Ucinsiyet='"+cinsiyet.Text+"',Uyas='"+yas.Text+ "',Uodeme='"+tutar.Text+ "',Uzamanlama='"+zamanlama.Text+"' where iduser = "+key+";";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Key", key);  // SQL Injection önlemi
                        cmd.ExecuteNonQuery();  // Sorguyu çalıştır ve veritabanını etkileyen satır sayısını döndür
                        MessageBox.Show("Üye başarıyla guncellendi.");
                        uyeler(); // Listeyi güncelle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }
    }
}
