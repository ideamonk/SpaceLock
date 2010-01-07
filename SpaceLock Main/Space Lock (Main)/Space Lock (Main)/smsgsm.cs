using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;

class smsgsm
    {
        int newPort;  // the com port at which the phone is connected
        
        string phone_number;
        public void phone_number_change(string num, int port)
        {
            phone_number=num;
            newPort = port;
        }

        public bool check()
        {
       
            GsmCommMain comm = new GsmCommMain(newPort, 19200, 300);
            // try the connection at given COM port number
            try
            {
                comm.Open();
                comm.Close();
                return true;
            }
            // if the connection is unsuccesful exception is thrown
            catch (Exception)
            {
                return false;
            }
        }

        public bool send_sms()
        {
            GsmCommMain comm = new GsmCommMain(newPort, 19200, 300);
            // sent the sms
            try
            {
                comm.Open();
                // this pdu object stores the message and phone number
                SmsSubmitPdu pdu;
                string data = DateTime.Now.ToString();
                pdu = new SmsSubmitPdu("Intrusion Occured At: "+data, phone_number);
                // the message is sent
                comm.SendMessage(pdu);
                comm.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

