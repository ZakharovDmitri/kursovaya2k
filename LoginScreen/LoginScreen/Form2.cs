using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;
using System.Data.Common;

namespace LoginScreen
{

    public partial class Form2 : Form
    {
        private async Task<byte[]> GetImageBytesAsync(string imagePath)
        {
            byte[] imageBytes = null;
            using (var stream = new FileStream(imagePath, FileMode.Open))
            {
                imageBytes = new byte[stream.Length];
                await stream.ReadAsync(imageBytes, 0, (int)stream.Length);
            }
            return imageBytes;
        }
        
        

        public Form2()
        {
            InitializeComponent();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        public static int id = 30;

        private void Form2_Load(object sender, EventArgs e)
        {

            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            timer1.Start();

            DB dataBase = new DB();
            dataBase.openConnection();
            
            MySqlCommand command1 = new MySqlCommand("SELECT `picture` FROM `pictures` WHERE id = @id", dataBase.getConnection());
            command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            MySqlDataReader datr = command1.ExecuteReader();
            if(datr.Read())
            {
                byte[] xx = (byte[])datr.GetValue(0);
                string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                pictureBox3.Image = image;              
            }
            datr.Close();
            datr.Dispose();

            MySqlCommand command3 = new MySqlCommand("SELECT `videoPath` FROM `videos` WHERE id = @id", dataBase.getConnection());
            command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            datr = command3.ExecuteReader();
            if (datr.Read())
            {
                axWindowsMediaPlayer1.URL = (string)datr.GetValue(0);
                axWindowsMediaPlayer1.uiMode = "none";
                axWindowsMediaPlayer2.Ctlcontrols.pause();

            }
            datr.Close();
            datr.Dispose();

            MySqlCommand command4 = new MySqlCommand("SELECT `audioPath` FROM `audios` WHERE id = @id", dataBase.getConnection());
            command4.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            datr = command4.ExecuteReader();
            if (datr.Read())
            {
                axWindowsMediaPlayer2.URL = (string)datr.GetValue(0);
                axWindowsMediaPlayer2.uiMode = "none";
                axWindowsMediaPlayer2.Ctlcontrols.pause();
            }
            datr.Close();
            datr.Dispose();

            MySqlCommand command5 = new MySqlCommand("SELECT `document` FROM `documents` WHERE id = @id", dataBase.getConnection());
            command5.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            datr = command5.ExecuteReader();
            if (datr.Read())
            {
                byte[] xx = (byte[])datr.GetValue(0);
                string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                pictureBox4.Image = image;
            }
            datr.Close();
            datr.Dispose();


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `pictures`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            label6.Text = table.Rows.Count.ToString();
            table.Clear();

            MySqlCommand command6 = new MySqlCommand("SELECT * FROM `videos`", dataBase.getConnection());
            adapter.SelectCommand = command6;
            adapter.Fill(table);
            label7.Text = table.Rows.Count.ToString();
            table.Clear();
            MySqlCommand command7 = new MySqlCommand("SELECT * FROM `audios`", dataBase.getConnection());
            adapter.SelectCommand = command7;
            adapter.Fill(table);
            label10.Text = table.Rows.Count.ToString();
            MySqlCommand command8 = new MySqlCommand("SELECT * FROM `documents`", dataBase.getConnection());
            adapter.SelectCommand = command7;
            adapter.Fill(table);
            label13.Text = table.Rows.Count.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToShortDateString();
        }

        private void btnPhotos_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.openConnection();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `pictures`", dataBase.getConnection());
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                button20.Enabled = false;
                button9.Enabled = false;
            }
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel9.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
            label3.Text = "Photos";
        }

        private void BtnInfoboard_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            label3.Text = "Info Board";
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `pictures`", dataBase.getConnection());
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `videos`", dataBase.getConnection());
            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `audios`", dataBase.getConnection());
            MySqlCommand command4 = new MySqlCommand("SELECT * FROM `documents`", dataBase.getConnection());
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            label6.Text = table.Rows.Count.ToString();
            table.Clear();
            adapter.SelectCommand = command2;
            adapter.Fill(table);
            label7.Text = table.Rows.Count.ToString();
            table.Clear();
            adapter.SelectCommand = command3;
            adapter.Fill(table);
            label10.Text = table.Rows.Count.ToString();
            table.Clear();
            adapter.SelectCommand = command4;
            adapter.Fill(table);
            label13.Text = table.Rows.Count.ToString();
            table.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                var fileStream = openFileDialog1.ShowDialog().ToString();

                byte[] base64 = File.ReadAllBytes(Path.GetFullPath(openFileDialog1.FileName));


                DB dataBase = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                dataBase.openConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO `pictures`(`id`,`picture`,`description`) VALUES (@id,@pic,@de)", dataBase.getConnection());
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `pictures`", dataBase.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                command.Parameters.Add("@pic", MySqlDbType.Blob).Value = base64;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = 30 + table.Rows.Count;
                command.Parameters.Add("@de", MySqlDbType.VarChar).Value = "У этого фото пока нет описания";
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Файл был загружен","Успешно",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Файл не был загружен");
                if (table.Rows.Count == 0)
                {
                    string base64i = Convert.ToBase64String(base64, 0, base64.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64i)));
                    pictureBox3.Image = image;

                }
                dataBase.closeConnection();
                button20.Enabled = true;
                button9.Enabled = true;
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Файл не был выбран", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch(MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Объект слишком большой или не верного формата!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `pictures`", dataBase.getConnection());
            
            adapter.SelectCommand = command;
            adapter.Fill(table);

            id++;
            dataBase.openConnection();
            if (id >= table.Rows.Count+30)
            {

                id = 30;
                MySqlCommand command1 = new MySqlCommand("SELECT `picture` FROM `pictures` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox3.Image = image;
                    
                }
                datr.Close();
                datr.Dispose();
            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `picture` FROM `pictures` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox3.Image = image;
                    
                }
                datr.Close();
                datr.Dispose();
            }
            dataBase.closeConnection();
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `pictures`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            id--;
            dataBase.openConnection();
            if (id < 30)
            {

                id = 30 + table.Rows.Count-1;
                MySqlCommand command1 = new MySqlCommand("SELECT `picture` FROM `pictures` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox3.Image = image;
                    
                }
                datr.Close();
                datr.Dispose();

            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `picture` FROM `pictures` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox3.Image = image;
                    
                }
                datr.Close();
                datr.Dispose();

            }
            dataBase.closeConnection();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Внимание!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                
            
            DB dataBase = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            dataBase.openConnection();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `pictures`", dataBase.getConnection());
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            
            MySqlCommand command = new MySqlCommand("DELETE FROM `pictures` WHERE id = @id", dataBase.getConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.ExecuteNonQuery();
            MySqlCommand command3 = new MySqlCommand("SELECT `picture` FROM `pictures` WHERE id = @id", dataBase.getConnection());
                if (id != 29 + table.Rows.Count)
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id + 1;
                }
                else
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = 30;
                }
            MySqlDataReader datr = command3.ExecuteReader();           
                
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox3.Image = image;
                }
                datr.Close();
                datr.Dispose();
                     
            for (int i = id+1; i < table.Rows.Count + 31; i++)
            {
                MySqlCommand command2 = new MySqlCommand("UPDATE `pictures` SET `id` = @id WHERE `id` = @id1", dataBase.getConnection());
                if (id != table.Rows.Count + 29)
                {
                    
                    command2.Parameters.Add("@id", MySqlDbType.Int32).Value = i-1;
                    command2.Parameters.Add("@id1", MySqlDbType.Int32).Value = i;
                    datr = command2.ExecuteReader();
                    datr.Close();
                    datr.Dispose();

                }
                
            }

            if(table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы удалили последний элемент в архиве", "Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    pictureBox3.Image = null;
                    button20.Enabled = false;
                    button9.Enabled = false;
                }

            dataBase.closeConnection();

            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DB dataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.openConnection();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `videos`", dataBase.getConnection());
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                button19.Enabled = false;
                button13.Enabled = false;
            }
            panel8.Visible = true;
            panel10.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel9.Visible = false;
            label3.Text = "Videos";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                string formats = "All Videos Files |*.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;  *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                          " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm";

                openFileDialog.Filter = formats;
                openFileDialog.ShowDialog();

                var filePath = Path.GetFullPath(openFileDialog.FileName);
                DB dataBase = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                dataBase.openConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO `videos`(`id`,`videoPath`,`description`) VALUES (@id,@vid,@de)", dataBase.getConnection());
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `videos`", dataBase.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                command.Parameters.Add("@vid", MySqlDbType.VarChar).Value = filePath;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = 30 + table.Rows.Count;
                command.Parameters.Add("@de", MySqlDbType.VarChar).Value = "У этого видео пока нет описания";

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Файл был загружен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Файл не был загружен");
                dataBase.closeConnection();
                button19.Enabled = true;
                button13.Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Файл не был выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Объект слишком большой или не верного формата!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `videos`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            id++;
            dataBase.openConnection();
            if (id >= table.Rows.Count + 30)
            {

                id = 30;
                MySqlCommand command1 = new MySqlCommand("SELECT `videoPath` FROM `videos` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer1.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer1.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();
            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `videoPath` FROM `videos` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer1.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer1.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();
            }
            dataBase.closeConnection();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `videos`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            id--;
            dataBase.openConnection();
            if (id < 30)
            {

                id = 30 + table.Rows.Count - 1;
                MySqlCommand command1 = new MySqlCommand("SELECT `videoPath` FROM `videos` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer1.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer1.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();

            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `videoPath` FROM `videos` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer1.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer1.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();

            }
            dataBase.closeConnection();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {


                DB dataBase = new DB();


                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                dataBase.openConnection();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `videos`", dataBase.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);

                MySqlCommand command = new MySqlCommand("DELETE FROM `videos` WHERE id = @id", dataBase.getConnection());
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                MySqlCommand command3 = new MySqlCommand("SELECT `videoPath` FROM `videos` WHERE id = @id", dataBase.getConnection());
                if (id != 29 + table.Rows.Count)
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id + 1;
                }
                else
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = 30;
                }
                MySqlDataReader datr = command3.ExecuteReader();

                if (datr.Read())
                {
                    axWindowsMediaPlayer1.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer1.uiMode = "none";
                }
                datr.Close();
                datr.Dispose();

                for (int i = id + 1; i < table.Rows.Count + 31; i++)
                {
                    MySqlCommand command2 = new MySqlCommand("UPDATE `videos` SET `id` = @id WHERE `id` = @id1", dataBase.getConnection());
                    if (id != table.Rows.Count + 29)
                    {

                        command2.Parameters.Add("@id", MySqlDbType.Int32).Value = i - 1;
                        command2.Parameters.Add("@id1", MySqlDbType.Int32).Value = i;
                        datr = command2.ExecuteReader();
                        datr.Close();
                        datr.Dispose();

                    }

                }

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы удалили последний элемент в архиве", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button19.Enabled = false;
                    button13.Enabled = false;
                }

                dataBase.closeConnection();

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.openConnection();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `audios`", dataBase.getConnection());
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                ButtonDescAudi.Enabled = false;
                button17.Enabled = false;
            }
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = true;
            panel10.Visible = false;
            label3.Text = "Audios";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                string formats = "All Audios Files |*.mp3; *.mpeg4;";

                openFileDialog.Filter = formats;
                openFileDialog.ShowDialog();

                var filePath = Path.GetFullPath(openFileDialog.FileName);
                DB dataBase = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                dataBase.openConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO `audios`(`id`,`audioPath`,`description`) VALUES (@id,@au,@de)", dataBase.getConnection());
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `audios`", dataBase.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                command.Parameters.Add("@au", MySqlDbType.VarChar).Value = filePath;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = 30 + table.Rows.Count;
                command.Parameters.Add("@de", MySqlDbType.VarChar).Value = "У этого аудио пока нет описания";
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Файл был загружен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Файл не был загружен");
                dataBase.closeConnection();
                button17.Enabled = true;
                ButtonDescAudi.Enabled = true; ;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Файл не был выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Объект слишком большой или не верного формата!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `audios`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            id++;
            dataBase.openConnection();
            if (id >= table.Rows.Count + 30)
            {

                id = 30;
                MySqlCommand command1 = new MySqlCommand("SELECT `audioPath` FROM `audios` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer2.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer2.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();
            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `audioPath` FROM `audios` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer2.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer2.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();
            }
            dataBase.closeConnection();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `audios`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            id--;
            dataBase.openConnection();
            if (id < 30)
            {

                id = 30 + table.Rows.Count - 1;
                MySqlCommand command1 = new MySqlCommand("SELECT `audioPath` FROM `audios` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer2.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer2.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();

            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `audioPath` FROM `audios` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    axWindowsMediaPlayer2.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer2.uiMode = "none";

                }
                datr.Close();
                datr.Dispose();

            }
            dataBase.closeConnection();
        }

        

        private void button17_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {


                DB dataBase = new DB();


                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                dataBase.openConnection();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `audios`", dataBase.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);

                MySqlCommand command = new MySqlCommand("DELETE FROM `audios` WHERE id = @id", dataBase.getConnection());
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                MySqlCommand command3 = new MySqlCommand("SELECT `audioPath` FROM `audios` WHERE id = @id", dataBase.getConnection());
                if (id != 29 + table.Rows.Count)
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id + 1;
                }
                else
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = 30;
                }
                MySqlDataReader datr = command3.ExecuteReader();

                if (datr.Read())
                {
                    axWindowsMediaPlayer2.URL = (string)datr.GetValue(0);
                    axWindowsMediaPlayer2.uiMode = "none";
                }
                datr.Close();
                datr.Dispose();

                for (int i = id + 1; i < table.Rows.Count + 31; i++)
                {
                    MySqlCommand command2 = new MySqlCommand("UPDATE `audios` SET `id` = @id WHERE `id` = @id1", dataBase.getConnection());
                    if (id != table.Rows.Count + 29)
                    {

                        command2.Parameters.Add("@id", MySqlDbType.Int32).Value = i - 1;
                        command2.Parameters.Add("@id1", MySqlDbType.Int32).Value = i;
                        datr = command2.ExecuteReader();
                        datr.Close();
                        datr.Dispose();

                    }

                }

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы удалили последний элемент в архиве", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button17.Enabled = false;
                    ButtonDescAudi.Enabled = false;

                }

                dataBase.closeConnection();

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        public static bool flagButtonDesAudio = false;

        private void button18_Click(object sender, EventArgs e)
        {
            flagButtonDesAudio = true;
            DB dataBase = new DB();
            dataBase.openConnection();
            MySqlCommand command3 = new MySqlCommand("SELECT `description` FROM `audios` WHERE id = @id", dataBase.getConnection());
            command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            MySqlDataReader datr = command3.ExecuteReader();
            string str = null;
            
            if (datr.Read())
            {
                str = (string)datr.GetValue(0);
            }
            if (labelUserName.Text == "Admin")
            {
                Form3 m = new Form3();
                m.Show();
                m.richTextBox1.Text = str;
            }
            else
            {
                MessageBox.Show(str, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        public static bool flagButtonDesVideo = false;
        private void button19_Click(object sender, EventArgs e)
        {

            flagButtonDesVideo = true;
            DB dataBase = new DB();
            dataBase.openConnection();
            MySqlCommand command3 = new MySqlCommand("SELECT `description` FROM `videos` WHERE id = @id", dataBase.getConnection());
            command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            MySqlDataReader datr = command3.ExecuteReader();
            string str = null;

            if (datr.Read())
            {
                str = (string)datr.GetValue(0);
            }
            if (labelUserName.Text == "Admin")
            {
                Form3 m = new Form3();
                m.Show();
                m.richTextBox1.Text = str;
            }
            else
            {
                MessageBox.Show(str, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static bool flagButtonDesPhoto = false;
        private void button20_Click(object sender, EventArgs e)
        {
            flagButtonDesPhoto = true;
            DB dataBase = new DB();
            dataBase.openConnection();
            MySqlCommand command3 = new MySqlCommand("SELECT `description` FROM `pictures` WHERE id = @id", dataBase.getConnection());
            command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            MySqlDataReader datr = command3.ExecuteReader();
            string str = null;

            if (datr.Read())
            {
                str = (string)datr.GetValue(0);
            }
            if (labelUserName.Text == "Admin")
            {
                Form3 m = new Form3();
                m.Show();
                m.richTextBox1.Text = str;
            }
            else
            {
                MessageBox.Show(str, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            dataBase.openConnection();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `documents`", dataBase.getConnection());
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            if(table.Rows.Count == 0)
            {
                button18.Enabled = false;
                button21.Enabled = false;
            }
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel9.Visible = false;
            panel8.Visible = false;
            panel10.Visible = true;
            label3.Text = "Documents";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                var fileStream = openFileDialog1.ShowDialog().ToString();

                byte[] base64 = File.ReadAllBytes(Path.GetFullPath(openFileDialog1.FileName));


                DB dataBase = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                dataBase.openConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO `documents`(`id`,`document`,`description`) VALUES (@id,@doc,@de)", dataBase.getConnection());
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `documents`", dataBase.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                command.Parameters.Add("@doc", MySqlDbType.Blob).Value = base64;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = 30 + table.Rows.Count;
                command.Parameters.Add("@de", MySqlDbType.VarChar).Value = "У этого документа пока нет описания";
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Файл был загружен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Файл не был загружен");

                if(table.Rows.Count == 0)
                {
                    string base64i = Convert.ToBase64String(base64, 0, base64.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64i)));
                    pictureBox4.Image = image;

                }
                dataBase.closeConnection();
                button18.Enabled = true;
                button21.Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Файл не был выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Объект слишком большой или не верного формата!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {


                DB dataBase = new DB();


                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                dataBase.openConnection();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `documents`", dataBase.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);

                MySqlCommand command = new MySqlCommand("DELETE FROM `documents` WHERE id = @id", dataBase.getConnection());
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                MySqlCommand command3 = new MySqlCommand("SELECT `document` FROM `documents` WHERE id = @id", dataBase.getConnection());
                if (id != 29 + table.Rows.Count)
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id + 1;
                }
                else
                {
                    command3.Parameters.Add("@id", MySqlDbType.Int32).Value = 30;
                }
                MySqlDataReader datr = command3.ExecuteReader();

                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox4.Image = image;
                }
                datr.Close();
                datr.Dispose();

                for (int i = id + 1; i < table.Rows.Count + 31; i++)
                {
                    MySqlCommand command2 = new MySqlCommand("UPDATE `documents` SET `id` = @id WHERE `id` = @id1", dataBase.getConnection());
                    if (id != table.Rows.Count + 29)
                    {

                        command2.Parameters.Add("@id", MySqlDbType.Int32).Value = i - 1;
                        command2.Parameters.Add("@id1", MySqlDbType.Int32).Value = i;
                        datr = command2.ExecuteReader();
                        datr.Close();
                        datr.Dispose();

                    }

                }

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы удалили последний элемент в архиве", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pictureBox4.Image = null;
                    button18.Enabled = false;
                    button21.Enabled = false;
                }

                dataBase.closeConnection();

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `documents`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            id++;
            dataBase.openConnection();
            if (id >= table.Rows.Count + 30)
            {

                id = 30;
                MySqlCommand command1 = new MySqlCommand("SELECT `document` FROM `documents` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox4.Image = image;

                }
                datr.Close();
                datr.Dispose();
            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `document` FROM `documents` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox4.Image = image;

                }
                datr.Close();
                datr.Dispose();
            }
            dataBase.closeConnection();


        }

        private void button22_Click(object sender, EventArgs e)
        {
            DB dataBase = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `documents`", dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            id--;
            dataBase.openConnection();
            if (id < 30)
            {

                id = 30 + table.Rows.Count - 1;
                MySqlCommand command1 = new MySqlCommand("SELECT `document` FROM `documents` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox4.Image = image;

                }
                datr.Close();
                datr.Dispose();

            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `document` FROM `documents` WHERE id = @id", dataBase.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader datr = command1.ExecuteReader();
                if (datr.Read())
                {
                    byte[] xx = (byte[])datr.GetValue(0);
                    string base64 = Convert.ToBase64String(xx, 0, xx.Length);
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
                    pictureBox4.Image = image;

                }
                datr.Close();
                datr.Dispose();

            }
            dataBase.closeConnection();

        }

        public static bool flagButtonDesDoc = false;

        private void button18_Click_1(object sender, EventArgs e)
        {
            flagButtonDesDoc = true;
            DB dataBase = new DB();
            dataBase.openConnection();
            MySqlCommand command3 = new MySqlCommand("SELECT `description` FROM `documents` WHERE id = @id", dataBase.getConnection());
            command3.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            MySqlDataReader datr = command3.ExecuteReader();
            string str = null;

            if (datr.Read())
            {
                str = (string)datr.GetValue(0);
            }
            if (labelUserName.Text == "Admin")
            {
                Form3 m = new Form3();
                m.Show();
                m.richTextBox1.Text = str;
            }
            else
            {
                MessageBox.Show(str, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа создана студентом 2 курса в рамках написания курсовой работы" +
                          "\n Круглосуточная поддержка +7(996)-323-87-81 или dazakharov_2@edu.hse.ru" +
                          "\nАвтор: Захаров Дмитрий" +
                          "\nПИ-19-1 | НИУ ВШЭ - Пермь | 2021",
                          "Contact Us", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
