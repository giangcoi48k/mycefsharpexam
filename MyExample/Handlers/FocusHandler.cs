using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace MyExample.Handlers
{
    public class FocusHandler : IFocusHandler
    {
        public void OnGotFocus()
        {
            
        }

        public bool OnSetFocus(CefFocusSource source)
        {
            return false;
        }

        public void OnTakeFocus(bool next)
        {
            
        }
    }
}
