using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pansiyon
{
    public partial class frmMüsteri : Form
    {
        public frmMüsteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=OZGE\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True;TrustServerCertificate=True");

        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from MüsteriEkle",baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read()) { 
                ListViewItem ekle= new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["soyadi"].ToString());
                ekle.SubItems.Add(oku["cinsiyet"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["mail"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                ekle.SubItems.Add(oku["odaNo"].ToString());
                ekle.SubItems.Add(oku["ücret"].ToString());
                ekle.SubItems.Add(oku["giristarihi"].ToString());
                ekle.SubItems.Add(oku["cikistarihi"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }
        private void btnMüsteri_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }
        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id=int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txtAd.Text = listView1.SelectedItems[0].SubItems[1].Text;  
            txtSoyadı.Text = listView1.SelectedItems[0].SubItems[2].Text;  
            cmbCinsiyet.Text = listView1.SelectedItems[0].SubItems[3].Text;
            mskTel.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txtTc.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txtOda.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
            dtpGiris.Text = listView1.SelectedItems[0].SubItems[9].Text;
            dtpCikis.Text = listView1.SelectedItems[0].SubItems[10].Text;
           

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update MüsteriEkle set adi='" + txtAd.Text + "',soyadi='" + txtSoyadı.Text + "',cinsiyet='" + cmbCinsiyet.Text + "',telefon='" + mskTel.Text + "',mail='" + txtMail.Text + "',tc='" + txtTc.Text + "',odaNo='" + txtOda.Text + "',ücret='" + txtUcret.Text + "',giristarihi='" + dtpGiris.Value.ToString("yyyy-MM-dd") + "',cikistarihi='" + dtpCikis.Value.ToString("yyyy-MM-dd") + "'where Musteriid='" + id +"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from MüsteriEkle where Musteriid=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyadı.Clear();
            cmbCinsiyet.Text = "";
            mskTel.Clear();
            txtMail.Text = "";
            txtTc.Clear();
            txtOda.Clear();
            txtUcret.Clear();
            dtpGiris.Text = "";
            dtpCikis.Text = "";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from MüsteriEkle where adi like '%"+textBox1.Text+"%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["soyadi"].ToString());
                ekle.SubItems.Add(oku["cinsiyet"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["mail"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                ekle.SubItems.Add(oku["odaNo"].ToString());
                ekle.SubItems.Add(oku["ücret"].ToString());
                ekle.SubItems.Add(oku["giristarihi"].ToString());
                ekle.SubItems.Add(oku["cikistarihi"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        
        }

    }
}
