namespace RxExamples
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.spcLog = new System.Windows.Forms.SplitContainer();
            this.txtRaw = new System.Windows.Forms.TextBox();
            this.txtNotification = new System.Windows.Forms.TextBox();
            this.tlpPattern = new System.Windows.Forms.TableLayoutPanel();
            this.lblPattern = new System.Windows.Forms.Label();
            this.cboPattern = new System.Windows.Forms.ComboBox();
            this.chkDelayTimesTen = new System.Windows.Forms.CheckBox();
            this.lblPatternPlaceHolder = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLog)).BeginInit();
            this.spcLog.Panel1.SuspendLayout();
            this.spcLog.Panel2.SuspendLayout();
            this.spcLog.SuspendLayout();
            this.tlpPattern.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.spcLog, 0, 2);
            this.tlpMain.Controls.Add(this.tlpPattern, 0, 0);
            this.tlpMain.Controls.Add(this.lblPatternPlaceHolder, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tlpMain.Size = new System.Drawing.Size(621, 443);
            this.tlpMain.TabIndex = 0;
            // 
            // spcLog
            // 
            this.spcLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLog.Location = new System.Drawing.Point(3, 123);
            this.spcLog.Name = "spcLog";
            // 
            // spcLog.Panel1
            // 
            this.spcLog.Panel1.Controls.Add(this.txtRaw);
            // 
            // spcLog.Panel2
            // 
            this.spcLog.Panel2.Controls.Add(this.txtNotification);
            this.spcLog.Size = new System.Drawing.Size(615, 317);
            this.spcLog.SplitterDistance = 307;
            this.spcLog.TabIndex = 0;
            // 
            // txtRaw
            // 
            this.txtRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaw.Location = new System.Drawing.Point(0, 0);
            this.txtRaw.Multiline = true;
            this.txtRaw.Name = "txtRaw";
            this.txtRaw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRaw.Size = new System.Drawing.Size(307, 317);
            this.txtRaw.TabIndex = 0;
            // 
            // txtNotification
            // 
            this.txtNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotification.Location = new System.Drawing.Point(0, 0);
            this.txtNotification.Multiline = true;
            this.txtNotification.Name = "txtNotification";
            this.txtNotification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotification.Size = new System.Drawing.Size(304, 317);
            this.txtNotification.TabIndex = 0;
            // 
            // tlpPattern
            // 
            this.tlpPattern.AutoSize = true;
            this.tlpPattern.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpPattern.ColumnCount = 3;
            this.tlpPattern.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPattern.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPattern.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPattern.Controls.Add(this.lblPattern, 0, 0);
            this.tlpPattern.Controls.Add(this.cboPattern, 1, 0);
            this.tlpPattern.Controls.Add(this.chkDelayTimesTen, 2, 0);
            this.tlpPattern.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpPattern.Location = new System.Drawing.Point(0, 0);
            this.tlpPattern.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPattern.Name = "tlpPattern";
            this.tlpPattern.RowCount = 1;
            this.tlpPattern.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPattern.Size = new System.Drawing.Size(621, 27);
            this.tlpPattern.TabIndex = 1;
            // 
            // lblPattern
            // 
            this.lblPattern.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(3, 7);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(100, 13);
            this.lblPattern.TabIndex = 0;
            this.lblPattern.Text = "Notification Pattern:";
            // 
            // cboPattern
            // 
            this.cboPattern.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPattern.FormattingEnabled = true;
            this.cboPattern.Location = new System.Drawing.Point(109, 3);
            this.cboPattern.Name = "cboPattern";
            this.cboPattern.Size = new System.Drawing.Size(423, 21);
            this.cboPattern.TabIndex = 1;
            this.cboPattern.SelectedIndexChanged += new System.EventHandler(this.cboPattern_SelectedIndexChanged);
            // 
            // chkDelayTimesTen
            // 
            this.chkDelayTimesTen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkDelayTimesTen.AutoSize = true;
            this.chkDelayTimesTen.Location = new System.Drawing.Point(545, 5);
            this.chkDelayTimesTen.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.chkDelayTimesTen.Name = "chkDelayTimesTen";
            this.chkDelayTimesTen.Size = new System.Drawing.Size(73, 17);
            this.chkDelayTimesTen.TabIndex = 2;
            this.chkDelayTimesTen.Text = "Delay x10";
            this.chkDelayTimesTen.UseVisualStyleBackColor = true;
            this.chkDelayTimesTen.CheckedChanged += new System.EventHandler(this.chkDelayTimesTen_CheckedChanged);
            // 
            // lblPatternPlaceHolder
            // 
            this.lblPatternPlaceHolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPatternPlaceHolder.AutoSize = true;
            this.lblPatternPlaceHolder.Location = new System.Drawing.Point(209, 67);
            this.lblPatternPlaceHolder.Margin = new System.Windows.Forms.Padding(3, 40, 3, 40);
            this.lblPatternPlaceHolder.Name = "lblPatternPlaceHolder";
            this.lblPatternPlaceHolder.Size = new System.Drawing.Size(203, 13);
            this.lblPatternPlaceHolder.TabIndex = 2;
            this.lblPatternPlaceHolder.Text = "<Pattern Control design time placeholder>";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 443);
            this.Controls.Add(this.tlpMain);
            this.Name = "MainForm";
            this.Text = "Notification Patterns in Rx";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.spcLog.Panel1.ResumeLayout(false);
            this.spcLog.Panel1.PerformLayout();
            this.spcLog.Panel2.ResumeLayout(false);
            this.spcLog.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLog)).EndInit();
            this.spcLog.ResumeLayout(false);
            this.tlpPattern.ResumeLayout(false);
            this.tlpPattern.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.SplitContainer spcLog;
        private System.Windows.Forms.TableLayoutPanel tlpPattern;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.ComboBox cboPattern;
        private System.Windows.Forms.TextBox txtRaw;
        private System.Windows.Forms.TextBox txtNotification;
        private System.Windows.Forms.Label lblPatternPlaceHolder;
        private System.Windows.Forms.CheckBox chkDelayTimesTen;
    }
}

