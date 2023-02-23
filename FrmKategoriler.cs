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
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-16VPERV;Initial Catalog=SatisVeriTabani;Integrated Security=True");    
        private void btn_listele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TBLKATEGORI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void bn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Insert into TBLKATEGORI(KAtEGORIAD) values(@p1)",baglanti);
            komut2.Parameters.AddWithValue("p1", txt_kategoriad.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Kaydedildi");

        }

        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            // txt_kategoriid.Text=e.RowIndex.ToString();
            txt_kategoriid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); //DataGridView'in satırları içerisinde seçmiş olduğumuz satırın indexine göre
                                                                                            //bu satırda bulunan hücrelerden 0 nolu hücreyi string olarak yazdır
            txt_kategoriad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete From TBLKATEGORI where KATEGORIID=@p1",baglanti);
            komut3.Parameters.AddWithValue("@p1", txt_kategoriid.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Silindi");            
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {   
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update TBLKATEGORI set KATEGORIAD=@p1 where KATEGORIID=@p2",baglanti);
            komut4.Parameters.AddWithValue("@p1", txt_kategoriad.Text);
            komut4.Parameters.AddWithValue("@p2", txt_kategoriid.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Güncellendi");


        }
    }
}
