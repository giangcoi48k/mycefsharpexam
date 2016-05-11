using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MyExample.Webbrowser;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace MyExample
{
    public partial class FrmMain : Form
    {
        ucWebBrowser webbrowser = null;
        public FrmMain()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.FormClosing += FrmMain_FormClosing;
            lbAdress.SelectedIndex = 0;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                e.Cancel = false;
            else if (e.CloseReason == CloseReason.TaskManagerClosing)
                e.Cancel = true;
            else if (MessageBox.Show("Are you sure close program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStartStop.Text == "Start")
                {
                    CreateNewWebview();
                    ToggleLeftPanel(false);
                }
                else
                {
                    ToggleLeftPanel(true);
                    DisposeWebview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
        }

        private void CreateNewWebview()
        {
            try
            {
                webbrowser = new ucWebBrowser((string)lbAdress.SelectedItem);
                webbrowser.MoveNext += Webbrowser_MoveNext;
                splitContainer1.Panel2.Controls.Add(webbrowser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
        }

        private void Webbrowser_MoveNext()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                try
                {
                    int index = lbAdress.SelectedIndex;
                    if (index < lbAdress.Items.Count - 1)
                    {
                        index += 1;
                        lbAdress.SelectedIndex = index;
                        ReloadWebview();
                    }
                    else
                    {
                        ToggleLeftPanel(true);
                        DisposeWebview();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            });
        }

        private void ReloadWebview()
        {
            if (webbrowser != null)
                webbrowser.RestartBrowser((string)lbAdress.SelectedItem);
        }

        private void DisposeWebview()
        {
            if (webbrowser != null)
            {
                webbrowser.Dispose();
                webbrowser = null;
            }
            GC.Collect();
        }

        private void ToggleLeftPanel(bool enable)
        {
            groupBox2.Enabled = enable;
            btnStartStop.Text = enable ? "Start" : "Stop";
        }

        [DllImport("User32.dll")]
        private static extern bool LockSetForegroundWindow(uint uLockCode);

        protected override bool ShowWithoutActivation
        {
            get
            {
                return false;
            }
        }
        
    }
}
