using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataBase database = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        string qProduct = "select Код, Название, QR, Цена from dbo.Товары";
        string qSellProduct = "select Код, Дата, dbo.Товары.Наименование as Товар, Цена, QR, Количество, Сумма from dbo.ПродажаТоваров inner join dbo.Товары on dbo.Товары.Код = ТоварFK";
        string qGetProduct = "select Код, ДатаПоступления, dbo.Товары.Наименование as Товар, Цена, Количество, QR, Сумма from dbo.ПоступлениеТовара inner join dbo.Товары on dbo.Товары.Код = ТоварFK";
        string qOstatkiProduct = "select Код, dbo.Товары.Наименование as Товар, QR, Количество from dbo.ПродажаТоваров inner join dbo.Товары on dbo.Товары.Код = ТоварFK";
        
        void SetSellProduct()
        {
            database.openConnection();

            string querry_workers = $"select Код, Название, QR, Цена from dbo.Товары where QR='{textBox8.Text}'";
            SqlCommand cmd = new SqlCommand(querry_workers, database.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    {
                        if (Convert.ToInt64(dataGridView4[2, i].Value.ToString()) == Convert.ToInt64(reader[2].ToString()))
                        {
                            dataGridView1[0, 0].Value = reader[1].ToString();
                            dataGridView1[1, 0].Value = reader[3].ToString();
                            dataGridView1[2, 0].Value = + 1;
                            dataGridView1[3, 0].Value = reader[3].ToString();
                            dataGridView1[4, 0].Value = DateTime.Now.ToString();
                        }
                    }

                }
                
            }

            database.closeConnection();
        }

        void SetGetProduct()
        {
            database.openConnection();

            string querry_workers = $"select Код, Название, QR, Цена from dbo.Товары where QR='{comboBox1.Text}'";
            SqlCommand cmd = new SqlCommand(querry_workers, database.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox7.Text = reader[0].ToString();
                textBox4.Text = reader[1].ToString();
                textBox6.Text = reader[3].ToString();
            }

            database.closeConnection();
        }

        void SetProduct()
        {
            database.openConnection();

            string querry_workers = $"select Код, Название, QR, Цена from dbo.Товары where QR='{comboBox1.Text}'";
            SqlCommand cmd = new SqlCommand(querry_workers, database.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox7.Text = reader[0].ToString();
                textBox4.Text = reader[1].ToString();
                textBox6.Text = reader[3].ToString();
            }

            database.closeConnection();
        }

        //Поиск данных
        private void Search(string querry, DataGridView dgv)
        {
            database.openConnection();

            SqlDataAdapter adpt = new SqlDataAdapter(querry, database.getConnection());
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dgv.DataSource = dt;

            database.closeConnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "___QRСабирзянов_Ист_211_2_1DataSet.ПродажаТоваров". При необходимости она может быть перемещена или удалена.
            this.продажаТоваровTableAdapter.Fill(this.___QRСабирзянов_Ист_211_2_1DataSet.ПродажаТоваров);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "кассаDataSet.ОстаткиТоваров". При необходимости она может быть перемещена или удалена.
            this.остаткиТоваровTableAdapter1.Fill(this.кассаDataSet.ОстаткиТоваров);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "кассаDataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this.кассаDataSet.Продажи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "кассаDataSet.ПоступленияТоваров". При необходимости она может быть перемещена или удалена.
            this.поступленияТоваровTableAdapter.Fill(this.кассаDataSet.ПоступленияТоваров);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "кассаDataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter1.Fill(this.кассаDataSet.Товары);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "___QRСабирзянов_Ист_211_2_1DataSet.ОстаткиТоваров". При необходимости она может быть перемещена или удалена.
            this.остаткиТоваровTableAdapter.Fill(this.___QRСабирзянов_Ист_211_2_1DataSet.ОстаткиТоваров);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "___QRСабирзянов_Ист_211_2_1DataSet.ПоступлениеТоваров". При необходимости она может быть перемещена или удалена.
            this.поступлениеТоваровTableAdapter.Fill(this.___QRСабирзянов_Ист_211_2_1DataSet.ПоступлениеТоваров);
            this.товарыTableAdapter.Fill(this.___QRСабирзянов_Ист_211_2_1DataSet.Товары);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string product = textBox1.Text;
            string qr = textBox2.Text;
            string cost = textBox3.Text;

            string querry_insert = $"execute dbo.ДобавлениеТовара {product}, {qr}, {cost}";
            database.openConnection();

            SqlCommand insert_data = new SqlCommand(querry_insert, database.getConnection());
            insert_data.ExecuteNonQuery();

            database.closeConnection();
            Form1_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
            string columns = "(QR)";
            string querry_search = qProduct + $" where {columns} like '%{textBox10.Text}%'";

            Search(querry_search, dataGridView2);
            SetProduct();
                   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int code = int.Parse(textBox11.Text);
            string product = textBox1.Text;
            string qr = textBox2.Text;
            int cost = (int)Convert.ToDecimal(textBox3.Text);//textBox3.Text.Substring(0, textBox3.Text.Length - 5);

            string querry_insert = $"execute dbo.ОбновлениеТоваров '{code}', '{product}', '{cost}', '{qr}'";
            database.openConnection();

            SqlCommand insert_data = new SqlCommand(querry_insert, database.getConnection());
            insert_data.ExecuteNonQuery();

            database.closeConnection();
            textBox10.Text = "";
            Form1_Load(null, null);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            SetGetProduct();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            SetSellProduct();
        }
    }
}
