using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Findler
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ResultsPanel.Visibility = Visibility.Collapsed;
            QueryPanel.Visibility = Visibility.Visible;
        }

        public async void MainSequence()
        {
            QueryPanelFadeOut.Begin();

            //Search(ExpertIs.Text, ExpertFor.Text);
            await GetPeople(ExpertIs.Text, ExpertFor.Text);

            DumpBlock.Text = "RESULTS HERE";
            ResultsPanelFadeIn.Begin();       
        }

        private void ExpertFor_KeyDown_1(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                MainSequence();
            }
        }

        private async void Search(string expertIs, string expertFor)
        {
            var fapi = new Services.ApiInteract();
            DumpBlock.Text = await fapi.ApiSearch(expertFor);
        }

        private async Task GetPeople(string expertIs, string expertFor )
        {
            var fapi = new Services.ApiInteract();
            var bleh = await fapi.GetPeople(expertFor);
        }
    }
}
