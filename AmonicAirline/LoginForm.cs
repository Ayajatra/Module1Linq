using FormUtilitiesLibrary;
using HashLibrary;
using Session1Library;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Check apakah terhubung ke server (database) atau tidak

            if (!Connection.IsConnected())
            {
                MessageBox.Show("Gagal terhubung ke server!");
                Application.Exit();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            password = Hash.MakeMd5(password);
            using (var session = new Session1Entities())
            {
                var query = from u in session.Users
                            where u.Email == username && u.Password == password
                            select u;

                var result = query.ToList();
                if (result.Count == 1)
                {
                    // Sukses Login
                    // Supaya kalau AdminMainForm ditutup, LoginForm bakal automatis muncul lagi

                    ClearFields.ClearTextBoxes(this);
                    var admin = new AdminMainForm();
                    Hide();
                    admin.ShowDialog();
                    Show();

                    failedLoginAttempt = 0;
                }
                else
                {
                    // Gagal Login

                    MessageBox.Show("Salah Username atau Password!");
                    failedLoginAttempt++;
                    CheckLoginAttempt();
                }
            }
        }

        // Check berapa banyak kali gagal login

        private Timer timer = new Timer()
        {
            Interval = 1000,
            Enabled = true
        };

        private int cooldownTime = 10;
        private int failedLoginAttempt = 0;

        private void CheckLoginAttempt()
        {
            if (failedLoginAttempt > 3)
            {
                buttonLogin.Enabled = false;
                labelCooldown.Text = $"Cooldown : {cooldownTime}s";
                labelCooldown.Visible = true;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            cooldownTime--;
            labelCooldown.Text = $"Cooldown : {cooldownTime}s";
            if (cooldownTime < 1)
            {
                buttonLogin.Enabled = true;
                labelCooldown.Visible = false;
                cooldownTime = 10;
                failedLoginAttempt = 0;
                timer.Stop();
            }
        }
    }
}