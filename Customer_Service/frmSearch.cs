using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Customer_Service
{
    public partial class frmSearch : Form
    {
        OdbcCommand cmd;
        OdbcDataReader reader;

        findmode mode;
        string SQL;

        public frmSearch()
        {
            InitializeComponent();
            cmd = new OdbcCommand();
            cmd.Connection = DB.Cn;
            LVInit(LV1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (LV1.SelectedIndices.Count == 0) return;
            g.find.ID = LV1.SelectedItems[0].Text;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            g.find.ID = "-1";
            this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                go();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            go();
        }

        private void go()
        {
            if (mode == findmode.List)
            {
                SQL = "SELECT customerId As ID, customerName As Name, deviceType As Device, customerPhone As Phone, Left(description,50) As Description" +
                        " FROM list WHERE customerName LIKE ?";
            }
            /*else if (mode == findmode.Category)
            {
                SQL = "SELECT CategoryID, CategoryName, Left(Description,50) As Description" +
                        " FROM categories WHERE CategoryName LIKE ?";
            }*/
            else
            {
                return;
            }

            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@param", txtSearch.Text + "%");
                reader = cmd.ExecuteReader();

                g.find.Changed = false;
                My.LVLoad(LV1, reader, true);
                if (LV1.Items.Count > 0)
                {
                    LV1.Focus();
                    LV1.Items[0].Selected = true;
                }
                if (reader != null) { reader.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LVInit(ListView LV)
        {
            LV.View = View.Details;
            LV.LabelEdit = true;
            LV.GridLines = true;
            LV.FullRowSelect = true;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            mode = g.find.Mode;
        }

        private void frmSearch_Activated(object sender, EventArgs e)
        {
            if (g.find.Changed) { go(); }
        }

        private void btnGo_MouseEnter(object sender, EventArgs e)
        {
            btnGo.BackColor = Color.LightCyan;
        }

        private void btnGo_MouseLeave(object sender, EventArgs e)
        {
            btnGo.BackColor = Color.White;
        }

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            btnOK.BackColor = Color.LightCyan;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.BackColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.LightCyan;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
        }
    }
}
