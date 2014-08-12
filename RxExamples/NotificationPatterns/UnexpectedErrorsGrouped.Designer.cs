namespace RxExamples.NotificationPatterns
{
    partial class UnexpectedErrorsGrouped
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
            this.btnRaiseDivByZero = new System.Windows.Forms.Button();
            this.btnRaiseNullReference = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.btnRaiseDivByZero, 0, 1);
            this.tlpMain.Controls.Add(this.btnRaiseNullReference, 0, 0);
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
            // btnRaiseDivByZero
            // 
            this.btnRaiseDivByZero.AutoSize = true;
            this.btnRaiseDivByZero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRaiseDivByZero.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRaiseDivByZero.Location = new System.Drawing.Point(3, 32);
            this.btnRaiseDivByZero.Name = "btnRaiseDivByZero";
            this.btnRaiseDivByZero.Size = new System.Drawing.Size(144, 23);
            this.btnRaiseDivByZero.TabIndex = 1;
            this.btnRaiseDivByZero.Text = "Div By Zero";
            this.btnRaiseDivByZero.UseVisualStyleBackColor = true;
            this.btnRaiseDivByZero.Click += new System.EventHandler(this.btnRaiseDivByZero_Click);
            // 
            // btnRaiseNullReference
            // 
            this.btnRaiseNullReference.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRaiseNullReference.Location = new System.Drawing.Point(3, 3);
            this.btnRaiseNullReference.Name = "btnRaiseNullReference";
            this.btnRaiseNullReference.Size = new System.Drawing.Size(144, 23);
            this.btnRaiseNullReference.TabIndex = 0;
            this.btnRaiseNullReference.Text = "Null Reference";
            this.btnRaiseNullReference.UseVisualStyleBackColor = true;
            this.btnRaiseNullReference.Click += new System.EventHandler(this.btnRaiseNullReference_Click);
            // 
            // UnexpectedErrorsGrouped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "UnexpectedErrorsGrouped";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnRaiseDivByZero;
        private System.Windows.Forms.Button btnRaiseNullReference;
    }
}
