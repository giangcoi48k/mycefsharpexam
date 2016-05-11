using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyExample.Handlers
{
    public class LifeSpanHandler : ILifeSpanHandler
    {
        //public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        //{
        //    //Default behaviour
        //    newBrowser = null;

        //    //browserControl.Load(targetUrl);
        //    return true;

        //    //return false; //Return true to cancel the popup creation

        //    ////EXPERIMENTAL: Demonstrates using a new instance of ChromiumWebBrowser to host the popup.
        //    //var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

        //    //ChromiumWebBrowser chromiumBrowser = null;

        //    //var windowX = windowInfo.X;
        //    //var windowY = windowInfo.Y;
        //    //var windowWidth = (windowInfo.Width == int.MinValue) ? 600 : windowInfo.Width;
        //    //var windowHeight = (windowInfo.Height == int.MinValue) ? 800 : windowInfo.Height;

        //    //chromiumWebBrowser.Invoke(new Action(() =>
        //    //{
        //    //    var owner = chromiumWebBrowser.FindForm();
        //    //    chromiumBrowser = new ChromiumWebBrowser(targetUrl)
        //    //    {
        //    //        LifeSpanHandler = this
        //    //    };
        //    //    chromiumBrowser.SetAsPopup();

        //    //    var popup = new Form
        //    //    {
        //    //        Left = windowX,
        //    //        Top = windowY,
        //    //        Width = windowWidth,
        //    //        Height = windowHeight,
        //    //        Text = targetFrameName
        //    //    };

        //    //    owner.AddOwnedForm(popup);

        //    //    popup.Controls.Add(new Label { Text = "CefSharp Custom Popup" });
        //    //    popup.Controls.Add(chromiumBrowser);

        //    //    popup.Show();
        //    //}));

        //    //newBrowser = chromiumBrowser;

        //    //return false;
        //}

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IWindowInfo windowInfo, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            //Default behaviour
            newBrowser = null;

            //browserControl.Load(targetUrl);
            return true;
        }
    }
}
