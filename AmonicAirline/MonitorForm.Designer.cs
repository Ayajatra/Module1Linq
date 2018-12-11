namespace AmonicAirline
{
    partial class MonitorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLastLogin = new System.Windows.Forms.Label();
            this.radioButtonSoftwareCrash = new System.Windows.Forms.RadioButton();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonSystemCrash = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelLastLogin
            // 
            this.labelLastLogin.AutoSize = true;
            this.labelLastLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelLastLogin.Location = new System.Drawing.Point(12, 9);
            this.labelLastLogin.Name = "labelLastLogin";
            this.labelLastLogin.Size = new System.Drawing.Size(410, 17);
            this.labelLastLogin.TabIndex = 0;
            this.labelLastLogin.Text = "No logout detected for your last login on {lastDate} at {lastTime}";
            // 
            // radioButtonSoftwareCrash
            // 
            this.radioButtonSoftwareCrash.AutoSize = true;
            this.radioButtonSoftwareCrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonSoftwareCrash.Location = new System.Drawing.Point(25, 313);
            this.radioButtonSoftwareCrash.Name = "radioButtonSoftwareCrash";
            this.radioButtonSoftwareCrash.Size = new System.Drawing.Size(122, 21);
            this.radioButtonSoftwareCrash.TabIndex = 1;
            this.radioButtonSoftwareCrash.TabStop = true;
            this.radioButtonSoftwareCrash.Text = "Software Crash";
            this.radioButtonSoftwareCrash.UseVisualStyleBackColor = true;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Enabled = false;
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonConfirm.Location = new System.Drawing.Point(415, 311);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 33);
            this.buttonConfirm.TabIndex = 3;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxReason
            // 
            this.textBoxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxReason.Location = new System.Drawing.Point(12, 78);
            this.textBoxReason.Multiline = true;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(503, 227);
            this.textBoxReason.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reason :";
            // 
            // radioButtonSystemCrash
            // 
            this.radioButtonSystemCrash.AutoSize = true;
            this.radioButtonSystemCrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonSystemCrash.Location = new System.Drawing.Point(157, 313);
            this.radioButtonSystemCrash.Name = "radioButtonSystemCrash";
            this.radioButtonSystemCrash.Size = new System.Drawing.Size(113, 21);
            this.radioButtonSystemCrash.TabIndex = 2;
            this.radioButtonSystemCrash.TabStop = true;
            this.radioButtonSystemCrash.Text = "System Crash";
            this.radioButtonSystemCrash.UseVisualStyleBackColor = true;
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 356);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxReason);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.radioButtonSystemCrash);
            this.Controls.Add(this.radioButtonSoftwareCrash);
            this.Controls.Add(this.labelLastLogin);
            this.Name = "MonitorForm";
            this.Text = "MonitorForm";
            this.Load += new System.EventHandler(this.MonitorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLastLogin;
        private System.Windows.Forms.RadioButton radioButtonSoftwareCrash;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.TextBox textBoxReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonSystemCrash;
    }
}