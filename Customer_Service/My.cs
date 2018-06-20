using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Customer_Service
{
    public static class My
    {
        public static string Quote(string s)
        {
            string retv;
            retv = s.Replace("'", "''").Replace("\"", @"""").Replace("--", "");
            return "'" + @retv + "'";
        }

        public static void LVLoad(System.Windows.Forms.ListView LV,
                                    System.Data.Odbc.OdbcDataReader reader,
                                    bool bUpdateHeaders)
        {
            int i = 0, nFields = 0, nRows = 0;
            string s;

            try
            {
                LV.BeginUpdate();
                LV.Sorting = SortOrder.None;
                LV.Items.Clear();

                if (bUpdateHeaders == true)
                {
                    LV.Columns.Clear();
                    nFields = reader.FieldCount;
                    for (i = 0; i < nFields; i++)
                    {
                        LV.Columns.Add(reader.GetName(i));
                    }
                }

                nRows = 0;
                while (reader.Read())
                {
                    s = reader.GetValue(0).ToString();
                    LV.Items.Add(s);

                    for (i = 1; i < nFields; i++)
                    {
                        s = reader.GetValue(i).ToString();
                        LV.Items[nRows].SubItems.Add(s);
                    }
                    nRows += 1;
                }

                LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LV.EndUpdate();

            }catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
            }
        }
    }
}
