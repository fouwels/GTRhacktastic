using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            StatusMessage.Text = "Calculating";
            TheProgressRing.IsActive = true;
            //Do stuff

            await Task.Delay(1000);

            TheProgressRing.IsActive = false;
            var fr = new Frame();
            fr.Navigate(typeof (MainPage));
            Window.Current.Content = fr;
            Window.Current.Activate();
        }
    }
}