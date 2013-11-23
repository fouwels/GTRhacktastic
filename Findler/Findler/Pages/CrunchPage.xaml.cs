using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Findler.Pages
{
    public sealed partial class CrunchPage : Page
    {
        public CrunchPage()
        {
          InitializeComponent();  
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            StatusMessage.Text = "Doing shit";
            TheProgressRing.IsActive = true;
            //Do stuff

            await Task.Delay(1000);

            TheProgressRing.IsActive = false;
            var fr = new Frame();
            fr.Navigate(typeof(MainPage));
            Window.Current.Content = fr;
            Window.Current.Activate();
        }
    }
}
