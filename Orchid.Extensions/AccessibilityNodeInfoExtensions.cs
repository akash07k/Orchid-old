using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.Core.View.Accessibility;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.Extensions
{
    using NodeInfo = AccessibilityNodeInfoCompat;
    using NodeAction = AccessibilityNodeInfoCompat.AccessibilityActionCompat;

    /// <summary>
    /// An extension class for AccessibilityNodeInfoCompat which provides handy extension methods for extending the functionality of original AccessibilityNodeInfoCompat class
    /// </summary>
    public static class AccessibilityNodeInfoExtensions
    {
        #region Public Methods

        /// <summary>
        /// Checks if the node has any type of click
        /// </summary>
        /// <param name="node">AccessibilityNodeInfo</param>
        /// <returns>True if the node has any type of click, false otherwise</returns>
        public static bool HasClick(this NodeInfo node)
        {
            return node.Clickable || node.LongClickable;
        }

        #endregion Public Methods
    }
}
