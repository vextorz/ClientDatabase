namespace ClientDatabase
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.filterBox = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.lblLoggedInUser = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCheckRenewals = new System.Windows.Forms.Button();
            this.lblDisplayCurrent = new System.Windows.Forms.Label();
            this.lblCurrentReceiverEmail = new System.Windows.Forms.Label();
            this.btnEmailSettings = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.pictureUW = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(187, 131);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClients.Size = new System.Drawing.Size(1042, 498);
            this.dataGridViewClients.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(-1, 120);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(167, 32);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "   Export to Word";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(333, 47);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(189, 22);
            this.searchBox.TabIndex = 5;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // filterBox
            // 
            this.filterBox.FormattingEnabled = true;
            this.filterBox.Items.AddRange(new object[] {
            "Default",
            "Company Name",
            "Address",
            "Client Name",
            "Title",
            "Tier",
            "Email",
            "Phone",
            "Renewal Date",
            "Cost"});
            this.filterBox.Location = new System.Drawing.Point(187, 47);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(121, 21);
            this.filterBox.TabIndex = 6;
            this.filterBox.SelectedIndexChanged += new System.EventHandler(this.filterBox_SelectedIndexChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.Location = new System.Drawing.Point(184, 28);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(60, 16);
            this.filterLabel.TabIndex = 7;
            this.filterLabel.Text = "Sort by:";
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(333, 28);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(81, 16);
            this.searchLabel.TabIndex = 8;
            this.searchLabel.Text = "Search by:";
            // 
            // lblLoggedInUser
            // 
            this.lblLoggedInUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInUser.Location = new System.Drawing.Point(906, 39);
            this.lblLoggedInUser.Name = "lblLoggedInUser";
            this.lblLoggedInUser.Size = new System.Drawing.Size(323, 16);
            this.lblLoggedInUser.TabIndex = 9;
            this.lblLoggedInUser.Text = "Email info";
            this.lblLoggedInUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(1154, 58);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 28);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.pictureUW);
            this.panel1.Controls.Add(this.btnCheckRenewals);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblDisplayCurrent);
            this.panel1.Controls.Add(this.lblCurrentReceiverEmail);
            this.panel1.Controls.Add(this.btnEmailSettings);
            this.panel1.Controls.Add(this.btnSendEmail);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 644);
            this.panel1.TabIndex = 12;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(0, 225);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(166, 32);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "   Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCheckRenewals
            // 
            this.btnCheckRenewals.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCheckRenewals.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnCheckRenewals.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnCheckRenewals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckRenewals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckRenewals.Location = new System.Drawing.Point(0, 155);
            this.btnCheckRenewals.Name = "btnCheckRenewals";
            this.btnCheckRenewals.Size = new System.Drawing.Size(166, 32);
            this.btnCheckRenewals.TabIndex = 15;
            this.btnCheckRenewals.Text = "   Renewal Notification";
            this.btnCheckRenewals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckRenewals.UseVisualStyleBackColor = true;
            this.btnCheckRenewals.Click += new System.EventHandler(this.btnCheckRenewals_Click);
            // 
            // lblDisplayCurrent
            // 
            this.lblDisplayCurrent.AutoSize = true;
            this.lblDisplayCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayCurrent.Location = new System.Drawing.Point(10, 298);
            this.lblDisplayCurrent.Name = "lblDisplayCurrent";
            this.lblDisplayCurrent.Size = new System.Drawing.Size(148, 20);
            this.lblDisplayCurrent.TabIndex = 13;
            this.lblDisplayCurrent.Text = "Current recipient:";
            // 
            // lblCurrentReceiverEmail
            // 
            this.lblCurrentReceiverEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentReceiverEmail.Location = new System.Drawing.Point(3, 318);
            this.lblCurrentReceiverEmail.Name = "lblCurrentReceiverEmail";
            this.lblCurrentReceiverEmail.Size = new System.Drawing.Size(160, 68);
            this.lblCurrentReceiverEmail.TabIndex = 13;
            this.lblCurrentReceiverEmail.Text = "Email of the receiver";
            this.lblCurrentReceiverEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEmailSettings
            // 
            this.btnEmailSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnEmailSettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEmailSettings.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnEmailSettings.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnEmailSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmailSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailSettings.Location = new System.Drawing.Point(0, 190);
            this.btnEmailSettings.Name = "btnEmailSettings";
            this.btnEmailSettings.Size = new System.Drawing.Size(166, 32);
            this.btnEmailSettings.TabIndex = 12;
            this.btnEmailSettings.Text = "   Email Settings";
            this.btnEmailSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailSettings.UseVisualStyleBackColor = false;
            this.btnEmailSettings.Click += new System.EventHandler(this.btnEmailSettings_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSendEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSendEmail.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSendEmail.FlatAppearance.BorderSize = 0;
            this.btnSendEmail.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnSendEmail.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendEmail.Location = new System.Drawing.Point(0, 85);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(166, 30);
            this.btnSendEmail.TabIndex = 11;
            this.btnSendEmail.Text = "   Send Email";
            this.btnSendEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // pictureUW
            // 
            this.pictureUW.BackgroundImage = global::ClientDatabase.Properties.Resources.GT_Logo_circle;
            this.pictureUW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureUW.Location = new System.Drawing.Point(0, 496);
            this.pictureUW.Name = "pictureUW";
            this.pictureUW.Size = new System.Drawing.Size(166, 134);
            this.pictureUW.TabIndex = 13;
            this.pictureUW.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 69);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::ClientDatabase.Properties.Resources.Deleteclient;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(295, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::ClientDatabase.Properties.Resources.Editclient;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(241, 85);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(48, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::ClientDatabase.Properties.Resources.Addclient;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(187, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblLoggedInUser);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewClients);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1264, 680);
            this.MinimumSize = new System.Drawing.Size(1264, 680);
            this.Name = "MainForm";
            this.Text = "Client Database";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ComboBox filterBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label lblLoggedInUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmailSettings;
        private System.Windows.Forms.Label lblCurrentReceiverEmail;
        private System.Windows.Forms.Label lblDisplayCurrent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCheckRenewals;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.PictureBox pictureUW;
    }
}

