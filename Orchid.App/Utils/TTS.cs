using Android.Content;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.App.Utils
{
    public class TTS : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        #region Private Fields

        private const string TAG = "Orchid.TTS";
        private readonly Context _context;
        private readonly TextToSpeech _textToSpeech;

        #endregion Private Fields

        #region Public Constructors

        public TTS(Context context)
        {
            Log.Info(TAG, "Initializing the TTS");
            _context = context;
            _textToSpeech = new(context, this);
        }

        #endregion Public Constructors

        #region Public Methods

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                Log.Info(TAG, "TTS initialized successfully");
            }
            if (status == OperationResult.Error)
            {
                Log.Error(TAG, "Error while initializing the TTS");
            }
        }

        public void Shutdown()
        {
            Log.Info(TAG, "Shutting down the TTS");
            _textToSpeech.Shutdown();
        }

        public void Speak(string text)
        {
            Log.Info(TAG, $"Speaking the text: {text}");
            _textToSpeech.Speak(text, QueueMode.Flush, null, null);
        }

        #endregion Public Methods
    }
}
