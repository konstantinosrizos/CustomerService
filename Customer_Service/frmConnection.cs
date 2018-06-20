using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Service
{
    public partial class frmConnection : Form
    {
        public frmConnection()
        {
            InitializeComponent();
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            setpicturestate();
        }

        private void setpicturestate()
        {
            try
            {
                if (DB.Cn == null || DB.Cn.State != ConnectionState.Open)
                {
                    pictureBoxConnect.Image = Image.FromFile
                    (Environment.GetFolderPath
                    (Environment.SpecialFolder.UserProfile)
                    + @"\source\repos\Customer_Service\Customer_Service\assets\Traffic_light_Red.jpg");
                }
                else
                {
                    pictureBoxConnect.Image = Image.FromFile
                    (Environment.GetFolderPath
                    (Environment.SpecialFolder.UserProfile)
                    + @"\source\repos\Customer_Service\Customer_Service\assets\Traffic_light_Green.jpg");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Connect(txtServer.Text, txtPort.Text, txtUser.Text, txtPass.Text);
            }
            finally { setpicturestate(); };
            if (DB.Cn.State == ConnectionState.Open)
            {
                //this.Close();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Disconnect();
            }
            finally { setpicturestate(); };
        }

        private void btnConnect_MouseHover(object sender, EventArgs e)
        {
            btnConnect.BackColor = Color.AliceBlue;
        }

        private void btnDisconnect_MouseHover(object sender, EventArgs e)
        {
            btnDisconnect.BackColor = Color.AliceBlue;
        }
    }
}
