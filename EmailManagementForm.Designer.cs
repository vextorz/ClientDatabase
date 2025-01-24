namespace ClientDatabase
{
    partial class EmailManagementForm
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
            this.listBoxEmails = new System.Windows.Forms.ListBox();
            this.btnSetAsDefault = new System.Windows.Forms.Button();
            this.lblCurrentReceiverEmail = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNewEmail = new System.Windows.Forms.TextBox();
            this.lblAddNew = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblDisplayCurrent = new System.Windows.Forms.Label();
            this.chkAutoSendEmail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBoxEmails
            // 
            this.listBoxEmails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEmails.FormattingEnabled = true;
            this.listBoxEmails.ItemHeight = 16;
            this.listBoxEmails.Location = new System.Drawing.Point(12, 93);
            this.listBoxEmails.Name = "listBoxEmails";
            this.listBoxEmails.Size = new System.Drawing.Size(253, 228);
            this.listBoxEmails.TabIndex = 0;
            // 
            // btnSetAsDefault
            // 
            this.btnSetAsDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetAsDefault.Location = new System.Drawing.Point(271, 93);
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.Size = new System.Drawing.Size(94, 23);
            this.btnSetAsDefault.TabIndex = 1;
            this.btnSetAsDefault.Text = "Set Default";
            this.btnSetAsDefault.UseVisualStyleBackColor = true;
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // lblCurrentReceiverEmail
            // 
            this.lblCurrentReceiverEmail.AutoSize = true;
            this.lblCurrentReceiverEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentReceiverEmail.Location = new System.Drawing.Point(8, 40);
            this.lblCurrentReceiverEmail.Name = "lblCurrentReceiverEmail";
            this.lblCurrentReceiverEmail.Size = new System.Drawing.Size(71, 20);
            this.lblCurrentReceiverEmail.TabIndex = 2;
            this.lblCurrentReceiverEmail.Text = "Receiver";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(199, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(285, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNewEmail
            // 
            this.txtNewEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewEmail.Location = new System.Drawing.Point(12, 358);
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.Size = new System.Drawing.Size(253, 22);
            this.txtNewEmail.TabIndex = 5;
            // 
            // lblAddNew
            // 
            this.lblAddNew.AutoSize = true;
            this.lblAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNew.Location = new System.Drawing.Point(12, 335);
            this.lblAddNew.Name = "lblAddNew";
            this.lblAddNew.Size = new System.Drawing.Size(140, 16);
            this.lblAddNew.TabIndex = 6;
            this.lblAddNew.Text = "New email address";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(271, 357);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(271, 152);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(271, 123);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 23);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblDisplayCurrent
            // 
            this.lblDisplayCurrent.AutoSize = true;
            this.lblDisplayCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayCurrent.Location = new System.Drawing.Point(8, 20);
            this.lblDisplayCurrent.Name = "lblDisplayCurrent";
            this.lblDisplayCurrent.Size = new System.Drawing.Size(148, 20);
            this.lblDisplayCurrent.TabIndex = 10;
            this.lblDisplayCurrent.Text = "Current recipient:";
            // 
            // chkAutoSendEmail
            // 
            this.chkAutoSendEmail.AutoSize = true;
            this.chkAutoSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoSendEmail.Location = new System.Drawing.Point(12, 63);
            this.chkAutoSendEmail.Name = "chkAutoSendEmail";
            this.chkAutoSendEmail.Size = new System.Drawing.Size(210, 20);
            this.chkAutoSendEmail.TabIndex = 11;
            this.chkAutoSendEmail.Text = "Automatically Send Emails";
            this.chkAutoSendEmail.UseVisualStyleBackColor = true;
            // 
            // EmailManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 451);
            this.Controls.Add(this.chkAutoSendEmail);
            this.Controls.Add(this.lblDisplayCurrent);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAddNew);
            this.Controls.Add(this.txtNewEmail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCurrentReceiverEmail);
            this.Controls.Add(this.btnSetAsDefault);
            this.Controls.Add(this.listBoxEmails);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 490);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 490);
            this.Name = "EmailManagementForm";
            this.Text = "Email config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEmails;
        private System.Windows.Forms.Button btnSetAsDefault;
        private System.Windows.Forms.Label lblCurrentReceiverEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Label lblAddNew;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblDisplayCurrent;
        private System.Windows.Forms.CheckBox chkAutoSendEmail;
    }
}