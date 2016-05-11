using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyExample.Handlers
{
    internal class GeolocationHandler : IGeolocationHandler
    {
        bool IGeolocationHandler.OnRequestGeolocationPermission(IWebBrowser browserControl, IBrowser browser, string requestingUrl, int requestId, IGeolocationCallback callback)
        {
            return false;
        }

        public void OnCancelGeolocationPermission(IWebBrowser browserControl, IBrowser browser, string requestingUrl, int requestId)
        {
            
        }
    }
}
