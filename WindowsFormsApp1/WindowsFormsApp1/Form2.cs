using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Моя\WindowsFormsApp1\WindowsFormsApp1\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Vrahi] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_врача"] + "   " + Convert.ToString(sqlReader["Фамилия"] + "   " + Convert.ToString(sqlReader["Имя"] + "   " + Convert.ToString(sqlReader["Отчество"] + "   " + Convert.ToString(sqlReader["Специальность"]))))));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {


                SqlCommand command = new SqlCommand("INSERT INTO [Vrahi] (Код_врача, Фамилия, Имя, Отчество, Специальность ) VALUES (@Код_врача, @Фамилия, @Имя, @Отчество, @Специальность)", sqlConnection);
                command.Parameters.AddWithValue("Код_врача", textBox1.Text);
                command.Parameters.AddWithValue("Фамилия", textBox2.Text);
                command.Parameters.AddWithValue("Имя", textBox3.Text);
                command.Parameters.AddWithValue("Отчество", textBox4.Text);
                command.Parameters.AddWithValue("Специальность", textBox5.Text);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async void ОбновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Vrahi] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_врача"] + "" + Convert.ToString(sqlReader["Фамилия"] + "" + Convert.ToString(sqlReader["Имя"] + "" + Convert.ToString(sqlReader["Отчество"] + "" + Convert.ToString(sqlReader["Специальность"]))))));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
    }
}


