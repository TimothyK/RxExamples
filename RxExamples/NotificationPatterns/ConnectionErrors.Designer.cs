namespace RxExamples.NotificationPatterns
{
    partial class ConnectionErrors
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnSuccessfulConnection = new System.Windows.Forms.Button();
            this.btnRaiseConnectionError = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.btnSuccessfulConnection, 0, 1);
            this.tlpMain.Controls.Add(this.btnRaiseConnectionError, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(150, 58);
            this.tlpMain.TabIndex = 4;
            // 
            // btnSuccessfulConnection
            // 
            this.btnSuccessfulConnection.AutoSize = true;
            this.btnSuccessfulConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSuccessfulConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuccessfulConnection.Location = new System.Drawing.Point(3, 32);
            this.btnSuccessfulConnection.Name = "btnSuccessfulConnection";
            this.btnSuccessfulConnection.Size = new System.Drawing.Size(144, 23);
            this.btnSuccessfulConnection.TabIndex = 1;
            this.btnSuccessfulConnection.Text = "Success";
            this.btnSuccessfulConnection.UseVisualStyleBackColor = true;
            this.btnSuccessfulConnection.Click += new System.EventHandler(this.btnSuccessfulConnection_Click);
            // 
            // btnRaiseConnectionError
            // 
            this.btnRaiseConnectionError.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRaiseConnectionError.Location = new System.Drawing.Point(3, 3);
            this.btnRaiseConnectionError.Name = "btnRaiseConnectionError";
            this.btnRaiseConnectionError.Size = new System.Drawing.Size(144, 23);
            this.btnRaiseConnectionError.TabIndex = 0;
            this.btnRaiseConnectionError.Text = "Connection Error";
            this.btnRaiseConnectionError.UseVisualStyleBackColor = true;
            this.btnRaiseConnectionError.Click += new System.EventHandler(this.btnRaiseConnectionError_Click);
            // 
            // ConnectionErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ConnectionErrors";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnSuccessfulConnection;
        private System.Windows.Forms.Button btnRaiseConnectionError;
    }
}
