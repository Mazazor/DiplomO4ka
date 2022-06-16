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

    public partial class Registration : Form
    {
        Connection connection = new Connection();
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var login = textBox_login.Text;
            var password = textBox_password.Text;

            string qwerystring = $"insert into autolog(Login, Password) values('{login}', '{password}')";

            SqlCommand cmd = new SqlCommand(qwerystring, connection.GetConnection());

            connection.openConnection();

            if(cmd.ExecuteNonQuery() ==1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                Autharization autharization = new Autharization();
                this.Hide();
                autharization.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            connection.closeConnection();
        }

        private Boolean checkuser()
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string qwerystring = $"select ID,Login,Password from autolog where Login = '{loginUser}' and Password = '{passUser}' ";

            SqlCommand command = new SqlCommand(qwerystring, connection.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже сущесвует");
                return true;
            }
            else
            {
                return false;
            }


        }

        private void Registration_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Autharization autharization = new Autharization();
            autharization.Show();
            this.Hide();
        }
    }
}
