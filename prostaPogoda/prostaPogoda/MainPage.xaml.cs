using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

namespace prostaPogoda
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        

        public async void pobierzTemperature()
        {
            string response = "";
            try
            {
                HttpClient httpClient = new HttpClient();
                response = await httpClient.GetStringAsync(
                    new Uri("http://mnn.dsinf.net/2015/winphone/weather/api.php?" + "miasto="+miasto.Text +"&cel=temperatura" )
                );
            }
            catch (Exception ex)
            {
                response = "--";
            }
            temperatura.Text = response + "°C";
        }
        public async void pobierzPogode()
        {
             pogoda.Source = new BitmapImage( new Uri("http://mnn.dsinf.net/2015/winphone/weather/api.php?" + "miasto=" + miasto.Text + "&cel=obrazek"));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            pobierzTemperature();
            pobierzPogode();
        }
    }
}
