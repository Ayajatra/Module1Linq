using FormUtilitiesLibrary;
using Session1Library;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class EditRoleForm : Form
    {
        public EditRoleForm()
        {
            InitializeComponent();
        }

        private AdminMainForm adminMain;

        private void EditRoleForm_Load(object sender, EventArgs e)
        {
            using (var session = new Session1Entities())
            {
                var query = session.Offices.Select(o => new { o.ID, o.Title });
                var result = query.ToList();

                comboBoxOffice.DisplayMember = "Title";
                comboBoxOffice.ValueMember = "ID";
                comboBoxOffice.DataSource = result;
            }

            adminMain = (AdminMainForm)Owner;
            var row = adminMain.dataGridView.CurrentCell.OwningRow;
            textBoxEmailAddress.Text = row.Cells["EmailAddress"].Value.ToString();
            textBoxFirstName.Text = row.Cells["Name"].Value.ToString();
            textBoxLastName.Text = row.Cells["LastName"].Value.ToString();
            comboBoxOffice.Text = row.Cells["Office"].Value.ToString();
            if (row.Cells["UserRole"].Value.ToString() == "Administrator")
            {
                radioButtonAdministrator.Checked = true;
            }
            else
            {
                radioButtonUser.Checked = true;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (CheckFields.CheckIfFieldsIsNotEmpty(this))
            {
                var row = adminMain.dataGridView.CurrentCell.OwningRow;
                // rowEmail is here so that there's no error about LINQ
                // not being able to convert it to LINQ expression
                // please don't remove it

                if (CheckFields.IsValidEmail(textBoxEmailAddress.Text))
                {
                    using (var session = new Session1Entities())
                    {
                        var rowEmail = row.Cells["EmailAddress"].Value.ToString();
                        var rowSearch = session.Users.Where(u => u.Email == textBoxEmailAddress.Text).FirstOrDefault();
                        if (rowSearch == null || rowEmail == textBoxEmailAddress.Text)
                        {
                            // id is here so that there's no error about LINQ
                            // not being able to convert it to LINQ expression
                            // please don't remove it
                            var id = int.Parse(row.Cells["ID"].Value.ToString());
                            var rowEdit = session.Users.Where(u => u.ID == id).FirstOrDefault();
                            rowEdit.Email = textBoxEmailAddress.Text;
                            rowEdit.FirstName = textBoxFirstName.Text;
                            rowEdit.LastName = textBoxLastName.Text;
                            rowEdit.OfficeID = int.Parse(comboBoxOffice.SelectedValue.ToString());
                            rowEdit.RoleID = radioButtonAdministrator.Checked ? 1 : 2;

                            try
                            {
                                session.SaveChanges();
                                adminMain.SetDatagridView();
                                Close();
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
                            MessageBox.Show("Email Address has already been taken.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid email.");
                }
            }
            else
            {
                MessageBox.Show("Please don't leave any fields empty.");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}