﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MesajProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-32Q9FH5;Initial Catalog=DbMesajlasma;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

        private void btngiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLKISILER where NUMARA=@p1 and SIFRE=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", msktxtnumara.Text);
            komut.Parameters.AddWithValue("@p2", txtsıfre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm=new Form2();
                frm.lblnumara.Text = msktxtnumara.Text;
                frm.lbladsoyad.Text = dr[1]+" "+dr[2];
                frm.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Numara veya Sifre", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
    }
}
