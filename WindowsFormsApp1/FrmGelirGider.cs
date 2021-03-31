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


namespace WindowsFormsApp1
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-414DTKK\SQLEXPRESS;Initial Catalog=Pansiyon;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int personel;
            personel = Convert.ToInt32(textBox1.Text);
            lblPersonelMaas.Text = (personel * 2000).ToString();

            int sonuc;
            sonuc = (Convert.ToInt32(lblKasaToplam.Text) - Convert.ToInt32(lblPersonelMaas.Text) + Convert.ToInt32(lblAlinanUrunler1.Text) + Convert.ToInt32(lblAlinanUrunler2.Text) + Convert.ToInt32(lblAlinanUrunler3.Text) + Convert.ToInt32(lblFaturalar1.Text) + Convert.ToInt32(lblFaturalar2.Text) + Convert.ToInt32(lblFaturalar3.Text));
            lblSonuc.Text = sonuc.ToString();
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            //Kasadaki Toplam tutar
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Sum (Ucret) as toplam from musteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblKasaToplam.Text = oku["toplam"].ToString();
            }
            baglanti.Close();
            //Gıdalar
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select Sum (Gida) as toplam1 from AlinanUrunler", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                lblAlinanUrunler1.Text = oku2["toplam1"].ToString();
            }
            baglanti.Close();
            //İçecek
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select Sum (Icecek) as toplam2 from AlinanUrunler", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lblAlinanUrunler2.Text = oku3["toplam2"].ToString();
            }
            baglanti.Close();
            //Çerezler
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select Sum (Cerezler) as toplam3 from AlinanUrunler", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lblAlinanUrunler3.Text = oku4["toplam3"].ToString();
            }
            baglanti.Close();
            //Elektrik
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select Sum (Elektrik) as toplam4 from Faturalar", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                lblFaturalar1.Text = oku5["toplam4"].ToString();
            }
            baglanti.Close();
            //Su
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select Sum (Su) as toplam5 from Faturalar", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                lblFaturalar2.Text = oku6["toplam5"].ToString();
            }
            baglanti.Close();
            //İnternet
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select Sum (İnternet) as toplam6 from Faturalar", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                lblFaturalar3.Text = oku7["toplam6"].ToString();
            }
            baglanti.Close();

        }
    }
}
