using Xamarin.Forms;
using System;
using ZXing;
using ToDoList_Xamarin_SQLite.Services;

namespace ToDoList_Xamarin_SQLite.Views
{
    public partial class ScanBarCode : ContentPage
    {
        private bool _isScanning = true;

        public ScanBarCode()
        {
            InitializeComponent();     
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BarcodeScanView.IsTorchOn = false;
        }

        public async void ScanBarcode(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    if (_isScanning)
                    {
                        _isScanning = false;
                        BarcodeScanView.IsAnalyzing = false;

                        if (string.IsNullOrWhiteSpace(result.Text))
                        {
                            await DisplayAlert("Not found", "Unknown Barcode! Please scan again. ", "OK");
                        }
                        else
                        {
                            //play audio from URL
                            //string filename = "https://jfversluis.dev/Sample.mp3";
                            //mp = new MediaPlayer();
                            //try { mp.SetDataSource(filename); } catch (Exception e) { await Application.Current.MainPage.DisplayAlert("e1", e.Message, "OK");}
                            //try { mp.Prepare(); } catch (Exception e) { await Application.Current.MainPage.DisplayAlert("e2", e.Message, "OK");}
                            //mp.Start();

                            enCodBare.Text = result.Text;
                            _isScanning = true;
                            BarcodeScanView.IsAnalyzing = true;

                            try
                            { DependencyService.Get<IAudioPlayerService>().PlayAudioFile("BarcodeScannerBeep.mp3"); /*music from Assets folder - Android*/}
                            catch (Exception e1)
                            { await Application.Current.MainPage.DisplayAlert("player set path error: ", e1.Message, "OK"); }
                            //await Shell.Current.GoToAsync("..");
                        }
                    }
                }
                catch (Exception x)
                {
                    await Application.Current.MainPage.DisplayAlert("", x.Message, "OK");
                }
            });
            await Application.Current.MainPage.DisplayAlert("Scan result", enCodBare.Text, "OK");
        }

        private void TorchButton_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (BarcodeScanView.IsTorchOn)
                {
                    BarcodeScanView.IsTorchOn = false;
                    flashBtn.Text = "Flash On";
                    flashBtn.BackgroundColor = Color.Green;
                }
                else
                {
                    BarcodeScanView.IsTorchOn = true;
                    flashBtn.Text = "Flash Off";
                    flashBtn.BackgroundColor = Color.Red;
                }
            });
        }
    }
}
