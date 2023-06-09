using Android.Content;
using Android.OS;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.App.Utils
{
    /// <summary>
    /// Represents a class that handles vibration operations.
    /// </summary>
    public class Vibe
    {
        #region Private Fields

        private const string _TAG = "Orchid.Vibe";
        private readonly Context _context;
        private Vibrator _vibrator;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Vibe"/> class with the specified context.
        /// </summary>
        /// <param name="context">The context used for vibration operations.</param>
        public Vibe(Context context)
        {
            Log.Info(_TAG, "Initializing the vibrator");
            _context = context;
            _vibrator = (Vibrator)context.GetSystemService(Context.VibratorService);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Vibrates the device for the specified duration in milliseconds.
        /// </summary>
        /// <param name="milliseconds">The duration of the vibration in milliseconds.</param>
        public void Vibrate(int milliseconds)
        {
            var vibrationEffect = VibrationEffect.CreateOneShot(milliseconds, VibrationEffect.DefaultAmplitude);
            // Cancel other vibrations taking place.
            _vibrator.Cancel();
            _vibrator.Vibrate(vibrationEffect);
        }

        /// <summary>
        /// Vibrates the device with a click effect.
        /// </summary>
        public void VibrateClick()
        {
            var vibrationEffect = VibrationEffect.CreatePredefined(VibrationEffect.EffectClick);
            // Cancel other vibrations taking place.
            _vibrator.Cancel();
            _vibrator.Vibrate(vibrationEffect);
        }

        /// <summary>
        /// Vibrates the device with a double click effect.
        /// </summary>
        public void VibrateDoubleClick()
        {
            var vibrationEffect = VibrationEffect.CreatePredefined(VibrationEffect.EffectDoubleClick);
            // Cancel other vibrations taking place.
            _vibrator.Cancel();
            _vibrator.Vibrate(vibrationEffect);
        }

        /// <summary>
        /// Vibrates the device with a heavy click effect.
        /// </summary>
        public void VibrateHeavyClick()
        {
            var vibrationEffect = VibrationEffect.CreatePredefined(VibrationEffect.EffectHeavyClick);
            // Cancel other vibrations taking place.
            _vibrator.Cancel();
            _vibrator.Vibrate(vibrationEffect);
        }

        /// <summary>
        /// Vibrates the device with a tick effect.
        /// </summary>
        public void VibrateTick()
        {
            var vibrationEffect = VibrationEffect.CreatePredefined(VibrationEffect.EffectTick);
            // Cancel other vibrations taking place.
            _vibrator.Cancel();
            _vibrator.Vibrate(vibrationEffect);
        }

        #endregion Public Methods
    }
}
