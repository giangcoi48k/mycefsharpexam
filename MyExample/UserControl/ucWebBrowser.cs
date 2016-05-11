using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using MyExample.Handlers;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MyExample.Webbrowser
{
    public partial class ucWebBrowser : UserControl
    {
        string Address;
        public event Action MoveNext;
        ChromiumWebBrowser webbrowser;

        private ucWebBrowser()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public ucWebBrowser(string address)
            : this()
        {
            Dock = DockStyle.Fill;
            InitBrowser(address);
        }

        private void InitBrowser(string address)
        {
            Address = address;
            if (webbrowser != null)
                webbrowser.Dispose();
            webbrowser = new ChromiumWebBrowser(Address);
            webbrowser.Dock = DockStyle.Fill;
            webbrowser.MenuHandler = new MenuHandler();
            webbrowser.JsDialogHandler = new JsDialogHandler();
            webbrowser.DownloadHandler = new DownloadHandler();
            webbrowser.KeyboardHandler = new KeyboardHandler();
            webbrowser.LifeSpanHandler = new LifeSpanHandler();
            webbrowser.GeolocationHandler = new GeolocationHandler();
            webbrowser.FocusHandler = new FocusHandler();
            webbrowser.RequestContext = new RequestContext();

            webbrowser.LoadingStateChanged += Browser_LoadingStateChanged;
            webbrowser.ConsoleMessage += Browser_ConsoleMessage;
            pnlBrowser.Controls.Add(webbrowser);
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;
            try
            {
                lbStatus.SetText(e.IsLoading ? "Loading..." : browser.Address);
                if (!e.IsLoading)
                {
                    browser.ExecuteScriptAsync("setTimeout(function(){console.log('action:redirect');},3000);");
                }
            }
            catch
            {
                MoveNext();
            }
        }

        public void RestartBrowser(string address)
        {
            InitBrowser(address);
        }

        private void Browser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            if (e.Message == "action:redirect")
            {
                MoveNext?.Invoke();
            }
        }
    }
}
