using Android.Views.Accessibility;
using Orchid.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.App.EventProcessors
{
    public class SpeechEventProcessor : IEventProcessor
    {
        #region Private Fields

        private const string _TAG = "Orchid.SpeechEventProcessor";

        #endregion Private Fields

        #region Public Properties

        public string Name
        {
            get { return _TAG; }
        }

        #endregion Public Properties

        #region Public Methods

        public void OnEvent(AccessibilityEvent accessibilityEvent)
        {
            // TODO
        }

        #endregion Public Methods
    }
}
