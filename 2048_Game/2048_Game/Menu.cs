using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _2048_Game
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game gm = new Game();
            gm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rule rl = new Rule();
            rl.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            

        }

        string sqlCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True";

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlExpression = "SELECT * FROM Lids ORDER by Rez DESC";
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader reader;
            try
            {
                connection = new SqlConnection(sqlCon);
                connection.Open();
                command = new SqlCommand(sqlExpression, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    // reader.GetName(0) reader.GetName(1));
                    string FinRez = "";
                    while (reader.Read()) // построчно считываем данные
                    {
                        
                        string name = Convert.ToString( reader.GetValue(0));
                        string rez = Convert.ToString( reader.GetValue(1));
                        FinRez = FinRez + name + " - " + rez + "\n";
                        
                    }
                    MessageBox.Show(FinRez, "Таблица лидеров");
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



            

               
        }

     
    }
}
    

