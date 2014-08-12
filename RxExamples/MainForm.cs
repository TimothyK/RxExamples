using System;
using System.Linq;
using System.Windows.Forms;
using RxExamples.NotificationPatterns;

namespace RxExamples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void chkDelayTimesTen_CheckedChanged(object sender, EventArgs e)
        {
            TimeSpanFactory.Multiplier = chkDelayTimesTen.Checked ? 10 : 1;
            LoadSelectedPattern();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tlpMain.Controls.Remove(lblPatternPlaceHolder);

            var patterns = NotificationPatternFactory.All()
                .OrderBy(pattern => pattern.PatternName)
                .ToList();
            cboPattern.DataSource = patterns;
            cboPattern.DisplayMember = "PatternName";
        }

        private void cboPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedPattern();
        }

        private void LoadSelectedPattern()
        {
            var factory = (NotificationPatternFactory) cboPattern.SelectedItem;
            NotificationPatternControl = factory.CreateInstance();

            txtRaw.Text = string.Empty;
            txtNotification.Text = string.Empty;
        }

        private NotificationPattern NotificationPatternControl
        {
            get { return (NotificationPattern) tlpMain.GetControlFromPosition(0, 1); }
            set
            {
                var oldControl = NotificationPatternControl;
                if (oldControl != null)
                {
                    tlpMain.Controls.Remove(oldControl);
                    oldControl.Dispose();

                    oldControl.RawMessage -= AddMessageToRaw;
                    oldControl.NotificationMessage -= AddMessageToNotification;                        
                }

                value.Anchor = AnchorStyles.None;
                tlpMain.Controls.Add(value, 0, 1);

                value.RawMessage += AddMessageToRaw;
                value.NotificationMessage += AddMessageToNotification;
            }
        }

        void AddMessageToRaw(string message)
        {
            AddMessageToTextBox(txtRaw, message);
        }

        void AddMessageToNotification(string message)
        {
            AddMessageToTextBox(txtNotification, message);
        }

        static void AddMessageToTextBox(TextBox textBox, string message)
        {
            textBox.Text += DateTime.Now.ToString("HH:mm:ss.fff") + " - " + message + Environment.NewLine;
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }
    }
}
