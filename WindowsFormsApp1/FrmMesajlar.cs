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
    public partial class FrmMesajlar : Form
    {
        public FrmMesajlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-414DTKK\SQLEXPRESS;Initial Catalog=Pansiyon;Integrated Security=True");

        private void verilergoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Mesajlar ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Mesajid"].ToString();
                ekle.SubItems.Add(oku["AdıSoyadı"].ToString());
                ekle.SubItems.Add(oku["Mesaj"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }


        private void FrmMesajlar_Load(object sender, EventArgs e)
        {
            verilergoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Mesajlar(AdıSoyadı,Mesaj) values ('" + TxtAdiSoyadi.Text + "','" + rchtxtMesaj.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilergoster();
        }
        int id = 0;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdiSoyadi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            rchtxtMesaj.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }
    }
}
