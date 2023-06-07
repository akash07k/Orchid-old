using Android.Text;
using Android.Util;
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
    /// An extension class for <see cref="NodeInfo"/> which provides handy extension methods for extending the functionality of original class.
    /// </summary>
    public static class AccessibilityNodeInfoExtensions
    {
        #region Private Fields

        private static string _TAG = "Orchid.AccessibilityNodeExtensions";

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Determines if the <see cref="NodeInfo"/> has any type of click.
        /// </summary>
        /// <param name="node">The <see cref="NodeInfo"/> object representing the node to check.</param>
        /// <returns>
        ///   <c>true</c> if the <see cref="NodeInfo"/> has any type of click; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasClick(this NodeInfo node)
        {
            bool hasClick = node.Clickable || node.LongClickable;
            Log.Debug(_TAG, $"Has click: {hasClick}");
            return hasClick;
        }

        /// <summary>
        /// Checks if the <see cref="NodeInfo"/> has any visible text, hint text or content description.
        /// </summary>
        /// <param name="node">The <see cref="NodeInfo"/> object representing the node to check.</param>
        /// <returns>
        ///   <c>true</c> if the <see cref="NodeInfo"/> has any visible text or content description; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasText(this NodeInfo node)
        {
            bool hasText = !node.ContentDescription.IsNullOrEmpty() ||
                            !node.Text.IsNullOrEmpty() ||
                            !node.HintText.IsNullOrEmpty();
            Log.Debug(_TAG, _TAG, $"Has text: {hasText}");
            return hasText;
        }

        #endregion Public Methods
    }
}
