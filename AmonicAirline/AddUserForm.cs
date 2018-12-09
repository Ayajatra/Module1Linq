using FormUtilitiesLibrary;
using HashLibrary;
using Session1Library;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class AddUserForm : Form
    {
        private AdminMainForm adminMainForm;

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            adminMainForm = (AdminMainForm)Owner;

            // TODO: Move it to a method in a class (See: Line 23(AddUserForm), Line 24(AdminMainForm))
            // Get all Office ID and Title, then set it to comboBoxOffice.

            using (var session = new Session1Entities())
            {
                var query = from o in session.Offices
                            select new { o.ID, o.Title };

                var result = query.ToDictionary(o => o.ID, o => o.Title);

                comboBoxOffice.DataSource = new BindingSource(result, null);
                comboBoxOffice.DisplayMember = "Value";
                comboBoxOffice.ValueMember = "Key";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var session = new Session1Entities())
            {
                var email = textBoxEmail.Text;
                if (session.Users.Where(u => u.Email == email).FirstOrDefault() == null)
                {
                    var newUser = new User()
                    {
                        ID = Utilities.GetLastUserID() + 1,
                        Email = textBoxEmail.Text,
                        FirstName = textBoxFirstName.Text,
                        LastName = textBoxLastName.Text,
                        OfficeID = int.Parse(comboBoxOffice.SelectedValue.ToString()),
                        Birthdate = dateTimePickerBirthdate.Value,
                        Password = Hash.MakeMd5(textBoxPassword.Text),
                        RoleID = 2,
                        Active = true
                    };
                    session.Users.Add(newUser);
                    session.SaveChanges();
                    adminMainForm.SetDatagridView();
                    ClearFields.ClearTextBoxes(this);
                    dateTimePickerBirthdate.ResetText();
                }
                else
                {
                    MessageBox.Show("Please enter another email :\nThat email is already used by another user");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}