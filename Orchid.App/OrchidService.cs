using Android.AccessibilityServices;
using Android.Runtime;
using Android.Util;
using Android.Views.Accessibility;
using Orchid.App.EventProcessors;
using Orchid.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.App
{
    [Service(Name = "Services.OrchidService", Label = "@string/app_name", Enabled = true, Exported = false, Permission = "android.permission.BIND_ACCESSIBILITY_SERVICE"), IntentFilter(new[] { "android.accessibilityservice.AccessibilityService" }), MetaData("android.accessibilityservice", Resource = "@xml/serviceconfig")]
    [Register("com.techromantica.orchid.service")]
    public class OrchidService : AccessibilityService
    {
        #region Private Fields

        private const string _TAG = "Orchid.Service";
        private List<IEventProcessor> _eventProcessors = new List<IEventProcessor>();

        #endregion Private Fields

        #region Public Methods

        public override void OnAccessibilityEvent(AccessibilityEvent? e)
        {
            Log.Debug(_TAG, "Received the accessibility event");
            foreach (var processor in _eventProcessors)
            {
                // Log.Debug(_TAG, $"Propagating the accessibility event to {processor.Name}.");
                processor.OnEvent(e);
            }
        }

        public override void OnInterrupt()
        {
            // TODO
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnServiceConnected()
        {
            base.OnServiceConnected();
            Log.Info(_TAG, "OnServiceConnected: Configuring the service.");
            var speechEventProcessor = new SpeechEventProcessor(BaseContext);
            var focusEventProcessor = new FocusEventProcessor(BaseContext);
            var hapticEventProcessor = new HapticEventProcessor(BaseContext);
            _eventProcessors.Add(speechEventProcessor);
            _eventProcessors.Add(focusEventProcessor);
            _eventProcessors.Add(hapticEventProcessor);
        }

        #endregion Protected Methods
    }
}
