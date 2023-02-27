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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) //Kategorilere tıklayınca
        {
            FrmKategoriler fr= new FrmKategoriler();
            fr.Show();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0CRKMBG;Initial Catalog=SatisVeriVT;Integrated Security=True");
        private void btn_musteri_Click(object sender, EventArgs e)
        {
            FrmMusteri fr2=new FrmMusteri();
            fr2.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Ürünlerin Durum Seviyesi

            SqlCommand komut = new SqlCommand("Execute TEST4", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            //Grafiğe Veri Çekme


            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select KATEGORIAD,COunt(*) FROM TBLKATEGORI INNER JOIN TBLURUNLER ON TBLURUNLER.KATEGORI=TBLKATEGORI.KATEGORIID GROUP BY KATEGORIAD ", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select KATEGORIAD,COunt(*) FROM TBLKATEGORI INNER JOIN TBLURUNLER ON TBLURUNLER.KATEGORI=TBLKATEGORI.KATEGORIID GROUP BY KATEGORIAD ", baglanti);
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["MusteriSayisi"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();


        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_urunler_Click(object sender, EventArgs e)
        {

        }
    }
}
