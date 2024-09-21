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
using System.Data.SqlClient;

namespace MesajProjesi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-32Q9FH5;Initial Catalog=DbMesajlasma;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

        void gelenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select AD+' '+SOYAD as 'AdSoyad',BASLIK,ICERIK from TBLMESAJLAR\r\ninner join TBLKISILER\r\non TBLMESAJLAR.GONDEREN=TBLKISILER.NUMARA where ALICI=" + lblnumara.Text, baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        void gidenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select AD+' '+SOYAD as 'AdSoyad',BASLIK,ICERIK from TBLMESAJLAR\r\ninner join TBLKISILER\r\non TBLMESAJLAR.ALICI=TBLKISILER.NUMARA where GONDEREN=" + lblnumara.Text, baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gelenkutusu();
            gidenkutusu();
        }

        private void btngonder_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(@"insert into TBLMESAJLAR (GONDEREN,ALICI,BASLIK,ICERIK)values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", lblnumara.Text);
            komut.Parameters.AddWithValue("@p2", msktxtalıcı.Text);
            komut.Parameters.AddWithValue("@p3", txtbaslık.Text);
            komut.Parameters.AddWithValue("@p4", rchtxtmesaj.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Mesaj Başarıyla Gönderilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gelenkutusu();
            gidenkutusu();
        }


    }
}
