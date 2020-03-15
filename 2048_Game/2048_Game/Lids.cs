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
    public partial class Lids : Form
    {
        int score;
        public Lids(string sc)
        {
             score = Convert.ToInt32(sc);
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length != 3 || textBoxName.Text.Length == 0)
            {
                MessageBox.Show("Введите имя из 3 английских букв!");
                return;
            }
            string sqlCon  = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True";
           
            try
            {
                SqlConnection connection = new SqlConnection(sqlCon);
                // Открываем подключение
                connection.Open();

                string sqlExpression = "INSERT INTO Lids (Name, Rez) VALUES ('" + textBoxName.Text + "', " + score + " )";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Вы войдете в историю))");
                connection.Close();
                this.Close();
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Такое имя уже используется!");
            }
        
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }
    }
}
