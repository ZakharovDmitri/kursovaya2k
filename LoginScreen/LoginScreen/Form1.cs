using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = txtUserName.Text;
            String passUser = txtpassword.Text;

            DB dataBase = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP",dataBase.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

           
            

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.labelUserName.Text = loginUser;
                if(loginUser != "Admin")
                {
                    
                    f2.button6.Enabled = false;
                    f2.button9.Enabled = false;
                    f2.button10.Enabled = false;
                    f2.button13.Enabled = false;
                    f2.button17.Enabled = false;
                    f2.button14.Enabled = false;
                    f2.button24.Enabled = false;
                    f2.button21.Enabled = false;
                }
                f2.Show();
                MessageBox.Show("Успешно авторизовано");
            }
            else
                MessageBox.Show("Проверьте введенные данные");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
