﻿using FormUtilitiesLibrary;
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
            // Check if connected to server(database) or not

            if (!Connection.IsConnected())
            {
                MessageBox.Show("Failed to connect to server!");
                Application.Exit();
            }
            timer.Tick += Timer_Tick;
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
                var query = session.Users.Where(u => u.Email == username && u.Password == password);

                var result = query.FirstOrDefault();
                if (result != null)
                {
                    if (result.Active == true)
                    {
                        // Login Success
                        // Administrator = 1, User = 2
                        if (result.RoleID == 1)
                        {
                            var admin = new AdminMainForm();
                            // So that if AdminMainForm closed, LoginForm will open again

                            Hide();
                            admin.ShowDialog();
                            Show();
                        }
                        else
                        {
                            var user = new UserMainForm($"{result.FirstName} {result.LastName}", result.ID);
                            // So that if UserMainForm closed, LoginForm will open again

                            Hide();
                            var timeNow = DateTime.Now.TimeOfDay;
                            session.Activities.Add(new Activity { UserID = result.ID, Date = DateTime.Now.Date, LoginTime = new TimeSpan(timeNow.Hours, timeNow.Minutes, timeNow.Seconds) });
                            session.SaveChanges();
                            user.ShowDialog();
                            Show();
                        }

                        ClearFields.ClearTextBoxes(this);
                        failedLoginAttempt = 0;
                    }
                    else
                    {
                        MessageBox.Show("User suspended by Administrator!");
                        failedLoginAttempt++;
                        CheckLoginAttempt();
                    }
                }
                else
                {
                    // Login Failed

                    MessageBox.Show("Wrong Username or Password!");
                    failedLoginAttempt++;
                    CheckLoginAttempt();
                }
            }
        }

        // Check how many times failed to login

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