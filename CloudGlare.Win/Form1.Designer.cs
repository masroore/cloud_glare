namespace CloudGlare.Win
{
    partial class Form1
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnCookies = new System.Windows.Forms.Button();
            this.lvwCookies = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwHeaders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.btnEvalUserAgent = new System.Windows.Forms.Button();
            this.lblProxy = new System.Windows.Forms.Label();
            this.btnLoadUrl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProxies = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveSessions = new System.Windows.Forms.Button();
            this.btnSwitchNextProxy = new System.Windows.Forms.Button();
            this.btnLoadProxies = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnSaveSessions);
            this.splitContainer.Panel2.Controls.Add(this.btnCookies);
            this.splitContainer.Panel2.Controls.Add(this.lvwCookies);
            this.splitContainer.Panel2.Controls.Add(this.lvwHeaders);
            this.splitContainer.Panel2.Controls.Add(this.label5);
            this.splitContainer.Panel2.Controls.Add(this.label4);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.txtUserAgent);
            this.splitContainer.Panel2.Controls.Add(this.btnEvalUserAgent);
            this.splitContainer.Panel2.Controls.Add(this.lblProxy);
            this.splitContainer.Panel2.Controls.Add(this.btnSwitchNextProxy);
            this.splitContainer.Panel2.Controls.Add(this.btnLoadUrl);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.txtProxies);
            this.splitContainer.Panel2.Controls.Add(this.btnLoadProxies);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.txtUrl);
            this.splitContainer.Size = new System.Drawing.Size(1153, 685);
            this.splitContainer.SplitterDistance = 740;
            this.splitContainer.TabIndex = 0;
            // 
            // btnCookies
            // 
            this.btnCookies.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCookies.Location = new System.Drawing.Point(355, 456);
            this.btnCookies.Margin = new System.Windows.Forms.Padding(0);
            this.btnCookies.Name = "btnCookies";
            this.btnCookies.Size = new System.Drawing.Size(41, 18);
            this.btnCookies.TabIndex = 17;
            this.btnCookies.Text = "Cookie";
            this.btnCookies.UseVisualStyleBackColor = true;
            this.btnCookies.Click += new System.EventHandler(this.btnCookies_Click);
            // 
            // lvwCookies
            // 
            this.lvwCookies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvwCookies.HideSelection = false;
            this.lvwCookies.Location = new System.Drawing.Point(14, 474);
            this.lvwCookies.Name = "lvwCookies";
            this.lvwCookies.Size = new System.Drawing.Size(382, 177);
            this.lvwCookies.TabIndex = 16;
            this.lvwCookies.UseCompatibleStateImageBehavior = false;
            this.lvwCookies.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Value";
            // 
            // lvwHeaders
            // 
            this.lvwHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwHeaders.HideSelection = false;
            this.lvwHeaders.Location = new System.Drawing.Point(15, 275);
            this.lvwHeaders.Name = "lvwHeaders";
            this.lvwHeaders.Size = new System.Drawing.Size(382, 180);
            this.lvwHeaders.TabIndex = 15;
            this.lvwHeaders.UseCompatibleStateImageBehavior = false;
            this.lvwHeaders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(14, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Request Cookies:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(11, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Request Headers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(11, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "User Agent:";
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Location = new System.Drawing.Point(14, 216);
            this.txtUserAgent.Multiline = true;
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUserAgent.Size = new System.Drawing.Size(383, 40);
            this.txtUserAgent.TabIndex = 11;
            // 
            // btnEvalUserAgent
            // 
            this.btnEvalUserAgent.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvalUserAgent.Location = new System.Drawing.Point(362, 196);
            this.btnEvalUserAgent.Margin = new System.Windows.Forms.Padding(0);
            this.btnEvalUserAgent.Name = "btnEvalUserAgent";
            this.btnEvalUserAgent.Size = new System.Drawing.Size(34, 18);
            this.btnEvalUserAgent.TabIndex = 10;
            this.btnEvalUserAgent.Text = "UA";
            this.btnEvalUserAgent.UseVisualStyleBackColor = true;
            this.btnEvalUserAgent.Click += new System.EventHandler(this.btnEvalUserAgent_Click);
            // 
            // lblProxy
            // 
            this.lblProxy.AutoSize = true;
            this.lblProxy.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxy.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblProxy.Location = new System.Drawing.Point(85, 175);
            this.lblProxy.Name = "lblProxy";
            this.lblProxy.Size = new System.Drawing.Size(26, 13);
            this.lblProxy.TabIndex = 9;
            this.lblProxy.Text = "N/A";
            // 
            // btnLoadUrl
            // 
            this.btnLoadUrl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadUrl.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadUrl.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnLoadUrl.Location = new System.Drawing.Point(343, 8);
            this.btnLoadUrl.Name = "btnLoadUrl";
            this.btnLoadUrl.Size = new System.Drawing.Size(53, 23);
            this.btnLoadUrl.TabIndex = 5;
            this.btnLoadUrl.Text = "GO!";
            this.btnLoadUrl.UseVisualStyleBackColor = false;
            this.btnLoadUrl.Click += new System.EventHandler(this.btnLoadUrl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "HTTP Proxy Servers:";
            // 
            // txtProxies
            // 
            this.txtProxies.Location = new System.Drawing.Point(14, 51);
            this.txtProxies.Multiline = true;
            this.txtProxies.Name = "txtProxies";
            this.txtProxies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProxies.Size = new System.Drawing.Size(383, 113);
            this.txtProxies.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(49, 9);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(288, 22);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "https://ipinfo.io/json";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Proxy list|*.txt|All files|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "JSON File|*.json|All files|*.*";
            // 
            // btnSaveSessions
            // 
            this.btnSaveSessions.Image = global::CloudGlare.Win.Properties.Resources.save;
            this.btnSaveSessions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveSessions.Location = new System.Drawing.Point(14, 657);
            this.btnSaveSessions.Name = "btnSaveSessions";
            this.btnSaveSessions.Size = new System.Drawing.Size(65, 23);
            this.btnSaveSessions.TabIndex = 18;
            this.btnSaveSessions.Text = "Save";
            this.btnSaveSessions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveSessions.UseVisualStyleBackColor = true;
            this.btnSaveSessions.Click += new System.EventHandler(this.btnSaveSessions_Click);
            // 
            // btnSwitchNextProxy
            // 
            this.btnSwitchNextProxy.Image = global::CloudGlare.Win.Properties.Resources.right_arrow;
            this.btnSwitchNextProxy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSwitchNextProxy.Location = new System.Drawing.Point(343, 170);
            this.btnSwitchNextProxy.Name = "btnSwitchNextProxy";
            this.btnSwitchNextProxy.Size = new System.Drawing.Size(54, 23);
            this.btnSwitchNextProxy.TabIndex = 6;
            this.btnSwitchNextProxy.Text = "Next";
            this.btnSwitchNextProxy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSwitchNextProxy.UseVisualStyleBackColor = true;
            this.btnSwitchNextProxy.Click += new System.EventHandler(this.btnSwitchNextProxy_Click);
            // 
            // btnLoadProxies
            // 
            this.btnLoadProxies.Image = global::CloudGlare.Win.Properties.Resources.storage;
            this.btnLoadProxies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadProxies.Location = new System.Drawing.Point(14, 170);
            this.btnLoadProxies.Name = "btnLoadProxies";
            this.btnLoadProxies.Size = new System.Drawing.Size(65, 23);
            this.btnLoadProxies.TabIndex = 2;
            this.btnLoadProxies.Text = "Load";
            this.btnLoadProxies.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadProxies.UseVisualStyleBackColor = true;
            this.btnLoadProxies.Click += new System.EventHandler(this.btnLoadProxies_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 685);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CloudGlare - Win";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnLoadProxies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProxies;
        private System.Windows.Forms.Button btnLoadUrl;
        private System.Windows.Forms.Button btnSwitchNextProxy;
        private System.Windows.Forms.Label lblProxy;
        private System.Windows.Forms.Button btnEvalUserAgent;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvwCookies;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnCookies;
        private System.Windows.Forms.Button btnSaveSessions;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

