namespace ClientDatabase
{
    partial class RenewalNotificationsForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridViewClientsToRenew = new System.Windows.Forms.DataGridView();
            this.dataGridViewRenewalLogs = new System.Windows.Forms.DataGridView();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnClearOldLogs = new System.Windows.Forms.Button();
            this.btnCheckRenewalDate = new System.Windows.Forms.Button();
            this.labelUpComing = new System.Windows.Forms.Label();
            this.labelEmailLogs = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientsToRenew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRenewalLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataGridViewClientsToRenew
            // 
            this.dataGridViewClientsToRenew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientsToRenew.Location = new System.Drawing.Point(37, 51);
            this.dataGridViewClientsToRenew.Name = "dataGridViewClientsToRenew";
            this.dataGridViewClientsToRenew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClientsToRenew.Size = new System.Drawing.Size(530, 139);
            this.dataGridViewClientsToRenew.TabIndex = 1;
            // 
            // dataGridViewRenewalLogs
            // 
            this.dataGridViewRenewalLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRenewalLogs.Location = new System.Drawing.Point(37, 256);
            this.dataGridViewRenewalLogs.Name = "dataGridViewRenewalLogs";
            this.dataGridViewRenewalLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRenewalLogs.Size = new System.Drawing.Size(530, 166);
            this.dataGridViewRenewalLogs.TabIndex = 2;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(37, 196);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(118, 23);
            this.btnSendEmail.TabIndex = 3;
            this.btnSendEmail.Text = "Send selected email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(35, 428);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(127, 23);
            this.btnClearLogs.TabIndex = 4;
            this.btnClearLogs.Text = "Clear selected email";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnClearOldLogs
            // 
            this.btnClearOldLogs.Location = new System.Drawing.Point(168, 428);
            this.btnClearOldLogs.Name = "btnClearOldLogs";
            this.btnClearOldLogs.Size = new System.Drawing.Size(97, 23);
            this.btnClearOldLogs.TabIndex = 5;
            this.btnClearOldLogs.Text = "Clear old emails";
            this.btnClearOldLogs.UseVisualStyleBackColor = true;
            this.btnClearOldLogs.Click += new System.EventHandler(this.btnClearOldLogs_Click);
            // 
            // btnCheckRenewalDate
            // 
            this.btnCheckRenewalDate.Location = new System.Drawing.Point(161, 196);
            this.btnCheckRenewalDate.Name = "btnCheckRenewalDate";
            this.btnCheckRenewalDate.Size = new System.Drawing.Size(132, 23);
            this.btnCheckRenewalDate.TabIndex = 6;
            this.btnCheckRenewalDate.Text = "Check for renewal date";
            this.btnCheckRenewalDate.UseVisualStyleBackColor = true;
            this.btnCheckRenewalDate.Click += new System.EventHandler(this.btnCheckRenewalDate_Click);
            // 
            // labelUpComing
            // 
            this.labelUpComing.AutoSize = true;
            this.labelUpComing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpComing.Location = new System.Drawing.Point(36, 28);
            this.labelUpComing.Name = "labelUpComing";
            this.labelUpComing.Size = new System.Drawing.Size(126, 20);
            this.labelUpComing.TabIndex = 7;
            this.labelUpComing.Text = "Renewal Alert:";
            // 
            // labelEmailLogs
            // 
            this.labelEmailLogs.AutoSize = true;
            this.labelEmailLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailLogs.Location = new System.Drawing.Point(36, 233);
            this.labelEmailLogs.Name = "labelEmailLogs";
            this.labelEmailLogs.Size = new System.Drawing.Size(102, 20);
            this.labelEmailLogs.TabIndex = 8;
            this.labelEmailLogs.Text = "Email Logs:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(492, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RenewalNotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 496);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelEmailLogs);
            this.Controls.Add(this.labelUpComing);
            this.Controls.Add(this.btnCheckRenewalDate);
            this.Controls.Add(this.btnClearOldLogs);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.dataGridViewRenewalLogs);
            this.Controls.Add(this.dataGridViewClientsToRenew);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(605, 535);
            this.MinimumSize = new System.Drawing.Size(605, 535);
            this.Name = "RenewalNotificationsForm";
            this.Text = "Renewal Notifications";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientsToRenew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRenewalLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridViewClientsToRenew;
        private System.Windows.Forms.DataGridView dataGridViewRenewalLogs;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnClearOldLogs;
        private System.Windows.Forms.Button btnCheckRenewalDate;
        private System.Windows.Forms.Label labelUpComing;
        private System.Windows.Forms.Label labelEmailLogs;
        private System.Windows.Forms.Button btnClose;
    }
}