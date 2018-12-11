using Session1Library;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class MonitorForm : Form
    {
        private Timer timer = new Timer
        {
            Interval = 200,
            Enabled = true
        };

        private int id;

        public MonitorForm(int _ID)
        {
            InitializeComponent();
            id = _ID;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (textBoxReason.Text != "" && (radioButtonSoftwareCrash.Checked || radioButtonSystemCrash.Checked))
            {
                buttonConfirm.Enabled = true;
            }
        }

        private void MonitorForm_Load(object sender, EventArgs e)
        {
            using (var session = new Session1Entities())
            {
                var query = session.Activities.Where(a => a.UserID == id && a.FailReason == "CRASH").FirstOrDefault();

                if (query != null)
                {
                    labelLastLogin.Text = labelLastLogin.Text.Replace("{lastDate}", query.Date.ToString());
                    labelLastLogin.Text = labelLastLogin.Text.Replace("{lastTime}", query.LoginTime.ToString());
                }
                else
                {
                    Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string failText;
            if (radioButtonSoftwareCrash.Checked)
            {
                failText = $"Software Crash : {textBoxReason.Text}";
            }
            else
            {
                failText = $"System Crash : {textBoxReason.Text}";
            }

            using (var session = new Session1Entities())
            {
                var query = session.Activities.Where(a => a.UserID == id && a.FailReason == "CRASH").FirstOrDefault();

                query.FailReason = failText;
                session.SaveChanges();
                Close();
            }
        }
    }
}