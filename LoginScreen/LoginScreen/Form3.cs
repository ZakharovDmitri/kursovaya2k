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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            if (Form2.flagButtonDesAudio == true)
            {
                DB dataBase = new DB();
                dataBase.openConnection();
                MySqlCommand command2 = new MySqlCommand("UPDATE `audios` SET `description` = @de WHERE `id` = @id", dataBase.getConnection());
                command2.Parameters.Add("@id", MySqlDbType.Int32).Value = Form2.id;
                command2.Parameters.Add("@de", MySqlDbType.VarChar).Value = richTextBox1.Text;
                MySqlDataReader datr = command2.ExecuteReader();
                dataBase.closeConnection();
                Form2.flagButtonDesAudio = false;


            }
            else if(Form2.flagButtonDesVideo == true)
            {
                DB dataBase = new DB();
                dataBase.openConnection();
                MySqlCommand command2 = new MySqlCommand("UPDATE `videos` SET `description` = @de WHERE `id` = @id", dataBase.getConnection());
                command2.Parameters.Add("@id", MySqlDbType.Int32).Value = Form2.id;
                command2.Parameters.Add("@de", MySqlDbType.VarChar).Value = richTextBox1.Text;
                MySqlDataReader datr = command2.ExecuteReader();
                dataBase.closeConnection();
                Form2.flagButtonDesAudio = false;
            }
            else if (Form2.flagButtonDesPhoto == true)
            {
                DB dataBase = new DB();
                dataBase.openConnection();
                MySqlCommand command2 = new MySqlCommand("UPDATE `pictures` SET `description` = @de WHERE `id` = @id", dataBase.getConnection());
                command2.Parameters.Add("@id", MySqlDbType.Int32).Value = Form2.id;
                command2.Parameters.Add("@de", MySqlDbType.VarChar).Value = richTextBox1.Text;
                MySqlDataReader datr = command2.ExecuteReader();
                dataBase.closeConnection();
                Form2.flagButtonDesAudio = false;
            }
            else if(Form2.flagButtonDesDoc == true)
            {
                DB dataBase = new DB();
                dataBase.openConnection();
                MySqlCommand command2 = new MySqlCommand("UPDATE `documents` SET `description` = @de WHERE `id` = @id", dataBase.getConnection());
                command2.Parameters.Add("@id", MySqlDbType.Int32).Value = Form2.id;
                command2.Parameters.Add("@de", MySqlDbType.VarChar).Value = richTextBox1.Text;
                MySqlDataReader datr = command2.ExecuteReader();
                dataBase.closeConnection();
                Form2.flagButtonDesAudio = false;
            }

            this.Close();



        }
    }
}
