using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;

namespace Space_Lock__Main_
{
    public partial class settings : Form
    {
        frmControl camControl;

        public settings()
        {
            InitializeComponent();
            displaynum();
        }

        private void displaynum()
        {
            spacelocklinqDataContext data = new spacelocklinqDataContext();
            var query = from c in data.settings
                        where c.user == "admin"
                        select (c.Phone_Number);

            foreach (var item in query)
            {
                current_phone_number_box.Text = item.TrimEnd();
            }
        }
        private void settings_Load(object sender, EventArgs e)
        {

        }
        private void done_button_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void change_number_button_Click(object sender, EventArgs e)
        {
            if (new_number_box.Text != "")
            {
                spacelocklinqDataContext data = new spacelocklinqDataContext();
                var match = (from d in data.GetTable<setting>()
                             where d.user == "admin"
                             select d).SingleOrDefault();
                match.Phone_Number = new_number_box.Text;
                match.Phone_Number.TrimEnd();
                data.SubmitChanges();
                displaynum();
            }
        }

        
        private void change_password_button_Click(object sender, EventArgs e)
        {
            string password="";
            spacelocklinqDataContext data = new spacelocklinqDataContext();
            var query = from c in data.settings
                        where c.user == "admin"
                        select (c.Password);

            foreach (var item in query)
            {
                password = item.TrimEnd();
            }
            if (old_password_box.Text == password)
            {
                if (new_password_box.Text == confirm_new_password.Text && new_password_box.Text!="" && confirm_new_password.Text!="")
                {
                    spacelocklinqDataContext dat = new spacelocklinqDataContext();
                    var match = (from d in dat.GetTable<setting>()
                                 where d.user == "admin"
                                 select d).SingleOrDefault();
                    match.Password = confirm_new_password.Text;
                    match.Password.TrimEnd();
                    dat.SubmitChanges();
                    MessageBox.Show("Password Change Successful!");
                }
                else 
                {
                    MessageBox.Show("Either the old password is wrong or the two passwords dont match");
                }
            }
            else
            {
                MessageBox.Show("Either the old password is wrong or the two passwords dont match");
            }
        }

        private void done_button_Click_1(object sender, EventArgs e)
        {
            if (camControl != null)
                camControl.Close();
            this.Close();
            
        }

        private void com_port_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void test_phone_connection_button_Click(object sender, EventArgs e)
        {
            spacelocklinqDataContext dat = new spacelocklinqDataContext();
            var match = (from d in dat.GetTable<setting>()
                         where d.user == "admin"
                         select d).SingleOrDefault();
            try
            {
                match.Port_Number = int.Parse(com_port_box.Text.TrimEnd());
            }
            catch (Exception)
            {
                match.Port_Number = 10;
            }
            dat.SubmitChanges();
            GsmCommMain comm = new GsmCommMain(match.Port_Number, 19200, 300);
            try
            {
                comm.Open();
                comm.Close();
                MessageBox.Show("Phone Connection Successful");
            }
            catch (Exception)
            {
                MessageBox.Show("Phone Connection Unsuccessful");
            }
        }

        private void current_phone_number_box_TextChanged(object sender, EventArgs e)
        {

        }

        // Cam Control form --ideamonk
        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (camControl != null)
            {
                if (camControl.Visible == false)
                {
                    camControl = new frmControl();
                    camControl.Show();
                }   
            }
            else
            {
                camControl = new frmControl();
                camControl.Show();
            }
        }        
    }
}
