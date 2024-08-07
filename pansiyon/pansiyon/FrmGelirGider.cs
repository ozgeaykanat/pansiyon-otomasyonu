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

namespace pansiyon
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=OZGE\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int personel;
            if (int.TryParse(textBox1.Text, out personel))
            {
                lblMaas.Text = (personel * 1000).ToString();
            }

            int sonuc;
            sonuc = Convert.ToInt32(LblKasa.Text) - (Convert.ToInt16(lblMaas.Text) + Convert.ToInt16(LblAlınanürün1.Text) + Convert.ToInt16(LblAlınanürün2.Text) + Convert.ToInt16(LblAlınanürün3.Text) + Convert.ToInt16(lblElektrik.Text) + Convert.ToInt16(lblSu.Text) + Convert.ToInt16(lblİnternet.Text));
            lblsonuç.Text = sonuc.ToString();
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT sum(ücret) as toplam from MüsteriEkle ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                LblKasa.Text = oku["toplam"].ToString();
            }
            baglanti.Close();

            //stokların giderleri
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT sum(gida) as toplam1,sum(içecek) as toplam2,sum(cerezler) as toplam3 from Stoklar ", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                LblAlınanürün1.Text = oku2["toplam1"].ToString();
                LblAlınanürün2.Text = oku2["toplam2"].ToString();
                LblAlınanürün3.Text = oku2["toplam3"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3=new SqlCommand("select sum(elektrik) as toplam4,sum(su) as toplam5,sum(internet) as  toplam6 from Faturalar",baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                lblElektrik.Text = oku3["toplam4"].ToString();
                lblSu.Text = oku3["toplam5"].ToString();
                lblİnternet.Text = oku3["toplam6"].ToString() ;
            }
            baglanti.Close();   


        }
    }
}
