using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Customer_Service
{
    public static class DB
    {
        public static OdbcConnection Cn = new OdbcConnection();

        public static void Connect(string server, string port, string user, string password)
        {
            try
            {
                if (Cn == null)
                {
                    Cn = new OdbcConnection();
                }
                if (Cn.State != ConnectionState.Open)
                {
                    Cn.ConnectionString = "Provider=MSDASQL.1" +
                        ";Driver={MySQL ODBC 5.3 UNICODE Driver}" +
                        ";Server=" + server +
                        ";Port=" + port +
                        ";Database=service" +
                        ";User=" + user +
                        ";Password=" + password +
                        ";Option=3";
                    Cn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        public static void Disconnect()
        {
            try
            {
                if (Cn == null) return;
                if (Cn.State == ConnectionState.Closed) return;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
