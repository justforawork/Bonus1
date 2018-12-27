using Xamarin.Forms;
using Android.Media;
using App5.Services;
using System;

[assembly: Dependency(typeof(App5.Droid.Services.AudioService))]

namespace App5.Droid.Services
{
    public class AudioService : IAudio
    {
        public AudioService() { }

        private MediaPlayer _mediaPlayer;

        public bool PlayMp3File() 
        {
            try
            {
                _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.siren);
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
            _mediaPlayer.Start();

            return true;
        }

        public bool StopPlay()
        {
                _mediaPlayer.Stop();
                _mediaPlayer.Reset();
            
            return true;
        }
        
    }
}