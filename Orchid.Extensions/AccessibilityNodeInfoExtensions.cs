using Android.Content;
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

using Orchid.Extensions.Enums;

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
        /// Retrieves the content of the specified <see cref="NodeInfo"/> based on the provided <see cref="Context"/> context.
        /// </summary>
        /// <param name="node">The <see cref="NodeInfo"/> from which to retrieve the content.</param>
        /// <param name="context">The <see cref="Context"/> used for retrieving the content.</param>
        /// <returns>
        /// A string containing the content of the specified node, separated by commas.
        /// The content is determined based on the following priority:
        /// 1. ContentDescription: If not null or empty, it is used as the content.
        /// 2. Text: If ContentDescription is null or empty, Text is used as the content.
        /// 3. HintText: If both ContentDescription and Text are null or empty, HintText is used as the content.
        /// The result is a combination of the determined content and the readable node type.
        /// </returns>
        public static string GetContent(this NodeInfo node, Context context)
        {
            string content = string.Empty;
            if (!node.ContentDescription.IsNullOrEmpty())
            {
                content = node.ContentDescription;
            }
            else if (!node.Text.IsNullOrEmpty())
            {
                content = node.Text;
            }
            if (!node.HintText.IsNullOrEmpty())
            {
                content = node.HintText;
            }
            string finalContent = new List<string>
{
content, node.GetReadableNodeType(context)
}
            .FilterNotNullOrEmpty()
            .JoinToString(", ");
            return finalContent;
        }

        /// <summary>
        /// Retrieves the <see cref="NodeInfo"/> node type based on the properties of the specified node.
        /// </summary>
        /// <param name="node">The <see cref="NodeInfo"/> NodeInfo object representing the node to determine the type for.</param>
        /// <returns>
        ///   The NodeType corresponding to the properties of the node. The returned NodeType can be one of the following:
        ///   - If the node is an ImageButton, NodeType.BUTTON is returned.
        ///   - If the node is an ImageView and clickable, NodeType.BUTTON is returned; otherwise, NodeType.IMAGE is returned.
        ///   - If the node is an EditText, NodeType.EDITABLE is returned.
        ///   - If the node is a Switch, NodeType.SWITCH is returned.
        ///   - If the node is a ToggleButton, NodeType.TOGGLE is returned.
        ///   - If the node is a RadioButton, NodeType.RADIO is returned.
        ///   - If the node is a CheckBox, NodeType.CHECKBOX is returned.
        ///   - If the node is a Button, NodeType.BUTTON is returned.
        ///   - If the node is an AbsListView, NodeType.LIST is returned.
        ///   - If the node is an AbsSpinner, NodeType.OPTIONS is returned.
        ///   - If the node is checkable, NodeType.CHECKABLE is returned.
        ///   - If the node is editable, NodeType.EDITABLE is returned.
        ///   - If the node has a CollectionInfo, NodeType.LIST is returned.
        ///   - If the node is a heading, NodeType.TITLE is returned.
        ///   - If the node is clickable, NodeType.BUTTON is returned.
        ///   - If none of the above conditions match, NodeType.NONE is returned.
        /// </returns>
        public static NodeType GetNodeType(this NodeInfo node)
        {
            Debug.WriteLine("Getting the node type");
            if (typeof(ImageButton).IsInstanceOfType(node))
            {
                return NodeType.BUTTON;
            }
            if (typeof(ImageView).IsInstanceOfType(node))
            {
                return node.Clickable ? NodeType.BUTTON : NodeType.IMAGE;
            }
            if (typeof(EditText).IsInstanceOfType(node))
            {
                return NodeType.EDITABLE;
            }
            if (typeof(Android.Widget.Switch).IsInstanceOfType(node))
            {
                return NodeType.SWITCH;
            }
            if (typeof(ToggleButton).IsInstanceOfType(node))
            {
                return NodeType.TOGGLE;
            }
            if (typeof(RadioButton).IsInstanceOfType(node))
            {
                return NodeType.RADIO;
            }
            if (typeof(CheckBox).IsInstanceOfType(node))
            {
                return NodeType.CHECKBOX;
            }
            if (typeof(Button).IsInstanceOfType(node))
            {
                return NodeType.BUTTON;
            }
            if (typeof(AbsListView).IsInstanceOfType(node))
            {
                return NodeType.LIST;
            }
            if (typeof(AbsSpinner).IsInstanceOfType(node))
            {
                return NodeType.OPTION;
            }
            if (node.Checkable)
            {
                return NodeType.CHECKABLE;
            }
            if (node.Editable)
            {
                return NodeType.EDITABLE;
            }
            if (node.CollectionInfo != null)
            {
                return NodeType.LIST;
            }
            if (node.Heading)
            {
                return NodeType.TITLE;
            }
            if (node.Clickable)
            {
                return NodeType.BUTTON;
            }
            else
                return NodeType.NONE;
        }

        /// <summary>
        /// Retrieves the <see cref="NodeInfo"/> readable node type based on the properties of the specified node.
        /// </summary>
        /// <param name="node">The <see cref="NodeInfo"/> NodeInfo object representing the node to determine the type for.</param>
        /// <param name="context">The <see cref="Context"/> for accessing the string resource.</param>
        /// <returns>
        ///   The NodeType corresponding to the properties of the node.
        ///   </returns>
        public static string GetReadableNodeType(this NodeInfo node, Context context)
        {
            Debug.WriteLine("Getting the readable node type");
            var nodeType = node.GetNodeType();
            return (nodeType) switch
            {
                NodeType.NONE => string.Empty,
                NodeType.IMAGE => context.GetString(Resource.String.text_image_type),
                NodeType.SWITCH => context.GetString(Resource.String.text_switch_type, node.GetState(context)),
                NodeType.TOGGLE => context.GetString(Resource.String.text_toggle_type, node.GetState(context)),
                NodeType.RADIO => context.GetString(Resource.String.text_radio_type, node.GetState(context)),
                NodeType.CHECKBOX => context.GetString(Resource.String.text_checkbox_type, node.GetState(context)),
                NodeType.CHECKABLE => context.GetString(Resource.String.text_checkable_type, node.GetState(context)),
                NodeType.BUTTON => context.GetString(Resource.String.text_button_type),
                NodeType.EDITABLE => context.GetString(Resource.String.text_editable_type),
                NodeType.OPTION => context.GetString(Resource.String.text_option_type),
                NodeType.LIST => context.GetString(Resource.String.text_list_type),
                NodeType.TITLE => context.GetString(Resource.String.text_title_type),
                _ => string.Empty,
            };
        }

        /// <summary>
        /// Gets the state text based on the properties of the specified <see cref="NodeInfo"/> node.
        /// </summary>
        /// <param name="node">The <see cref="NodeInfo"/> NodeInfo object representing the node to retrieve the state text for.</param>
        /// <returns>
        ///   The state text corresponding to the properties of the node. The returned text can be one of the following:
        ///   - If the node is enabled, the text from the resource with the ID Resource.String.text_enabled is returned.
        ///   - If the node is disabled, the text from the resource with the ID Resource.String.text_disabled is returned.
        ///   - If the node is checked, the text from the resource with the ID Resource.String.text_checked is returned.
        ///   - If the node is unchecked, the text from the resource with the ID Resource.String.text_unchecked is returned.
        ///   - If the state cannot be determined, the text from the resource with the ID Resource.String.text_unknown is returned.
        /// </returns>
        public static string GetState(this NodeInfo node, Context context)
        {
            Debug.WriteLine("Getting the state of the node");
            if (node.Enabled)
            {
                return context.GetString(Resource.String.text_enabled);
            }
            if (!node.Enabled)
            {
                return context.GetString(Resource.String.text_disabled);
            }
            if (node.Checked)
            {
                return context.GetString(Resource.String.text_checked);
            }
            if (!node.Checked)
            {
                return context.GetString(Resource.String.text_unchecked);
            }
            else
                return context.GetString(Resource.String.text_unknown);
        }

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
