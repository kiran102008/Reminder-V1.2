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

namespace Reminderappv1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string currentime,currentdate,messagetime,messagedate,new_msg,new_date,new_time,temptime;
        SqlConnection con,icon,icon2;
        SqlCommand cmd,icmd,icmd2;

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string check_this = monthCalendar1.SelectionRange.Start.ToString("dd/MM/yy");
            label8.Text = "";
            icon2.Open();
            icmd2 = new SqlCommand("select date,time,msg from data where date='" + check_this + "'");
            icmd2.Connection = icon2;
            rdr = icmd2.ExecuteReader();
            while (rdr.Read())
            {
                new_date = rdr[0].ToString();
                new_time = rdr[1].ToString();
                new_msg = rdr[2].ToString();
                label8.Text =label8.Text + "\n" + new_time + " " + new_msg;
            }
            icon2.Close();
        }

        SqlDataReader rdr;
        private void timer1_Tick(object sender, EventArgs e)
        {
            currentime = DateTime.Now.ToString("hh:mm:ss tt");
            currentdate = DateTime.Now.ToString("dd/MM/yy");
            label1.Text = "Current time : " + currentime;
            maskedTextBox2.Text = monthCalendar1.SelectionRange.Start.ToString("dd/MM/yy");
        }

        protected void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=reminder;Integrated Security=true");
            icon = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=reminder;Integrated Security=true");
            icon2 = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=reminder;Integrated Security=true");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer2.Start();
            //button1.Enabled = false;
            con.Open();
            cmd = new SqlCommand("insert into data values('" + maskedTextBox2.Text + "','" + messagetime + "','" + textBox1.Text + "')");
            //button2.Enabled = true;
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully uploaded");
            }
            else
            {
                MessageBox.Show("Upload failed");
            }
            con.Close();
        }

        public void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 1;
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //timer2.Stop();
        //button1.Enabled = true;
        //button2.Enabled = false;
        //label4.Text = " ";
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            messagetime = maskedTextBox1.Text + " " + comboBox1.Text;
            messagedate = maskedTextBox2.Text;
            //label2.Text = messagetime;
            label4.Text = "Set Reminder for:  " + messagetime;
            label7.Text = "Today's date :"+currentdate;
            icon.Close();
            icon.Open();
            //icmd = new SqlCommand("select date,time,msg from data");
            icmd = new SqlCommand("select * from data where time='" + currentime + "'");
            
            icmd.Connection = icon;
            rdr = icmd.ExecuteReader();
            //int a1 = icmd.ExecuteNonQuery();
            //if (a1 > 0)
            //{
            //    label9.Text = "something";
            //    timer2.Stop();
            //}
            //else
            //{
            //    Random rnd = new Random();
            //    int month = rnd.Next(1, 13);
            //    label8.Text = "nothing"+ month;

            //}
            if (rdr.Read())
            {
                timer2.Interval = 1000;
                //timer2.Stop();
                temptime = currentime;
                new_date = rdr[0].ToString();
                new_time = rdr[1].ToString();
                new_msg = rdr[2].ToString();
                MessageBox.Show(new_msg, "Reminder");
                
            }
            timer2.Interval = 100;
            //icon.Close();
            //timer2.Start();
            /* if ( currentime == new_time && currentdate == new_date)
             {
             //timer2.Stop();
                 MessageBox.Show("hehahah");
                 button1.Enabled = true;
                 //button2.Enabled = false;
                 label4.Text = " ";
             } */
        }
    }
}
