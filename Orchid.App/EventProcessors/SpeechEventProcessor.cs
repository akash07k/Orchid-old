using Android.Content;
using Android.Util;
using Android.Views.Accessibility;
using AndroidX.Core.View.Accessibility;
using Orchid.App.Interfaces;
using Orchid.App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.App.EventProcessors
{
    using NodeInfo = AccessibilityNodeInfoCompat;

    public class SpeechEventProcessor : IEventProcessor
    {
        #region Private Fields

        private const string _TAG = "Orchid.SpeechEventProcessor";
        private readonly Context _context;
        private readonly TTS _tts;

        #endregion Private Fields

        #region Public Properties

        public string Name
        {
            get { return _TAG; }
        }

        #endregion Public Properties

        #region Public Constructors

        public SpeechEventProcessor(Context context)
        {
            Log.Debug(_TAG, $"Initializing the {_TAG}.");
            _context = context;
            _tts = new TTS(context);
        }

        #endregion Public Constructors

        #region Public Methods

        public void OnEvent(AccessibilityEvent accessibilityEvent)
        {
            Log.Debug(_TAG, "Received the event, processing it.");
        }

        #endregion Public Methods
    }
}
