using Android.AccessibilityServices;
using Android.Runtime;
using Android.Views.Accessibility;
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
        #region Public Methods

        public override void OnAccessibilityEvent(AccessibilityEvent? e)
        {
            throw new NotImplementedException();
        }

        public override void OnInterrupt()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnServiceConnected()
        {
            base.OnServiceConnected();
        }

        #endregion Protected Methods
    }
}
