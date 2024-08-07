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



namespace pansiyon
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=OZGE\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private void btnAdmin_Click(object sender, EventArgs e)
        {

                        baglanti.Open();
                        string sql = "select * from adminGiris where Kullanici=@Kullaniciadi AND Sifre=@Sifresi ";
                        SqlParameter prm1 = new SqlParameter("Kullaniciadi", txtKullaniciAdi.Text.Trim());
                        SqlParameter prm2 = new SqlParameter("Sifresi", txtAdminSifre.Text.Trim());
                        SqlCommand komut = new SqlCommand(sql, baglanti);
                        komut.Parameters.Add(prm1);
                        komut.Parameters.Add(prm2);

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            FrmAnaSayfa fr = new FrmAnaSayfa();
                            fr.Show();
                        }
                       else 
                       {
                        MessageBox.Show("Hatali giriş");
                        baglanti.Close();
                       }

                    
                }


     }
}
