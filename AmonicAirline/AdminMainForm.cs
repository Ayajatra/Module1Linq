using Session1Library;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            using (var session = new Session1Entities())
            {
                var query = session.Offices.Select(o => new
                {
                    o.ID,
                    o.Title
                });

                var result = query.ToList();
                // Add All offices option and then sort it based on ID

                result.Add(new { ID = 0, Title = "All Offices" });
                result = result.OrderBy(o => o.ID).ToList();

                comboBoxOffice.ValueMember = "ID";
                comboBoxOffice.DisplayMember = "Title";
                comboBoxOffice.DataSource = result;

                comboBoxOffice.SelectedIndexChanged += ComboBoxOffice_SelectedIndexChanged;
                SetDatagridView();
            }
        }

        private void ComboBoxOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDatagridView();
        }

        public void SetDatagridView()
        {
            // If value == 0 : All Office will be shown.
            int value = int.Parse(comboBoxOffice.SelectedValue.ToString());
            using (var session = new Session1Entities())
            {
                if (value != 0)
                {
                    var query = session.Users.Where(u => u.Office.ID == value).Select(u => new
                    {
                        u.ID,
                        Name = u.FirstName,
                        u.LastName,
                        Age = DateTime.Now.Year - u.Birthdate.Value.Year,
                        UserRole = u.Role.Title,
                        EmailAddress = u.Email,
                        Office = u.Office.Title,
                        u.Active
                    });

                    dataGridView.DataSource = query.ToList();
                }
                else
                {
                    var query = session.Users.Select(u => new
                    {
                        u.ID,
                        Name = u.FirstName,
                        u.LastName,
                        Age = DateTime.Now.Year - u.Birthdate.Value.Year,
                        UserRole = u.Role.Title,
                        EmailAddress = u.Email,
                        Office = u.Office.Title,
                        u.Active
                    });

                    dataGridView.DataSource = query.ToList();
                }
            }

            dataGridView.Columns["ID"].Visible = false;
            dataGridView.Columns["Active"].Visible = false;
            GiveColor();
        }

        private void GiveColor()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Check if the User is active or not
                // if not active : Give red color

                // Reset all of the affected cells color
                row.DefaultCellStyle.BackColor = default(Color);
                row.DefaultCellStyle.ForeColor = default(Color);

                // Set UserRole Color
                if (row.Cells["UserRole"].Value.ToString() == "Administrator")
                {
                    row.DefaultCellStyle.BackColor = Color.DarkGreen;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

                // Set Suspended Color
                if (row.Cells["Active"].Value.ToString() == "False")
                {
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelAddUser_Click(object sender, EventArgs e)
        {
            var addUserForm = new AddUserForm();
            addUserForm.Owner = this;
            addUserForm.ShowDialog();
        }

        private void buttonChangeRole_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                var editRoleForm = new EditRoleForm();
                editRoleForm.Owner = this;
                editRoleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a cell/row.");
            }
        }

        private void buttonSuspendAccount_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                using (var session = new Session1Entities())
                {
                    // So that there's no LINQ error about
                    // not being able to convert to LINQ expression
                    var currentCellID = int.Parse(dataGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    var result = session.Users.SingleOrDefault(u => u.ID == currentCellID);
                    result.Active = result.Active == true ? false : true;

                    session.SaveChanges();
                    SetDatagridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a cell/row.");
            }
        }

        private void buttonChangeLogin_Click(object sender, EventArgs e)
        {
        }

        private void labelAddUser_MouseEnter(object sender, EventArgs e)
        {
            labelAddUser.BackColor = SystemColors.ControlLight;
        }

        private void labelAddUser_MouseLeave(object sender, EventArgs e)
        {
            labelAddUser.BackColor = default(Color);
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            labelExit.BackColor = SystemColors.ControlLight;
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.BackColor = default(Color);
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (dataGridView.Rows[rowIndex].Cells["Active"].Value.ToString() == "True")
            {
                buttonSuspendAccount.Text = "Suspend Account";
            }
            else
            {
                buttonSuspendAccount.Text = "Unsuspend Accout";
            }
        }
    }
}