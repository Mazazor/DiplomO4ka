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

namespace ComputerTechnique
{
    public partial class Autharization : Form
    {
       Connection connection = new Connection();
        public Autharization()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Autharization_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            
            string querystriing = $"select Id, Login, Password from autolog where Login = '{loginUser}' and Password = '{passUser}'";
            
            SqlCommand cmd = new SqlCommand(querystriing, connection.GetConnection());
            
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            
            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Main main = new Main();
                this.Hide();
                main.ShowDialog();
                this.Hide();
            }
            else
                MessageBox.Show("Такого аккаунта не существует", "Аккаунта не существует!", MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
