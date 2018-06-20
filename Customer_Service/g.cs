using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Service
{
    public enum findmode : int
    {
        List = 1
        //Category = 2
    };

    public struct FindStruct
    {
        public string ID;
        public bool Changed;
        public findmode Mode;
    }

    public static class g
    {
        public static FindStruct find;
        public static void ClearForm(Control parent)
        {
            Type t;
            foreach (Control cnt in parent.Controls)
            {
                t = cnt.GetType();
                if (t == typeof(TextBox)) cnt.Text = "";
                else if (t == typeof(RichTextBox)) cnt.Text = "";
            }
        }


    }
}
