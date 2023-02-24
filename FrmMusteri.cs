using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Sql_DB
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0CRKMBG;Initial Catalog=SatisVeriVT;Integrated Security=True");

        void Listele()
        {
            SqlCommand komut = new SqlCommand("Select * From TBLMUSTERI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            Listele();

            //Şimdi de şehirleri çekelim
            //baglanti.Open();
            //SqlCommand komut1 = new SqlCommand("Select * FROM TBL_SEHIRLER ",baglanti);
            //SqlDataReader dr = komut1.ExecuteReader();
            //while (dr.Read())
            //{
            //    cbx_sehir.Items.Add(dr["SEHIRAD"]);
            //}
            //baglanti.Close();
            
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbx_sehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_bakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void bn_kaydet_Click(object sender, EventArgs e)
        {
          baglanti.Open();
          SqlCommand komut = new SqlCommand("Insert INTO TBLMUSTERI (MUSTERIAD,MUSTERISOYAD,MUSTERISEHIR,MUSTERIBAKIYE) values (@x2,@x3,@x4,@x5)", baglanti);
            
            komut.Parameters.AddWithValue("@x2",txt_ad.Text);
            komut.Parameters.AddWithValue("@x3",txt_soyad.Text);
            komut.Parameters.AddWithValue("@x4", cbx_sehir.Text);
            komut.Parameters.AddWithValue("@x5",txt_bakiye.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Edildi");
            Listele();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from TBLMUSTERI where MUSTERIID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_id.Text);
            komut.ExecuteNonQuery();
            Listele();
            MessageBox.Show("Silme İşlemi Yapıldı");
            baglanti.Close();



        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("UPDATE TBLMUSTERI set MUSTERIAD=@p2,MUSTERISOYAD=@p3,MUSTERISEHIR=@p4,MUSTERIBAKIYE=@p5 where MUSTERIID=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1",txt_id.Text);
            komut.Parameters.AddWithValue("@p2",txt_ad.Text);
            komut.Parameters.AddWithValue("@p3",txt_soyad.Text);
            komut.Parameters.AddWithValue("@p4",cbx_sehir.Text);
            komut.Parameters.AddWithValue("@p5",txt_bakiye.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("güncellendi");
            Listele();
        
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            //SqlCommand komut = new SqlCommand("Select * From TBLMUSTERI where MUSTERIAD=@p1",baglanti); //Normal Arama Komutu 
           //SqlCommand komut = new SqlCommand("Select * From TBLMUSTERI where MUSTERIAD LIKE @p1+ '%'", baglanti); //İlk Harfte Arayabilmek İçin

           // komut.Parameters.AddWithValue("@p1",txt_ad.Text);
           // SqlDataAdapter da=new SqlDataAdapter(komut);
           // DataTable dt = new DataTable();
           // da.Fill(dt);    
           // dataGridView1.DataSource = dt;     
            
           
        }

       
    }
}
