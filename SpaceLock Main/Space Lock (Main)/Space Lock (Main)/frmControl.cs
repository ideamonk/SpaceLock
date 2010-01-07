using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Space_Lock__Main_
{
    public partial class frmControl : Form
    {
        System.Diagnostics.Process proc;
        public frmControl()
        {
            InitializeComponent();

            proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = Application.StartupPath.ToString() + "\\MotorController.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = false;
        }

        private void MissingError()
        {
            MessageBox.Show(this, "MotorController.exe is missing!", "Missing Component", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                proc.StartInfo.Arguments = "SpaceLock up";
                proc.Start();
            }
            catch
            {
                MissingError();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            try
            {
                proc.StartInfo.Arguments = "SpaceLock left";
                proc.Start();
            }
            catch
            {
                MissingError();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                proc.StartInfo.Arguments = "SpaceLock down";
                proc.Start();
            }
            catch
            {
                MissingError();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            try
            {
                proc.StartInfo.Arguments = "SpaceLock right";
                proc.Start();
            }
            catch
            {
                MissingError();
            }
        }

        private void frmControl_Load(object sender, EventArgs e)
        {

        }
    }
}
