using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Odbc;


namespace Customer_Service
{
    public partial class Service : Form
    {

        OdbcCommand cmd;
        OdbcDataReader reader;

        private static frmSearch f;

        Boolean modeNew = false;
        Boolean bImgChange = false;
        int rowsAffected = 0;
        Int32 ID =- 1, oldID =- 1;

        Image img = null;
        byte[] ImgBytes;
        String SQL;
        String msg;

        public Service()
        {
            InitializeComponent();
            cmd = new OdbcCommand();
            cmd.Connection = DB.Cn;
        }

        private void Service_Load(object sender, EventArgs e)
        {
            EnableBtns(false);
            EnableInputs(false, false);
        }

        private void loadData()
        {
            clearForm();
            if (ID <= 0) return;
            try
            {
                String SQL = "SELECT customerId,customerName,deviceType,description," +
                                "devicePhoto,customerPhone FROM list WHERE customerId=?";

                cmd.Parameters.Clear();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@customerId", ID);
                reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    return;
                }

                txtServiceID.Text = reader["customerId"].ToString();
                txtServiceName.Text = reader["customerName"].ToString();
                txtServiceType.Text = reader["deviceType"].ToString();
                txtServicePhone.Text = reader["customerPhone"].ToString();
                txtDescription.Text = reader["description"].ToString();

                if (reader["devicePhoto"] != System.DBNull.Value)
                {
                    ImgBytes = (byte[])reader["devicePhoto"];
                    if(ImgBytes.Length != 0) {
                        MemoryStream ms = null;

                        if (ImgBytes[0] == 0x15 && ImgBytes[1] == 0x1C)
                        {
                            //Ms Access , add 78 bytes in headwe
                            ms = new MemoryStream(ImgBytes, 78, ImgBytes.Length - 78);
                        }
                        else
                        {
                            ms = new MemoryStream(ImgBytes);
                        }
                        img = Image.FromStream(ms);
                        pictureBoxDevice.Image = img;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        } 

        private void clearForm()
        {
            g.ClearForm(datapanel);
            this.pictureBoxDevice.Image = null;
            bImgChange = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            g.find.Mode = findmode.List;
            int tempid;
            showFormSearch();
            try
            {
                tempid = Int32.Parse(g.find.ID);
            }catch
            {
                tempid = -1;
            }
            if (tempid < 0) return;
            oldID = ID;
            ID = tempid;
            loadData();
        }

        private void showFormSearch()
        {
            if (f == null)
            {
                f = new frmSearch();
            }
            f.ShowDialog();
        }

        private void EnableBtns(Boolean b)
        {
            this.btnSearch.Enabled = !b;
            this.btnEdit.Enabled = !b;
            this.btnNew.Enabled = !b;

            this.btnImageBrowse.Enabled = b;
            this.btnImageNull.Enabled = b;

            this.btnSave.Enabled = b;
            this.btnCancel.Enabled = b;
            this.btnDelete.Enabled = b;
            modeNew = false;
        }

        private void EnableInputs(Boolean b, Boolean bkey)
        {
            this.txtServiceID.ReadOnly = !bkey;
            this.txtServiceName.ReadOnly = !b;
            this.txtServiceType.ReadOnly = !b;
            this.txtServicePhone.ReadOnly = !b;
            this.txtDescription.ReadOnly = !b;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ID <= 0) return;
            EnableInputs(true, false);
            EnableBtns(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (!checkToSave()) return;

            try
            {
                if (!modeNew)
                {
                    SQL = "UPDATE list SET " +
                            "customerName=?, deviceType=?, description=?, customerPhone=? WHERE customerId=?";

                    cmd.Parameters.Clear();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@customerName", txtServiceName.Text);
                    cmd.Parameters.AddWithValue("@deviceType", txtServiceType.Text);
                    cmd.Parameters.AddWithValue("@description", this.txtDescription.Text);
                    cmd.Parameters.AddWithValue("@customerPhone", txtServicePhone.Text);
                    cmd.Parameters.AddWithValue("@customerId", ID);
                    rowsAffected = cmd.ExecuteNonQuery();
                } else
                {
                    if (!Int32.TryParse(txtServiceID.Text, out ID)) return;

                    SQL = "INSERT INTO list(customerId,customerName,deviceType,description,customerPhone)" +
                            " VALUES(?,?,?,?,?)";

                    cmd.Parameters.Clear();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@customerId", ID);
                    cmd.Parameters.AddWithValue("@customerName", txtServiceName.Text);
                    cmd.Parameters.AddWithValue("@deviceType", txtServiceType.Text);
                    cmd.Parameters.AddWithValue("@description", this.txtDescription.Text);
                    cmd.Parameters.AddWithValue("@customerPhone", txtServicePhone.Text);
                    rowsAffected = cmd.ExecuteNonQuery();
                }

                if (bImgChange == true)
                {
                    if (this.pictureBoxDevice.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        this.pictureBoxDevice.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ImgBytes = ms.ToArray();
                        SQL = "UPDATE list SET devicePhoto=?" +
                                " WHERE customerId=?";
                    }else
                    {
                        SQL = "UPDATE list SET devicePhoto=null" +
                                " WHERE customerId=?";
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = SQL;
                    if (this.pictureBoxDevice.Image != null)
                    {
                        cmd.Parameters.AddWithValue("@devicePhoto", ImgBytes);
                    }
                    cmd.Parameters.AddWithValue("@customerId", ID);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                g.find.Changed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + SQL);
            }
            reloadRecord();
        }

        private void reloadRecord()
        {
            EnableInputs(false, false);
            EnableBtns(false);
            loadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reloadRecord();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearForm();
            EnableInputs(true, true);
            EnableBtns(true);
            modeNew = true;
        }

        private Boolean checkToSave()
        {
            Int32 tempid = -1, x = -1;

            msg = "";

            if (this.txtServiceID.Text == "")
            {
                if (msg == "") this.txtServiceID.Focus();
                msg += "\n You must fill the ID";
            } else
            {
                try
                {
                    tempid = Int32.Parse(this.txtServiceID.Text);
                }
                catch
                {
                    if (msg == "") this.txtServiceID.Focus();
                    msg += "\n 2:serviceId";
                }
            }

            if (this.txtServiceName.Text == "")
            {
                if (msg == "") this.txtServiceName.Focus();
                msg += "\n You must fill the Name";
            }

            if (this.txtServiceType.Text == "")
            {
                if (msg == "") this.txtServiceType.Focus();
                msg += "\n You must fill the Type";
            }

            if (this.txtServicePhone.Text == "")
            {
                if (msg == "") this.txtServicePhone.Focus();
                msg += "\n You must fill the Phone";
            }

            if (this.txtDescription.Text == "")
            {
                if (msg == "") this.txtDescription.Focus();
                msg += "\n You must fill the Description";
            }

            //Database Query
            if (modeNew == true && tempid != -1)
            {
                SQL = "SELECT count(*) FROM list WHERE customerId=?";
                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@customerId", tempid);
                    var v = cmd.ExecuteScalar();
                    x = (v == null) ? 0 : Convert.ToInt32(v);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (x > 0)
                {
                    msg += "\n Current ID exist in Database";
                }
            }

            if (msg != "")
            {
                MessageBox.Show(msg);
                return false;
            }else
            {
                return true;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!modeNew)
            {
                try
                {
                    SQL = "DELETE FROM list" +
                            " WHERE customerId=?";

                    cmd.Parameters.Clear();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@customerId", ID);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            reloadRecord();
        }

        private void btnImageNull_Click(object sender, EventArgs e)
        {
            if (pictureBoxDevice.Image != null)
            {
                pictureBoxDevice.Image = null;
                bImgChange = true;
            }
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                string filename = "";
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.FileName = "";
                openFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs JPEGs|*.gif;*.jpg";
                openFileDialog.FilterIndex = 3;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = openFileDialog.FileName;
                    pictureBoxDevice.Image = Image.FromFile(filename);
                    bImgChange = true;
                }
            }
            finally
            {

            }
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.LightCyan;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.White;
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.LightCyan;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.White;
        }

        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnNew.BackColor = Color.LightCyan;
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackColor = Color.White;
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.LightCyan;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.White;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.LightCyan;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.LightCyan;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.White;
        }

        private void btnImageNull_MouseEnter(object sender, EventArgs e)
        {
            btnImageNull.BackColor = Color.LightCyan;
        }

        private void btnImageNull_MouseLeave(object sender, EventArgs e)
        {
            btnImageNull.BackColor = Color.White;
        }

        private void btnImageBrowse_MouseEnter(object sender, EventArgs e)
        {
            btnImageBrowse.BackColor = Color.LightCyan;
        }

        private void btnImageBrowse_MouseLeave(object sender, EventArgs e)
        {
            btnImageBrowse.BackColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
