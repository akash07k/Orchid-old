using Android.Views.Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.App.Interfaces
{
    public interface IEventProcessor
    {
        #region Public Methods

        void OnEvent(AccessibilityEvent accessibilityEvent);

        #endregion Public Methods
    }
}
