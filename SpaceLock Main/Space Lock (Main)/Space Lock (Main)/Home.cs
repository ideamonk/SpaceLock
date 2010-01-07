using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Space_Lock__Main_
{
    public partial class Home : Form
    {
        # region Variables & Home
        
        /// This Section contains initialization of objects and variables
        /// Checking Variables are initialized
        /// The home window is designed using home function
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();
        smsgsm sms_object = new smsgsm();
        bool login_check = false;
        static bool intrusion_check_variable = false;
        bool recording_check = false;
        static bool rotation_check_variable = false;
        static bool stop_check = true;
        string send = "null";
        string password;
        static int lookuptime_rotation = 10;
        static bool close_check = false;        
        Thread motor_thread;
        Thread intrusion_thread;

        // Variables for Log file appends   -- ideamonk
        // Change begins [[
            StreamWriter LogSW;
            Byte[] initialContent;
            int MAX_LOG_SIZE;
        // Change ends ]]
        
        // MotorController Process Objetcs  --ideamonk
            static System.Diagnostics.Process proc;

        // Motion Detection Process         --ideamonk
            System.Diagnostics.Process procMotionDetect;

        public Home()
        {
            InitializeComponent();

            //t.Start(stop_check);
            spacelocklinqDataContext data = new spacelocklinqDataContext();
            var query = from c in data.settings
                        where c.user == "admin"
                        select (c.Password);
            foreach (var item in query)
            {
                password = item.TrimEnd(); ;
            }
            /*
            start_button.Enabled=false;
            status_box.Hide();
            stop_button.Enabled=false;
            lock_button.Enabled=false;
            settings_button.Hide();
            */
            // Changes -- ideamonk
                start_button.Enabled = false;
                status_box.Enabled = false;
                stop_button.Enabled = false;
                lock_button.Enabled = false;
                settings_button.Hide();
                picWelcome.Visible = false;
                btnViewLog.Hide();
                btn_Browse.Hide();
            // end Changes


            /* ---------------- Adding stats to a log fine ---------------  -- */
            // Truncate the log if too big
            // = File.ReadAllBytes(Application.StartupPath.ToString() + "\\SpaceLockLog.txt");
                MAX_LOG_SIZE = 102400;          // 100 KB
                try
                {
                    initialContent = File.ReadAllBytes(Application.StartupPath.ToString() + "\\SpaceLockLog.txt");
                    if (initialContent.Length > MAX_LOG_SIZE)
                    {
                        // Empty the log file
                        LogSW = File.CreateText(Application.StartupPath.ToString() + "\\SpaceLockLog.txt");
                        LogSW.WriteLine("SpaceLock Log truncated on " + System.DateTime.Today.ToString() + ", " + DateTime.Now.ToString());
                        LogSW.Close();
                    }
                }
                catch
                {
                    // Log file does not exist
                }

                // Open the log file in append mode
                LogSW = File.AppendText(Application.StartupPath.ToString() + "\\SpaceLockLog.txt");
            // Change Ends --------------- ]]

            // -------------------- Settings for Calling MotorController.exe --ideamonk
                proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = Application.StartupPath.ToString() + "\\MotorController.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = false;
            // Change ends ]]  19 Apr 2009

            // -------------------- Settings for Calling MotionDetect2.exe process --ideamonk
                procMotionDetect = new System.Diagnostics.Process();
                procMotionDetect.StartInfo.FileName = Application.StartupPath.ToString() + "\\MotionDetect2.exe";
                procMotionDetect.StartInfo.UseShellExecute = false;
                procMotionDetect.StartInfo.RedirectStandardOutput = false;
        }
        #endregion

        # region login and lock

        /// <summary>
        /// This vsection contains functions for login and lock
        /// When the user first starts space lock login function is called
        /// login_check variable is set to true
        /// When software is locked lock_button_click is called
        /// To unlock the software lock_spacelock is called
        /// </summary>
        private void login_box_Click(object sender, EventArgs e)
        {
            if (login_check == false)
            {
                timer1.Start();
                motor_thread = new Thread(ThreadedTcpSrvr);
                motor_thread.Start();
                intrusion_thread = new Thread(intr);
                intrusion_thread.Start();
                //************************************************************
                // PRABHAT
                // START MOTION DETECTION USING PROCESS.START()
                //*****************************************************************
                login();                

                //if (login_check)                    // --ideamonk
                  //  procMotionDetect.Start(); 
            }
            else
            {
                lock_spacelock();
            }
        }

        private void lock_spacelock()
        {
            spacelocklinqDataContext data = new spacelocklinqDataContext();
            var query = from c in data.settings
                        where c.user == "admin"
                        select (c.Password);

            foreach (var item in query)
            {
                password = item.TrimEnd(); ;
            }
            if (password_box.Text == password)
            {
                password_box.Hide();
                password_label.Hide();
                settings_button.Hide();
                picWelcome.Visible = false;
                btnViewLog.Hide();
                btn_Browse.Hide();
                login_box.Hide();

                if (stop_check == true)
                {
                    stop_button.Enabled=false;
                    start_button.Enabled=true;
                    settings_button.Show();
                    picWelcome.Visible = true;
                    btnViewLog.Show();
                    btn_Browse.Show();
                    lock_pc_button.Enabled=true;
                    close_button.Enabled=true;
                    lock_button.Enabled=true;
                }
                else
                {
                    stop_button.Enabled=true;
                }
                lock_button.Enabled=true;
            }

            else
            {
                MessageBox.Show("Wrong password!");
            }
        }

        private void login()
        {
            spacelocklinqDataContext data = new spacelocklinqDataContext();
            var query = from c in data.settings
                        where c.user == "admin"
                        select (c.Password);

            foreach (var item in query)
            {
                password = item.TrimEnd(); ;
            }
            if (password_box.Text == password)
            {
                password_box.Hide();
                password_label.Hide();
                login_box.Hide();
                start_button.Enabled=true;
                settings_button.Show();
                picWelcome.Visible = true;
                btnViewLog.Show();
                btn_Browse.Show();
                close_button.Enabled=true;
                lock_button.Enabled=true;
                login_check = true;
            }
            else
                MessageBox.Show("Wrong Password!");

        }

        private void lock_button_Click(object sender, EventArgs e)
        {
            start_button.Enabled=false;
            close_button.Enabled=false;
            stop_button.Enabled=false;
            lock_button.Enabled=false;
            settings_button.Hide();
            picWelcome.Visible = false;
            btnViewLog.Hide();
            btn_Browse.Hide();

            status_box.Show();
            password_box.Text = "";
            password_box.Show();
            password_label.Show();
            login_box.Show();
        }
        #endregion

        #region stop

        /// <summary>
        /// When application is terminated stop_spacelock is called
        /// This method resets all the variable to initial state
        /// Plus the TCP connections are aborted
        /// </summary>
        private void stop_button_Click(object sender, EventArgs e)  // aborts all processes
        {
            stop_spacelock();
        }
        private void stop_spacelock()
        {
            MessageBox.Show("Space Lock has been stopped");
            start_button.Enabled=true;
            close_button.Enabled=true;
            stop_button.Enabled=false;
            lock_button.Enabled=true;
            settings_button.Show();
            picWelcome.Visible = true;
            btnViewLog.Show();
            btn_Browse.Show();
            status_box.Items.Add("Space Lock terminated at: " + DateTime.Now);
            status_box.SelectedIndex = status_box.Items.Count - 1;
            status_box.SelectedIndex = -1;
            AppendLog();

            intrusion_check_variable = false;
            recording_check = false;
            rotation_check_variable = false;
            stop_check = true;
        }
        #endregion

        #region start

        /// <summary>
        /// When the application is started:
        /// Connection with phone is verified
        /// The timer is started
        /// Threads for motor control and intrusion check are strated
        /// </summary>
        private void start_button_Click(object sender, EventArgs e)
        {
            start();
        }
        public void start()
        {    
            
            spacelocklinqDataContext data = new spacelocklinqDataContext();
            var match = (from d in data.GetTable<setting>()
                         where d.user == "admin"
                         select d).SingleOrDefault();
            sms_object.phone_number_change(match.Phone_Number.TrimEnd().ToString(), match.Port_Number);
            start_button.Enabled=false;
            close_button.Enabled=false;
            //settings_button.Enabled = false;
            settings_button.Hide();
            picWelcome.Visible = false;
            btnViewLog.Hide();
            btn_Browse.Hide();

            lock_button.Enabled=false;
            status_box.Show();
            password_box.Text = "";
            password_box.Show();
            password_label.Show();
            login_box.Show();
            stop_check = false;
            intrusion_check_variable = false;
            recording_check = false;
            rotation_check_variable = false;
            status_box.Items.Add("Login at: " + DateTime.Now);
            status_box.SelectedIndex = status_box.Items.Count - 1;
            status_box.SelectedIndex = -1;
            AppendLog();

            if (sms_object.check() == true)
            {
                status_box.Items.Add("Phone Connection Successful at " + DateTime.Now);
                status_box.SelectedIndex = status_box.Items.Count - 1;
                status_box.SelectedIndex = -1;
                AppendLog();
            }
            else
            {
                status_box.Items.Add("Phone Connection Unsuccessful at " + DateTime.Now);
                status_box.SelectedIndex = status_box.Items.Count - 1;
                status_box.SelectedIndex = -1;
                AppendLog();
            }
        }
        #endregion        

        #region timer, close and other functions

        /// <summary>
        /// The setting button invokes the settings form
        /// The timer is responsible for checking if intrusion has occured and accordingly send SMS
        /// This timer calls the functions which reads the incomming messages
        /// The close button terminates the application
        /// The rotation timer is used to stop the motion detection when the motor is being turned
        /// </summary>
        private void lock_pc_button_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }
        private void settings_button_Click(object sender, EventArgs e)
        {
            settings set = new settings();
            set.ShowDialog();
        }
        private void close_button_Click(object sender, EventArgs e)
        {
            try
            {
                motor_thread.Abort();
                intrusion_thread.Abort();
            }
            catch (Exception)
            {
            }
            timer1.Dispose();
            string name;
            //*********************************************************************
            //PRABHAT
            // TERMINATE MOTION DETECTION 
            // BY USING PROCESS.KILL()                      //done down after flushes
            //**************************************************************************
            foreach (Process proc in Process.GetProcesses())
            {
                name = proc.ProcessName;
                //if (name == "Space Lock (Main)")
                if (name == "SpaceLock Alpha")
                {
                    proc.Kill();
                }
            }

            /* Closes the Log file in use       -- ideamonk */
            // Begin Changes [[
            LogSW.Flush();
            LogSW.Close();
            try
            {
                procMotionDetect.Kill();            // kill the motion detector instance
            }
            catch
            {
                //nothing to do
            }

            // End chages ]]

            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (send == "stop")
            {
                send = "null";
                stop_spacelock();
            }
            if (send == "start")
            {
                send = "null";
                start();
            }
            if (stop_check == false)
            {
                if (rotation_check_variable == false)
                {
                    if (intrusion_check_variable == true && recording_check == false)    // a message is sent if intrusion occurs... but it is not sent if the recording has started... only one sms should be sent per recording
                    {
                        status_box.Items.Add("Intrusion Occured at: " + DateTime.Now + "\n");
                        status_box.SelectedIndex = status_box.Items.Count - 1;
                        status_box.SelectedIndex = -1;
                        sms_object.send_sms();
                        if (sms_object.send_sms()==true)
                        {
                            status_box.Items.Add("SMS sent: " + DateTime.Now + "\n");
                            status_box.SelectedIndex = status_box.Items.Count - 1;
                            status_box.SelectedIndex = -1;
                        }
                        else
                        {
                            status_box.Items.Add("Phone connection error SMS could not be sent: " + DateTime.Now + "\n");
                            status_box.SelectedIndex = status_box.Items.Count - 1;
                            status_box.SelectedIndex = -1;
                        }
                        AppendLog();
                    }
                    if (intrusion_check_variable == true && recording_check == false)   // if a new intrusion has occured... start the recording
                    {
                        recording_check = true;
                        status_box.Items.Add("Recording started at " + DateTime.Now + "\n");
                        status_box.SelectedIndex = status_box.Items.Count - 1;
                        status_box.SelectedIndex = -1;
                        AppendLog();
                    }
                    if (intrusion_check_variable == false && recording_check == true)
                    {
                        recording_check = false;
                        status_box.Items.Add("Intrusion ended at: " + DateTime.Now + "\n");
                        status_box.SelectedIndex = status_box.Items.Count - 1;
                        status_box.SelectedIndex = -1;
                        AppendLog();
                    }
                }
                if (rotation_check_variable == true)
                {
                    rotation_timer.Enabled = true;
                    lookuptime_rotation = 10;
                    rotation_timer.Start();
                }
                rotation_check_variable = false;
            }
            read_sms();            
        }
        private void rotation_timer_Tick(object sender, EventArgs e)
        {
            lookuptime_rotation = 0;
            rotation_timer.Enabled = false;            
        }

        #endregion

        #region read sms

        /// <summary>
        /// This method constatly checks with the phone for any incomming message
        /// If a desired message is received from a particulaar number
        /// The application is either started or terminated
        /// </summary>


        private void read_sms()
        {

            SmsSubmitPdu pdu;
            string phone_number = "";
            int newPort = 10;
            spacelocklinqDataContext data = new spacelocklinqDataContext();
            var query = (from c in data.GetTable<setting>()
                         where c.user == "admin"
                         select c).SingleOrDefault();
            try
            {
                phone_number = query.Phone_Number.TrimEnd();
                newPort = query.Port_Number;
            }
            catch (Exception)
            {

            }
            send = "null";
            GsmCommMain comm = new GsmCommMain(newPort, 19200, 300);
            string storage = string.Empty;
            while (true)
            {
                try
                {
                    comm.Open();
                }
                catch (Exception)
                {
                    break;
                }

                storage = PhoneStorageType.Phone;
                SmsDeliverPdu del;
                DecodedShortMessage[] messages;
                try
                {
                    messages = comm.ReadMessages(PhoneMessageStatus.All, storage);
                }
                catch (Exception)
                {
                    break;
                }
                foreach (DecodedShortMessage message in messages)
                {
                    try
                    {
                        del = (SmsDeliverPdu)(message.Data);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (del.UserDataText == "STOP" && del.OriginatingAddress == phone_number)
                    {
                        if (stop_check == false)
                        {
                            try
                            {
                                comm.DeleteMessage(message.Index, storage);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            pdu = new SmsSubmitPdu("Space Lock has been deactivated", phone_number);
                            comm.SendMessage(pdu);
                            stop_check = true;
                            send = "stop";
                            //MessageBox.Show("STOP");  --ideamonk commented
                            try
                            {
                                comm.DeleteMessage(message.Index, storage);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    if (del.UserDataText == "STOP" && del.OriginatingAddress == phone_number)
                    {
                        if (stop_check == true)
                        {
                            pdu = new SmsSubmitPdu("Wrong message! Space Lock has ALREADY been deactivated", phone_number);
                            comm.SendMessage(pdu);
                            try
                            {
                                comm.DeleteMessage(message.Index, storage);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    if (del.UserDataText == "START" && del.OriginatingAddress == phone_number)
                    {
                        if (stop_check == true)
                        {
                            try
                            {
                                comm.DeleteMessage(message.Index, storage);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            pdu = new SmsSubmitPdu("Space Lock has started", phone_number);
                            // the message is sent
                            comm.SendMessage(pdu);
                            stop_check = false;
                            send = "start";
                            try
                            {
                                comm.DeleteMessage(message.Index, storage);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    if (del.UserDataText == "START" && del.OriginatingAddress == phone_number)
                    {
                        if (stop_check == false)
                        {
                            pdu = new SmsSubmitPdu("Space Lock is already running", phone_number);
                            // the message is sent
                            comm.SendMessage(pdu);
                            try
                            {
                                comm.DeleteMessage(message.Index, storage);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                }
                break;
            }
            try
            {
                comm.Close();

            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region MotorControl & Intrusion Check
       
        /// <summary>
        /// This method communicates with ASP.NET MVC using TCP sockets
        /// It takes the input left, right, up or down
        /// Accordingly the output is given out to the motors
        /// Once motors have been actuated a message is sent to the image processor to terminate the motion detection
        /// This method also communicates with image processor
        /// If intrusion has occured the intrusion variable is updated
        /// </summary>
        public static void ThreadedTcpSrvr()
        {  
            TcpListener client1;
            try
            {
                client1 = new TcpListener(9080);
                client1.Start();
                while (close_check==false)
                {
                        while (!client1.Pending())
                        {
                            Thread.Sleep(1000);
                        }
                        ConnectionThread_rotation newconnection = new ConnectionThread_rotation();
                        newconnection.threadListener = client1;
                        Thread newthread = new Thread(new ThreadStart(newconnection.HandleConnection));
                        newthread.Start();
                }                
            }
            catch (Exception)
            {
            }
         }
        static int test_temp = 0;
        public static void intr()
        {
            TcpListener client;
            Thread newthread;
            try
            {
                client = new TcpListener(9050);
                client.Start();
                while (true)
                {
                    
                    while (!client.Pending())
                    {
                        Thread.Sleep(1000);
                    }
                    ConnectionThread_intrusion newconnection = new ConnectionThread_intrusion();
                    newconnection.threadListener = client;
                    newthread = new Thread(new ThreadStart(newconnection.HandleConnection));                    
                    newthread.Start();
                }
            }
            catch (Exception)
            {
            }
        }
      
        class ConnectionThread_rotation
        {
            public TcpListener threadListener;
            public void HandleConnection()
            {
                int recv;
                byte[] data = new byte[1024];
                TcpClient client = threadListener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                while (true)
                {
                    Application.DoEvents();
                    data = new byte[1024];
                    try
                    {
                        recv = ns.Read(data, 0, data.Length);
                        string test = Encoding.ASCII.GetString(data, 0, recv);
                        if (test == "LEFT")
                        {
                            //MessageBox.Show("LEFT");
                            //      Calls MotorController.exe with appropriate arguments -- ideamonk
                            try
                            {
                                proc.StartInfo.Arguments = "SpaceLock left";
                                proc.Start();
                            }
                            catch
                            {
                                MessageBox.Show("MotorController.exe is missing!");
                            }
                           
                            rotation_check_variable = true;
                        }
                        if (test == "RIGHT")
                        {
                            //MessageBox.Show("RIGHT");

                            //      Calls MotorController.exe with appropriate arguments -- ideamonk
                            try
                            {
                                proc.StartInfo.Arguments = "SpaceLock right";
                                proc.Start();
                            }
                            catch
                            {
                                MessageBox.Show("MotorController.exe is missing!");
                            }

                            rotation_check_variable = true;
                        }
                        if (test == "UP")
                        {
                            //MessageBox.Show("UP");
                            //      Calls MotorController.exe with appropriate arguments -- ideamonk
                            try
                            {
                                proc.StartInfo.Arguments = "SpaceLock up";
                                proc.Start();
                            }
                            catch
                            {
                                MessageBox.Show("MotorController.exe is missing!");
                            }

                            rotation_check_variable = true;
                        }
                        if (test == "DOWN")
                        {
                            //MessageBox.Show("DOWN");
                            //      Calls MotorController.exe with appropriate arguments -- ideamonk
                            try
                            {
                                proc.StartInfo.Arguments = "SpaceLock down";
                                proc.Start();
                            }
                            catch
                            {
                                MessageBox.Show("MotorController.exe is missing!");
                            }


                            rotation_check_variable = true;
                        }
                        if (rotation_check_variable)
                        { 
                            data=Encoding.ASCII.GetBytes("ROTATION");
                            ns.Write(data, 0, data.Length);
                        }
                        if (lookuptime_rotation == 0)
                        {
                            data = Encoding.ASCII.GetBytes("NOROTATION");
                            ns.Write(data, 0, data.Length);
                        }
                        if (stop_check == true)
                        {
                            data = Encoding.ASCII.GetBytes("STOP");
                            ns.Write(data, 0, data.Length);
                        }
                        if (stop_check == false)
                        {
                            data = Encoding.ASCII.GetBytes("START");
                            ns.Write(data, 0, data.Length);
                        }

                        data = Encoding.ASCII.GetBytes("R");
                        ns.Write(data, 0, data.Length);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                ns.Close();
                client.Close();
            }
        }           

        class ConnectionThread_intrusion
        {
            public TcpListener threadListener;
            public void HandleConnection()
            {
                int recv;
                byte[] data = new byte[1024];
                TcpClient client = threadListener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                while (true)
                {
                    Application.DoEvents();
                    data = new byte[1024];
                    try
                    {
                        recv = ns.Read(data, 0, data.Length);
                        string test = Encoding.ASCII.GetString(data, 0, recv);
                        if (test == "INTRUSION")
                        {
                            intrusion_check_variable = true;
                            test_temp = 1;
                        }
                        if (test == "STOP")
                        {
                            intrusion_check_variable = false;
                            test_temp = 1;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                ns.Close();
                client.Close();
            }
        }
        #endregion                        

        #region Viewing the Videos from control module
        // Additional Button to Browse Video Archives Locally -- ideamonk
        // [[ begin changes
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath.ToString() + "\\WebInterface\\Content\\videos");
            }
            catch 
            {
                MessageBox.Show ("Failed to find videos, check if IIS is configured properly.");
            }

        }

        private void AppendLog()
        {
            try
            {
                LogSW.WriteLine(status_box.Items[status_box.Items.Count - 1]);
                LogSW.Flush();
            }
            catch
            {
                status_box.Items.Add("!! Error writing to log file " + DateTime.Now);
                status_box.SelectedIndex = status_box.Items.Count - 1;
                status_box.SelectedIndex = -1;
                AppendLog();
            }
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath.ToString() + "\\SpaceLockLog.txt");
            }
            catch
            {
                MessageBox.Show("Error Accessing Logfile!");
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
        // End Changes ]]
        #endregion
    }
        
}