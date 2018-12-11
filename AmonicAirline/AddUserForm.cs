using FormUtilitiesLibrary;
using HashLibrary;
using Session1Library;
using System;
using System.Data.Entity.Validation;
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

            using (var session = new Session1Entities())
            {
                var query = session.Offices.Select(o => new { o.ID, o.Title });
                var result = query.ToList();

                comboBoxOffice.DisplayMember = "Title";
                comboBoxOffice.ValueMember = "ID";
                comboBoxOffice.DataSource = result;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckFields.CheckIfFieldsIsNotEmpty(this))
            {
                var email = textBoxEmail.Text;
                if (CheckFields.IsValidEmail(email))
                {
                    using (var session = new Session1Entities())
                    {
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
                            try
                            {
                                session.SaveChanges();
                                adminMainForm.SetDatagridView();
                                ClearFields.ClearTextBoxes(this);
                                dateTimePickerBirthdate.ResetText();
                            }
                            catch (DbEntityValidationException ex)
                            {
                                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                                var fullErrorMessage = string.Join("\n", errorMessages);
                                var exceptionMessage = $"Error : {fullErrorMessage}";
                                MessageBox.Show(exceptionMessage);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter another email :\nThat email is already used by another user");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a valid email.");
                }
            }
            else
            {
                MessageBox.Show("Please fill all of the fields first.");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}