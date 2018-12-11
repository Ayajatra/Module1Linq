using System.Windows.Forms;

namespace FormUtilitiesLibrary
{
    public static class ClearFields
    {
        /// <summary>
        /// Empty Text of all TextBox in the Form.
        /// </summary>
        /// <param name="form">Form that will be cleared</param>
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

        /// <summary>
        /// Empty Items of all ComboBox in the Form.
        /// </summary>
        /// <param name="form">Form that will be cleared</param>
        public static void ClearComboBoxes(Form form)
        {
            foreach (var control in form.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).Items.Clear();
                }
            }
        }

        /// <summary>
        /// Uncheck all CheckBox in the Form.
        /// </summary>
        /// <param name="form">Form that will be cleared.</param>
        public static void UncheckCheckBoxes(Form form)
        {
            foreach (var control in form.Controls)
            {
                if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
            }
        }
    }
}