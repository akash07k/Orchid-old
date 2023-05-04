using Android.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.App
{
    [Application(Label = "@string/app_name")]
    public class OrchidApp : Application
    {
        #region Public Constructors

        public OrchidApp(IntPtr handle, JniHandleOwnership ownership)
    : base(handle, ownership)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void OnCreate()
        {
            base.OnCreate();
        }

        #endregion Public Methods
    }
}
