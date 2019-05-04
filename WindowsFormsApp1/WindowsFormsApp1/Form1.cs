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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Моя\WindowsFormsApp1\WindowsFormsApp1\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Analiz] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_анализа"] + "   " + Convert.ToString(sqlReader["Код_пациента"] + "   " + Convert.ToString(sqlReader["Наименование"] + "   " + Convert.ToString(sqlReader["Дата"])))));
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

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {


                SqlCommand command = new SqlCommand("INSERT INTO [Analiz] (Код_анализа, Код_пациента, Наименование, Дата) VALUES (@Код_анализа, @Код_пациента, @Наименование, @Дата)", sqlConnection);
                command.Parameters.AddWithValue("Код_анализа", textBox1.Text);
                command.Parameters.AddWithValue("Код_пациента", textBox2.Text);
                command.Parameters.AddWithValue("Наименование", textBox3.Text);
                command.Parameters.AddWithValue("Дата", textBox4.Text);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async void ОбновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Analiz] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_анализа"] + "" + Convert.ToString(sqlReader["Код_пациента"] + "" + Convert.ToString(sqlReader["Наименование"] + "" + Convert.ToString(sqlReader["Дата"])))));
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

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(this);
            newForm.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4(this);
            newForm.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5(this);
            newForm.Show();
        }
    }
}
