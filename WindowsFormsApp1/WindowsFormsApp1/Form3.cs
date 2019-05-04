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
using System.Data;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
        public Form3(Form1 f)
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Моя\WindowsFormsApp1\WindowsFormsApp1\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Pacienti] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_пациента"] + "   " + Convert.ToString(sqlReader["Фамилия"] + "   " + Convert.ToString(sqlReader["Имя"] + "   " + Convert.ToString(sqlReader["Отчество"] + "  " + Convert.ToString(sqlReader["Дата_рождения"] + "  " + Convert.ToString(sqlReader["Пол"] + "  " + Convert.ToString(sqlReader["СНИЛС"]))))))));
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

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {


                SqlCommand command = new SqlCommand("INSERT INTO [Pacienti] (Код_пациента, Фамилия, Имя, Отчество, Дата_рождения, Пол, СНИЛС) VALUES (@Код_пациента, @Фамилия, @Имя, @Отчество, @Дата_рождения, @Пол, @СНИЛС)", sqlConnection);
                command.Parameters.AddWithValue("Код_пациента", textBox1.Text);
                command.Parameters.AddWithValue("Фамилия", textBox2.Text);
                command.Parameters.AddWithValue("Имя", textBox3.Text);
                command.Parameters.AddWithValue("Отчество", textBox4.Text);
                command.Parameters.AddWithValue("Дата_рождения", textBox5.Text);
                command.Parameters.AddWithValue("Пол", textBox6.Text);
                command.Parameters.AddWithValue("СНИЛС", textBox7.Text);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async void ОбновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Pacienti] ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())

                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Код_пациента"] + "" + Convert.ToString(sqlReader["Фамилия"] + "" + Convert.ToString(sqlReader["Имя"] + "" + Convert.ToString(sqlReader["Отчество"] + "" + Convert.ToString(sqlReader["Дата_рождения"] + "" + Convert.ToString(sqlReader["Пол"] + "" + Convert.ToString(sqlReader["СНИЛС"]))))))));
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

