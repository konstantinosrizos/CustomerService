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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show();
            showConnectionForm();
        }

        private void showConnectionForm()
        {
            new frmConnection().ShowDialog();
        }

        private void showService()
        {
            new Service().Show();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            showService();
        }

        private void btnConnect_MouseEnter(object sender, EventArgs e)
        {
            btnConnect.BackColor = Color.LightCyan;
        }

        private void btnConnect_MouseLeave(object sender, EventArgs e)
        {
            btnConnect.BackColor = Color.White;
        }

        private void btnService_MouseEnter(object sender, EventArgs e)
        {
            btnService.BackColor = Color.LightCyan;
        }

        private void btnService_MouseLeave(object sender, EventArgs e)
        {
            btnService.BackColor = Color.White;
        }
    }
}
