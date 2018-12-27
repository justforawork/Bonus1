using System;
using static System.Math;
using Xamarin.Forms;
using Xamarin.Essentials;
using App5.Services;

namespace App5
{
        
    public partial class MainPage : ContentPage
    {
        private string password = "123";
        SensorSpeed speed = SensorSpeed.UI;
        //double xA, yA, zA;

        public MainPage()
        {
            InitializeComponent();
            newPassLabel.IsVisible = false;
            newPassEntry.IsVisible = false;
            applyButton.IsVisible = false;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            mainSwitch.Toggled += MainSwitch_Toggled;
        }

        private void MainSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (mainSwitch.IsToggled == true && !(Accelerometer.IsMonitoring))
                Accelerometer.Start(speed);
            //ToggleAccelerometer();
            else if (mainSwitch.IsToggled == false && passEntry.Text == password && Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();
                //ToggleAccelerometer();
            }
            else
            {
                DisplayAlert("!", "You wrote wrong password.", "ОK");
            }
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            double xA=0,yA=0,zA=0;
            xA = data.Acceleration.X;
            yA = data.Acceleration.Y;
            zA = data.Acceleration.Z;
            if (Abs(xA) + Abs(yA) + Abs(zA) >= 1.5)
                DependencyService.Get<IAudio>().PlayMp3File();
            xLabel.Text = " X: " + xA;
            yLabel.Text = " Z: " + yA;
            zLabel.Text = " Y: " + zA;
            xA = 0;
            yA = 0;
            zA = 0;
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    Accelerometer.Stop();
                    topLabel.Text = "Stopped";
                }
                else
                {
                    Accelerometer.Start(speed);
                    topLabel.Text = "Started";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private void ConfigButton_Clicked(object sender, EventArgs e)
        {
            if (passEntry.Text == password)
            {
                if (newPassLabel.IsVisible == true)
                {
                    newPassLabel.IsVisible = false;
                    newPassEntry.IsVisible = false;
                    applyButton.IsVisible = false;
                }
                else
                {
                    newPassLabel.IsVisible = true;
                    newPassEntry.IsVisible = true;
                    applyButton.IsVisible = true;
                }
            }
            else
            {
                DisplayAlert("!", "You wrote wrong password.", "ОK");
            }
        }

        private void StopPlayingButton_Clicked(object sender, EventArgs e)
        {
            //stopPlayingButton.Text = passEntry.Text + " - " + password;
            if (passEntry.Text == password)
            {
                DependencyService.Get<IAudio>().StopPlay();
            }
            else
                DisplayAlert("!", "You wrote wrong password.", "ОK");
        }

        private void ApplyButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudio>().PlayMp3File();
        }

    }
}
