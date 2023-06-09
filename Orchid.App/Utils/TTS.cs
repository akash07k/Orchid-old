using Android.Content;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides text-to-speech functionality for the application.
/// </summary>
namespace Orchid.App.Utils
{
    /// <summary>
    /// Represents a class that handles text-to-speech operations.
    /// </summary>
    public class TTS : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        #region Private Fields

        private const string _TAG = "Orchid.TTS";
        private readonly Context _context;
        private readonly TextToSpeech _textToSpeech;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TTS"/> class with the specified context.
        /// </summary>
        /// <param name="context">The context used for text-to-speech operations.</param>
        public TTS(Context context)
        {
            Log.Info(_TAG, "Initializing the TTS");
            _context = context;
            _textToSpeech = new(context, this);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Called to indicate the completion of the TextToSpeech engine initialization.
        /// </summary>
        /// <param name="status">The initialization status.</param>
        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                Log.Info(_TAG, "TTS initialized successfully");
            }
            if (status == OperationResult.Error)
            {
                Log.Error(_TAG, "Error while initializing the TTS");
            }
        }

        /// <summary>
        /// Shuts down the TextToSpeech engine.
        /// </summary>
        public void Shutdown()
        {
            Log.Info(_TAG, "Shutting down the TTS");
            _textToSpeech.Shutdown();
        }

        /// <summary>
        /// Speaks the specified text using the TextToSpeech engine.
        /// </summary>
        /// <param name="text">The text to be spoken.</param>
        public void Speak(string text)
        {
            Log.Debug(_TAG, $"Speaking the text: {text}.");
            _textToSpeech.Speak(text, QueueMode.Flush, null, null);
        }

        #endregion Public Methods
    }
}
