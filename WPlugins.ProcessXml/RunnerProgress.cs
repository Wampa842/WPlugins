using System;
using System.Windows.Forms;

namespace WPlugins.ProcessXml
{
    public class RunnerProgress
    {
        private readonly TextBox _messageTextBox;
        private readonly ProgressBar _progressBar;

        public bool Cancel { get; set; }

        public RunnerProgress(TextBox messageTextBox, ProgressBar progressBar)
        {
            _messageTextBox = messageTextBox;
            _progressBar = progressBar;
            Cancel = false;
        }

        public void Report(int percent)
        {
            _progressBar.Value = percent;
        }

        public void Report(string message)
        {
            _messageTextBox.AppendText(message + Environment.NewLine);
        }

        public void Report(int percent, string message)
        {
            _progressBar.Value = percent;
            _messageTextBox.AppendText(message + Environment.NewLine);
        }
    }
}
