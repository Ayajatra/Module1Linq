using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUtilitiesLibrary
{
    public static class ClearFields
    {
        public static void ClearTextBoxes(Form form)
        {
            foreach (var control in form.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
            }
        }
    }
}
