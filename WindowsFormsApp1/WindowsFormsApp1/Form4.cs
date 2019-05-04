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
    public partial class Form4 : Form
    {
        SqlConnection sqlConnection;
        public Form4(Form1 f)
        {
            InitializeComponent();
        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Моя\WindowsFormsApp1\WindowsFormsApp1\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Priem] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_приёма"] + "   " + Convert.ToString(sqlReader["Код_врача"] + "   " + Convert.ToString(sqlReader["Код_пациента"] + "   " + Convert.ToString(sqlReader["Диагноз"])))));
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

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
               !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
               !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
               !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {


                SqlCommand command = new SqlCommand("INSERT INTO [Priem] (Код_приёма, Код_врача, Код_пациента, Диагноз) VALUES (@Код_приёма, @Код_врача, @Код_пациента, @Диагноз)", sqlConnection);
                command.Parameters.AddWithValue("Код_приёма", textBox1.Text);
                command.Parameters.AddWithValue("Код_врача", textBox2.Text);
                command.Parameters.AddWithValue("Код_пациента", textBox3.Text);
                command.Parameters.AddWithValue("Диагноз", textBox4.Text);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async void ОбновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Priem] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_приёма"] + "" + Convert.ToString(sqlReader["Код_врача"] + "" + Convert.ToString(sqlReader["Код_пациента"] + "" + Convert.ToString(sqlReader["Диагноз"])))));
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
