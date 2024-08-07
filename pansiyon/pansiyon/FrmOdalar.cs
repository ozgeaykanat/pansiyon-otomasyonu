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
    public partial class FrmOdalar : Form
    {
        public FrmOdalar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=OZGE\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True;TrustServerCertificate=True");

        private void FrmOdalar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Oda101",baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();
            
            while (oku1.Read())
            {
                btnOda101.Text = oku1["adi"].ToString() + " " + oku1["soyadi"].ToString();
            }
            baglanti.Close();
            if(btnOda101.Text != "101")
            {
                btnOda101.BackColor = Color.Red;

            }

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Oda105",baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read()) 
            {
                btnOda105.Text = oku2["adi"].ToString() + " " + oku2["soyadi"].ToString();
            }
            baglanti.Close();

            if(btnOda105.Text != "105")
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
            if(btnOda106.Text != "106")
            {
                btnOda106.BackColor = Color.Red;
            }

            baglanti.Open ();
            SqlCommand komut4 = new SqlCommand("select * from Oda107", baglanti);
            SqlDataReader oku4= komut4.ExecuteReader();
            while (oku4.Read()) 
            {
                btnOda107.Text = oku4["adi"].ToString() + " " + oku4["soyadi"].ToString();
            }
            baglanti.Close();
            if(btnOda107.Text != "107")
            {
                btnOda107.BackColor = Color.Red;
            }

           
        }
    }
}
