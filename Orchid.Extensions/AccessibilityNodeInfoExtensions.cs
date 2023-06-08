using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.View.Accessibility;

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static string _TAG = "Orchid.AccessibilityNodeInfoExtensions";

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

        /// <summary>
        /// Logs the information of a <see cref="NodeInfo"/> object.
        /// </summary>
        /// <param name="node">The <see cref="NodeInfo"/> object to log.</param>
        /// <returns>A string containing the logged information.</returns>
        /// <remarks>
        /// This method logs various properties and states of the <paramref name="node"/> object, including its content, focus states, actionable states, other states, and hierarchy information.
        /// </remarks>
        public static string LogNode(this NodeInfo node)
        {
            List<string> logList = new List<string>();
            try
            {
                // Content.
                logList.Add("\n## Content:\n");
                logList.Add($"Content description: {node?.ContentDescription}");
                logList.Add($"Hint text: {node?.HintText}");
                logList.Add($"Text: {node?.Text}");
                logList.Add($"Package name: {node?.PackageName}");
                logList.Add($"Id: {node?.ViewIdResourceName}");
                logList.Add($"Unique Id: {node?.UniqueId}");
                logList.Add($"Class name: {node?.ClassName}");
                logList.Add($"Is heading: {node?.Heading}");
                logList.Add($"Is important for accessibility: {node?.ImportantForAccessibility}");
                logList.Add($"Error: {node?.Error}");

                // Focus states.
                logList.Add("\n## Focus states");
                logList.Add($"Is focusable: {node?.Focusable}");
                logList.Add($"Is focused: {node?.Focused}");
                logList.Add($"Is accessibility focused: {node?.AccessibilityFocused}");
                logList.Add($"Is screen reader focusable: {node?.ScreenReaderFocusable}");

                // Actionable states.
                logList.Add($"\n## Actionable states");
                logList.Add($"Is checkable: {node?.Checkable}");
                logList.Add($"Is clickable: {node?.Clickable}");
                logList.Add($"Is long clickable: {node?.LongClickable}");
                logList.Add($"Is editable: {node?.Editable}");
                logList.Add($"Is checked: {node?.Checked}");
                logList.Add($"Is enabled: {node?.Enabled}");

                // Other states.
                logList.Add($"\n## Other states");
                logList.Add($"Is password: {node?.Password}");

                // Hierarchy
                logList.Add("\n## Hierarchy");
                logList.Add($"Parent class name: {node?.Parent?.ClassName}");
                logList.Add($"Child count: {node?.ChildCount}");
                logList.Add($"Pane title: {node?.PaneTitle}");
            }
            catch (Java.Lang.NullPointerException ex)
            {
                Log.Error(_TAG, ex.Message);
            }
            string logContent = logList?.JoinToString("\n");
            Debug.Write($"Node information: {Environment.NewLine}{logContent}");
            return logContent;
        }

        #endregion Public Methods
    }
}
