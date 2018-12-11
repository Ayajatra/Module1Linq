namespace AmonicAirline
{
    partial class AdminMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelExit = new System.Windows.Forms.Label();
            this.labelAddUser = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxOffice = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonChangeRole = new System.Windows.Forms.Button();
            this.buttonSuspendAccount = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelExit);
            this.panel1.Controls.Add(this.labelAddUser);
            this.panel1.Location = new System.Drawing.Point(-2, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 31);
            this.panel1.TabIndex = 0;
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelExit.Location = new System.Drawing.Point(91, 6);
            this.labelExit.Name = "labelExit";
            this.labelExit.Padding = new System.Windows.Forms.Padding(1);
            this.labelExit.Size = new System.Drawing.Size(32, 19);
            this.labelExit.TabIndex = 1;
            this.labelExit.Text = "&Exit";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            this.labelExit.MouseEnter += new System.EventHandler(this.labelExit_MouseEnter);
            this.labelExit.MouseLeave += new System.EventHandler(this.labelExit_MouseLeave);
            // 
            // labelAddUser
            // 
            this.labelAddUser.AutoSize = true;
            this.labelAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelAddUser.Location = new System.Drawing.Point(6, 6);
            this.labelAddUser.Name = "labelAddUser";
            this.labelAddUser.Padding = new System.Windows.Forms.Padding(1);
            this.labelAddUser.Size = new System.Drawing.Size(69, 19);
            this.labelAddUser.TabIndex = 0;
            this.labelAddUser.Text = "&Add User";
            this.labelAddUser.Click += new System.EventHandler(this.labelAddUser_Click);
            this.labelAddUser.MouseEnter += new System.EventHandler(this.labelAddUser_MouseEnter);
            this.labelAddUser.MouseLeave += new System.EventHandler(this.labelAddUser_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Office : ";
            // 
            // comboBoxOffice
            // 
            this.comboBoxOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOffice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxOffice.FormattingEnabled = true;
            this.comboBoxOffice.Location = new System.Drawing.Point(69, 42);
            this.comboBoxOffice.Name = "comboBoxOffice";
            this.comboBoxOffice.Size = new System.Drawing.Size(191, 24);
            this.comboBoxOffice.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Location = new System.Drawing.Point(9, 87);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4);
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(731, 324);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            // 
            // buttonChangeRole
            // 
            this.buttonChangeRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonChangeRole.Location = new System.Drawing.Point(9, 423);
            this.buttonChangeRole.Name = "buttonChangeRole";
            this.buttonChangeRole.Size = new System.Drawing.Size(109, 43);
            this.buttonChangeRole.TabIndex = 2;
            this.buttonChangeRole.Text = "Change Role";
            this.buttonChangeRole.UseVisualStyleBackColor = true;
            this.buttonChangeRole.Click += new System.EventHandler(this.buttonChangeRole_Click);
            // 
            // buttonSuspendAccount
            // 
            this.buttonSuspendAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSuspendAccount.Location = new System.Drawing.Point(134, 423);
            this.buttonSuspendAccount.Name = "buttonSuspendAccount";
            this.buttonSuspendAccount.Size = new System.Drawing.Size(227, 43);
            this.buttonSuspendAccount.TabIndex = 3;
            this.buttonSuspendAccount.Text = "Suspend / Unsuspend Account";
            this.buttonSuspendAccount.UseVisualStyleBackColor = true;
            this.buttonSuspendAccount.Click += new System.EventHandler(this.buttonSuspendAccount_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 478);
            this.Controls.Add(this.buttonSuspendAccount);
            this.Controls.Add(this.buttonChangeRole);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.comboBoxOffice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainMenu";
            this.Load += new System.EventHandler(this.AdminMainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label labelAddUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxOffice;
        private System.Windows.Forms.Button buttonChangeRole;
        private System.Windows.Forms.Button buttonSuspendAccount;
        public System.Windows.Forms.DataGridView dataGridView;
    }
}