using Session1Library;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class UserMainForm : Form
    {
        private string name;
        private int userID;
        private int ID;
        private Session1Entities session = new Session1Entities();
        private Activity thisUser;

        private Timer timer = new Timer
        {
            Interval = 1000,
            Enabled = true
        };

        public UserMainForm(string _name, int _userID)
        {
            name = _name;
            userID = _userID;
            InitializeComponent();
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            Hide();
            var monitorForm = new MonitorForm(userID);
            monitorForm.ShowDialog();
            Show();

            thisUser = session.Activities.Where(a => a.ID == ID).FirstOrDefault();

            var query = session.Activities.ToList()
                .Where(a => a.UserID == userID).Select(a => new
                {
                    a.ID,
                    a.Date,
                    a.LoginTime,
                    a.LogoutTime,
                    TimeSpent = $"{(a.LogoutTime.GetValueOrDefault() - a.LoginTime).Hours}:{(a.LogoutTime.GetValueOrDefault() - a.LoginTime).Minutes}:{(a.LogoutTime.GetValueOrDefault() - a.LoginTime).Seconds}",
                    a.FailReason
                });

            var result = query.ToList();
            if (result.Any())
            {
                ID = result.Last().ID;
                result.RemoveAt(result.Count - 1);
            }
            dataGridView.DataSource = result;
            dataGridView.Columns["ID"].Visible = false;

            GetSetTimeSpent();
            timer.Start();
            timer.Tick += Timer_Tick;

            var crashesCount = result.Where(a => a.FailReason != null).Count();

            labelWelcomeMessage.Text = $"Hi {name}, welcome to AMONIC Airlines.";
            labelNumberOfCrashes.Text = $"Number of crashes : {crashesCount}";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeSpents = timeSpents.Add(new TimeSpan(0, 0, 1));
            labelTimeSpent.Text = $"Time Spent on the system : {timeSpents}";
        }

        private TimeSpan timeSpents = new TimeSpan(0, 0, 0);

        private void GetSetTimeSpent()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    timeSpents += TimeSpan.Parse(row.Cells["TimeSpent"].Value.ToString());
                }

                labelTimeSpent.Text = $"Time spent on the system : {timeSpents}";
            }
            catch { };
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            labelExit.BackColor = SystemColors.ControlLight;
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.BackColor = default(Color);
        }

        private bool reportedCrash = false;

        private void labelExit_Click(object sender, EventArgs e)
        {
            session.Activities.Where(a => a.ID == ID).FirstOrDefault().FailReason = null;
            reportedCrash = true;
            session.SaveChanges();
            Close();
        }

        private void UserMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var timeNow = DateTime.Now.TimeOfDay;
            if (!reportedCrash)
            {
                session.Activities.Where(a => a.ID == ID).FirstOrDefault().FailReason = "CRASH";
            }
            session.Activities.Where(a => a.ID == ID).FirstOrDefault().LogoutTime = new TimeSpan(timeNow.Hours, timeNow.Minutes, timeNow.Seconds);
            session.SaveChanges();
        }
    }
}