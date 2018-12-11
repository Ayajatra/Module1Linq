using System.Windows.Forms;

namespace FormUtilitiesLibrary
{
    public static class CheckFields
    {
        public static bool CheckIfFieldsIsNotEmpty(Form form)
        {
            bool isTextBoxNotEmpty = true;
            bool isRadioButtonNotEmpty = true;
            foreach (var control in form.Controls)
            {
                if (control is TextBox)
                {
                    if (isTextBoxNotEmpty)
                    {
                        if (string.IsNullOrWhiteSpace(((TextBox)control).Text))
                        {
                            isTextBoxNotEmpty = false;
                        }
                    }
                }
                else if (control is RadioButton)
                {
                    if (!isRadioButtonNotEmpty)
                    {
                        if (((RadioButton)control).Checked)
                        {
                            isRadioButtonNotEmpty = true;
                        }
                    }
                }
            }

            return isTextBoxNotEmpty && isRadioButtonNotEmpty ? true : false;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                if (email == "")
                {
                    return false;
                }

                var _email = email.Split('@');
                if (_email.Length == 2 && _email[0] != "" && _email[1] != "")
                {
                    var _email2 = _email[1].Split('.');
                    if (_email2.Length == 2 && _email2[0] != "" && _email2[1] != "")
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}