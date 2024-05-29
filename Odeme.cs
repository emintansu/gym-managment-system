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
    public partial class Odeme : Form
    {
        private string server = "localhost";
        private string database = "spordb";
        private string username = "root";
        private string password = "";
        private MySqlConnection conn;
        public Odeme()
        {
            InitializeComponent();
            conn = new MySqlConnection($"Server={server};Database={database};Uid={username};Pwd={password};");

        }
        private void Fillname()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Uadsoyad FROM user", conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Uadsoyad", typeof(string));
                dt.Load(dr);
                adsoyad.ValueMember = "Uadsoyad";
                adsoyad.DataSource = dt;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void uyeler()
        {
            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            string query = "SELECT * FROM odeme";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds); // Veri çekme işlemi
                    odemedatagridwiew.DataSource = ds.Tables[0]; // DataGridView kontrolünü doldur
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
        private void adfilter()
        {
            if (arat.Text.Length == 0)
            {
                MessageBox.Show("Arama metni giriniz");
                return;
            }

            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            string query = "SELECT * FROM odeme WHERE Ouye LIKE @oye";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                 
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@oye", "%" + arat.Text + "%");
                   


                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds); // Veri çekme işlemi
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        odemedatagridwiew.DataSource = ds.Tables[0]; // DataGridView kontrolünü doldur
                       
                    }
                    else
                    {
                        MessageBox.Show("Aramanıza uygun veri bulunamadı");
                        odemedatagridwiew.DataSource = null; // DataGridView'i temizle

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }


        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            adsoyad.Text = "";
            tutar.Text = "";
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            Fillname();
            uyeler();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (adsoyad.Text.Length == 0 || tutar.Text.Length == 0)
            {
                MessageBox.Show("eksik bilgi");
            }
            else
            {
                // Doğru zaman formatını kullanarak string oluşturma
                string odemeperiyot = odemeperiyot1.Value.Month.ToString() + odemeperiyot1.Value.Year.ToString();

                try
                {
                    conn.Open();
                    // Doğru COUNT kullanımı
                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM odeme WHERE Ouye = @oye AND Oay = @oay", conn);
                    cmd.Parameters.AddWithValue("@oye", adsoyad.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@oay", odemeperiyot);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Zaten ödeme yapıldı");
                    }
                    else
                    {
                        // Parametreli sorgu kullanarak güvenliği artırma
                        string query = "INSERT INTO odeme (Ouye, Oay, Omiktar) VALUES (@oye, @oay, @otutar)";
                        MySqlCommand insertCmd = new MySqlCommand(query, conn);
                        insertCmd.Parameters.AddWithValue("@oye", adsoyad.SelectedValue.ToString());
                        insertCmd.Parameters.AddWithValue("@oay", odemeperiyot);
                        insertCmd.Parameters.AddWithValue("@otutar", tutar.Text);

                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("Tutar başarıyla ödendi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    uyeler();
                }
            }
        }

      

        private void yenile_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void ara_Click(object sender, EventArgs e)
        {
            adfilter();
        }
    }
}
