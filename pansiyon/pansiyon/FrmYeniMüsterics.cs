using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace pansiyon
{
    public partial class FrmYeniMüsterics : Form
    {
        public FrmYeniMüsterics()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=OZGE\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        
        private void btnOda101_Click(object sender, EventArgs e)
        {
            txtOda.Text = "101";

        }

        private void btnOda102_Click(object sender, EventArgs e)
        {
            txtOda.Text = "102";
        }

        private void btnOda103_Click(object sender, EventArgs e)
        {
            txtOda.Text = "103";
        }

        private void btnOda104_Click(object sender, EventArgs e)
        {
            txtOda.Text="104";
        }

        private void btnOda105_Click(object sender, EventArgs e)
        {
            txtOda.Text = "105";
        }

        private void btnOda106_Click(object sender, EventArgs e)
        {
            txtOda.Text = "106";

        }

        private void btnOda107_Click(object sender, EventArgs e)
        {
            txtOda.Text = "107";
        }

        private void btnOda108_Click(object sender, EventArgs e)
        {
            txtOda.Text = "108";
        }

        private void btnOda109_Click(object sender, EventArgs e)
        {
            txtOda.Text = "109";
        }

        private void btnBos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil renk buton odanın boş olduğunu gösterir");
        }

        private void btnDolu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı renk buton odanın dolu olduğunu gösterir.");
        }

        private void dtpCikis_ValueChanged(object sender, EventArgs e)
        {
            int Ucret;
            DateTime KucukTarih = Convert.ToDateTime(dtpGiris.Text);
            DateTime BuyukTarih = Convert.ToDateTime(dtpCikis.Text);

            TimeSpan Sonuc;
            Sonuc = BuyukTarih - KucukTarih;
            label11.Text = Sonuc.TotalDays.ToString();

            Ucret = Convert.ToInt32(label11.Text) * 100;
            txtUcret.Text = Ucret.ToString();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("Insert into MüsteriEkle (adi,soyadi,cinsiyet,telefon,mail,tc,odaNo,ücret,giristarihi,cikistarihi) values ('" + txtAd.Text + "','" + txtSoyadı.Text + "','" + cmbCinsiyet.Text + "','"+mskTel.Text+"','"+txtMail.Text+"','"+txtTc.Text+"','"+txtOda.Text+"','"+txtUcret.Text+"','"+dtpGiris.Value.ToString("yyyy-MM-dd")+"','"+dtpCikis.Value.ToString("yyyy-MM-dd")+"')", baglanti);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri kaydı yapıldı");
        }

        private void FrmYeniMüsterics_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Oda101", baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                btnOda101.Text = oku1["adi"].ToString() + " " + oku1["soyadi"].ToString();
            }
            baglanti.Close();
            if (btnOda101.Text != "101")
            {
                btnOda101.BackColor = Color.Red;

            }

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Oda105", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                btnOda105.Text = oku2["adi"].ToString() + " " + oku2["soyadi"].ToString();
            }
            baglanti.Close();

            if (btnOda105.Text != "105")
            {
                btnOda105.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from Oda106", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                btnOda106.Text = oku3["adi"].ToString() + " " + oku3["soyadi"].ToString();
            }
            baglanti.Close();
            if (btnOda106.Text != "106")
            {
                btnOda106.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select * from Oda107", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                btnOda107.Text = oku4["adi"].ToString() + " " + oku4["soyadi"].ToString();
            }
            baglanti.Close();
            if (btnOda107.Text != "107")
            {
                btnOda107.BackColor = Color.Red;
            }

        }
    }
}
