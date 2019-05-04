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
    public partial class Form5 : Form
    {
        SqlConnection sqlConnection;
        public Form5(Form1 f)
        {
            InitializeComponent();
        }

        private async void Form5_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Моя\WindowsFormsApp1\WindowsFormsApp1\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Procedyru] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_процедур"] + "   " + Convert.ToString(sqlReader["Код_пациента"] + "   " + Convert.ToString(sqlReader["Наименование"] + "   " + Convert.ToString(sqlReader["Дата"])))));
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


                SqlCommand command = new SqlCommand("INSERT INTO [Procedyru] (Код_процедур, Код_пациента, Наименование, Дата) VALUES (@Код_процедур, @Код_пациента, @Наименование, @Дата)", sqlConnection);
                command.Parameters.AddWithValue("Код_процедур", textBox1.Text);
                command.Parameters.AddWithValue("Код_пациента", textBox2.Text);
                command.Parameters.AddWithValue("Наименование", textBox3.Text);
                command.Parameters.AddWithValue("Дата", textBox4.Text);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async void ОбновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Procedyru] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_процедур"] + "" + Convert.ToString(sqlReader["Код_пациента"] + "" + Convert.ToString(sqlReader["Наименование"] + "" + Convert.ToString(sqlReader["Дата"])))));
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

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
