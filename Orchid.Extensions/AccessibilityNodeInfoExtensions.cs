﻿using Android.Text;
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
    /// An extension class for AccessibilityNodeInfoCompat which provides handy extension methods for extending the functionality of original AccessibilityNodeInfoCompat class.
    /// </summary>
    public static class AccessibilityNodeInfoExtensions
    {
        #region Public Methods

        /// <summary>
        /// Determines if the node has any type of click.
        /// </summary>
        /// <param name="node">The AccessibilityNodeInfo object representing the node to check.</param>
        /// <returns>
        ///   <c>true</c> if the node has any type of click; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasClick(this NodeInfo node)
        {
            return node.Clickable || node.LongClickable;
        }

        /// <summary>
        /// Checks if the node has any visible text, hint text or content description.
        /// </summary>
        /// <param name="node">The AccessibilityNodeInfo object representing the node to check.</param>
        /// <returns>
        ///   <c>true</c> if the node has any visible text or content description; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasText(this NodeInfo node)
        {
            return
                            !node.ContentDescription.IsNullOrEmpty() ||
                            !node.Text.IsNullOrEmpty() ||
                            !node.HintText.IsNullOrEmpty();
        }

        #endregion Public Methods
    }
}
