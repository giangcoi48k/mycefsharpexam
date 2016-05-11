using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyExample
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
        /// </summary>
        /// <param name="control">the control for which the update is required</param>
        /// <param name="action">action to be performed on the control</param>
        public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        public static void SetText(this Control control, string text)
        {
            InvokeOnUiThreadIfRequired(control, () => control.Text = text);
        }

        public static bool Activate(this Control control)
        {
            // Notify WinForms world that inner browser window got focus. This will trigger Leave event to previous focused control
            var containerControl = control.GetContainerControl();
            if (containerControl != null)
            {
                return containerControl.ActivateControl(control);
            }
            return false;
        }

        /// <summary>
        /// Returns whether the supplied control is the currently
        /// active control.
        /// </summary>
        /// <param name="control">the control to check</param>
        /// <returns>true if the control is the currently active control</returns>
        public static bool IsActiveControl(this Control control)
        {
            Control activeControl = control.FindForm().ActiveControl;
            while (activeControl != null
                   && (activeControl is ContainerControl)
                   && !Object.ReferenceEquals(control, activeControl))
            {
                var containerControl = activeControl as ContainerControl;
                activeControl = containerControl.ActiveControl;
            }
            return Object.ReferenceEquals(control, activeControl);
        }

        public static void SelectNextControl(this Control control, bool next)
        {
            var containerControl = control.GetContainerControl();

            while (containerControl != null)
            {
                var containerControlAsControl = containerControl as Control;
                if (containerControlAsControl == null)
                {
                    break;
                }

                var activeControl = containerControl.ActiveControl;
                if (containerControlAsControl.SelectNextControl(activeControl, next, true, true, false))
                {
                    break;
                }

                if (containerControlAsControl.Parent == null)
                {
                    break;
                }

                containerControl = containerControlAsControl.Parent.GetContainerControl();
            }
        }
    }
}
