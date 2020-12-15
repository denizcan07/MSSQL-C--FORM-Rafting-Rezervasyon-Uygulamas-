using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sql komutlarını ve parametrelerini kullanmamızı sağlar.
namespace Stored_deneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=MSI\\SQLEXPRESS02;Initial Catalog=vt;Integrated Security=True;");
        //New connection sınıfından yeni bir nesne üretiyoruz.Bu nesne SQL Server veritabanına olan bağlantıyı temsil ediyor//

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglantı.Open(); //Baglantımızı açtıyoruz//
            SqlCommand komut = new SqlCommand("göster",baglantı); //SqlCommand komutu ile 'göster' stored procedures e bağlandık
            komut.CommandType = CommandType.StoredProcedure; //Kullanıcağımız sql komutunu Stored procedure olarak belirledik.
            DataTable dt = new DataTable(); //data table sınıfından yeni bir nesne türetiyoruz.Tabloları listelemek için.
            dt.Load(komut.ExecuteReader());  //Veri kaynağımızdan verileri çekiyoruz.
            dataGridView1.DataSource = dt;  //tabloları listeleyip dataGridView'e bağlıyoruz.
            baglantı.Close(); //Bağlantımızı kapattıyoruz.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open(); //Bağlantımızı açıyoruz.//
            SqlCommand komut = new SqlCommand("Ekle", baglantı); //SqlCommand komutu ile 'ekle' stored procedures e bağlandık.
            komut.CommandType = CommandType.StoredProcedure;  //Kullanıcağımız sql komutunu Stored procedure olarak belirledik.
            komut.Parameters.AddWithValue("@Mno",textBox1.Text); 
            komut.Parameters.AddWithValue("@Tc",textBox2.Text);
            komut.Parameters.AddWithValue("@Ad",textBox3.Text); //Komut parametremiz ile textboxlara yazdığımız değerleri ekliyoruz.
            komut.Parameters.AddWithValue("@Soyad",textBox4.Text);
            komut.Parameters.AddWithValue("@Telefon",textBox5.Text);
            komut.Parameters.AddWithValue("@Email",textBox6.Text);
            komut.Parameters.AddWithValue("@Reztarih",dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@Kisisayı",textBox7.Text);
            komut.ExecuteNonQuery(); //Veri tabanı içerisinde değişiklik yapacağımız komut işlemi burda gerçekleşiyor.
            baglantı.Close(); //Bağlantımızı kapattıyoruz.//
            MessageBox.Show("Kayıt Ekleme İşlemi Başarılı!!"); //Mesaj kutucuğu gönderiyoruz.


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();  //dataGridView'de tıkladığımız verinin bilgileri TextBoxlara gönderiyoruz.
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open(); //Bağlantımızı açıyoruz.//
            SqlCommand komut = new SqlCommand("silme", baglantı);//SqlCommand komutu ile 'silme' stored procedures e bağlandık
            komut.CommandType = CommandType.StoredProcedure; //Kullanıcağımız sql komutunu Stored procedure olarak belirledik.
            komut.Parameters.AddWithValue("Mno", textBox1.Text); //Mno ya göre kişiyi listeden silme komutu sağladık.
            komut.ExecuteNonQuery(); //Veri tabanı içerisinde değişiklik yapacağımız komut işlemi burda gerçekleşiyor.
            baglantı.Close(); //Bağlantımızı kapattıyoruz.//
            MessageBox.Show("Kayıt Silme İşlemi Başarılı!!"); //Mesaj kutucuğu gönderiyoruz.

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open(); //Bağlantımızı açıyoruz.//
            SqlCommand komut = new SqlCommand("güncelleme", baglantı); //SqlCommand komutu ile 'güncelleme' stored procedures e bağlandık
            komut.CommandType = CommandType.StoredProcedure; //Kullanıcağımız sql komutunu Stored procedure olarak belirledik.
            komut.Parameters.AddWithValue("@Mno", textBox1.Text);
            komut.Parameters.AddWithValue("@Tc", textBox2.Text); //Komut parametremiz ile textboxlara güncelleyeceğimiz değerleri ekliyoruz.
            komut.Parameters.AddWithValue("@Ad", textBox3.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox4.Text);
            komut.Parameters.AddWithValue("@Telefon",textBox5.Text);
            komut.Parameters.AddWithValue("@Email", textBox6.Text);
            komut.Parameters.AddWithValue("@Kisisayı", textBox7.Text);
            komut.Parameters.AddWithValue("@Reztarih", dateTimePicker1.Value);
            komut.ExecuteNonQuery(); //Veri tabanı içerisinde değişiklik yapacağımız komut işlemi burda gerçekleşiyor.
            baglantı.Close(); //Bağlantımızı kapattıyoruz.//
            MessageBox.Show("Kayıt Güncelleme İşlemi Başarılı!!"); //Mesaj kutucuğu gönderiyoruz.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); //Textboxların içindeki veriyi temizliyor.
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();            
            textBox1.Focus();
        }
    }
}
