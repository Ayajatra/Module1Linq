using Session1Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class AdminMainForm : Form
    {
        // Awalnya ingin mencoba men-bind ke databasenya dengan menghabiskan 1 jam-an di internet untuk mencari caranya
        // Akhirnya 1 jam-an itu sia-sia karena entah kenapa bindingSource.Reset(true) tidak bekerja (Line 154)
        private BindingSource bindingSource = new BindingSource();

        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            // TODO: Move it to a method in a class (See: Line 23(AddUserForm), Line 24(AdminMainForm))
            // Get all Office ID and Title, then set it to comboBoxOffice.

            using (var session = new Session1Entities())
            {
                var query = from o in session.Offices
                            select new { o.ID, o.Title };

                var result = query.ToDictionary(o => o.ID, o => o.Title);
                // Add All offices option and then sort it based on ID

                result.Add(0, "All offices");
                result = result.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);

                comboBoxOffice.DataSource = new BindingSource(result, null);
                comboBoxOffice.DisplayMember = "Value";
                comboBoxOffice.ValueMember = "Key";

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
                    var query = from u in session.Users
                                join r in session.Roles on u.RoleID equals r.ID
                                join o in session.Offices on u.OfficeID equals o.ID
                                where u.OfficeID == value
                                select new
                                {
                                    u.ID,
                                    Name = u.FirstName,
                                    u.LastName,
                                    Age = DateTime.Now.Year - u.Birthdate.Value.Year,
                                    UserRole = r.Title,
                                    EmailAddress = u.Email,
                                    Office = o.Title,
                                    u.Active
                                };

                    bindingSource.DataSource = query.ToList();
                    dataGridView.DataSource = bindingSource;
                }
                else
                {
                    var query = from u in session.Users
                                join r in session.Roles on u.RoleID equals r.ID
                                join o in session.Offices on u.OfficeID equals o.ID
                                select new
                                {
                                    u.ID,
                                    Name = u.FirstName,
                                    u.LastName,
                                    Age = DateTime.Now.Year - u.Birthdate.Value.Year,
                                    UserRole = r.Title,
                                    EmailAddress = u.Email,
                                    Office = o.Title,
                                    u.Active
                                };

                    bindingSource.DataSource = query.ToList();
                    dataGridView.DataSource = bindingSource;
                }

                dataGridView.Columns["ID"].Visible = false;
                dataGridView.Columns["Active"].Visible = false;
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
        }

        private void buttonSuspendAccount_Click(object sender, EventArgs e)
        {
            // Get all of selected rows primary key

            var selectedRowsKey = new List<int>();

            // for selected cells

            int selectedCellCount = dataGridView.GetCellCount(DataGridViewElementStates.Selected);
            for (int i = 0; i < selectedCellCount; i++)
            {
                selectedRowsKey.Add(int.Parse(dataGridView.SelectedCells[i].OwningRow.Cells["ID"].Value.ToString()));
            }

            // for selected rows

            int selectedRowsCount = dataGridView.SelectedRows.Count;
            for (int i = 0; i < selectedRowsCount; i++)
            {
                selectedRowsKey.Add(int.Parse(dataGridView.SelectedRows[i].Cells["ID"].Value.ToString()));
            }

            if (selectedRowsKey.Count != 0)
            {
                // Change the value

                using (var session = new Session1Entities())
                {
                    foreach (var key in selectedRowsKey)
                    {
                        var result = session.Users.SingleOrDefault(u => u.ID == key);
                        result.Active = result.Active == true ? false : true;
                    }

                    session.SaveChanges();
                    // bindingSource.ResetBindings(true); Kenapa ini tidak bekerja?
                    SetDatagridView();
                }
            }
            else
            {
                MessageBox.Show("Please select the row that you want to suspend/unsuspend first!");
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

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Check if the User is active or not
            // if not active : Give red color

            int rowIndex = e.RowIndex;
            int rowCount = dataGridView.Rows.Count;
            while (rowIndex < rowCount)
            {
                if (dataGridView.Rows[rowIndex].Cells["Active"].Value.ToString() == "False")
                {
                    dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.DarkRed;
                    dataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = default(Color);
                    dataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor = default(Color);
                }
                rowIndex++;
            }
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