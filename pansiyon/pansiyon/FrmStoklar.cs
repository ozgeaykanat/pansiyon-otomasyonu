using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Management.Instrumentation;

namespace pansiyon
{
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=OZGE\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private void veriler()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Stoklar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["gida"].ToString();
                ekle.SubItems.Add(oku["içecek"].ToString());
                ekle.SubItems.Add(oku["cerezler"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void veriler2()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Faturalar", baglanti);
            SqlDataReader oku2= komut2.ExecuteReader();

            while (oku2.Read()) 
            {
                ListViewItem ekle= new ListViewItem();
                ekle.Text = oku2["elektrik"].ToString();
                ekle.SubItems.Add(oku2["su"].ToString());
                ekle.SubItems.Add(oku2["internet"].ToString());
                listView2.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT into Stoklar(gida,içecek,cerezler) values ('" + txtGida.Text + "','" + txtİcecekler.Text + "','" + txtAtistirmaliklar.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close() ;
            veriler() ;
        }

        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            veriler();
            veriler2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open() ;
            SqlCommand komut2= new SqlCommand("INSERT into Faturalar(elektrik,su,internet) values ('" + txtElektrk.Text + "','" + txtsu.Text + "','" + txtİnternet.Text +"')",baglanti);   
            komut2.ExecuteNonQuery();
            baglanti.Close() ;
            veriler2 ();
        }
    }
}
