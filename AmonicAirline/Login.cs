using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Session1Library;

namespace AmonicAirline
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QueryData();
        }

        private void QueryData()
        {
            using (var db = new Session1Entities())
            {
                var query = from u in db.Users
                            join o in db.Offices on u.OfficeID equals o.ID
                            select new
                            {
                                u.ID,
                                u.RoleID,
                                u.Email,
                                u.Password,
                                u.FirstName,
                                u.LastName,
                                Office = o.Title,
                                u.Birthdate,
                                u.Active
                            };

            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            QueryData();
        }
    }
}
