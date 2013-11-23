using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
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
using Findler.Templates;

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
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            ScrollViewer.SetVerticalScrollBarVisibility(PersonsItemsControl, ScrollBarVisibility.Hidden);
            Reset();
        }

        private async void Reset()
        {
            ResultsPanelFadeOut.Begin();
            QueryPanelFadeIn.Begin();
        }

        public async void MainSequence()
        {
            QueryPanelFadeOut.Begin();

            //Search(ExpertIs.Text, ExpertFor.Text);
            var peopleData = await GetPeople(ExpertIs.Text, ExpertFor.Text);

            //DrawTextDump(peopleData);

            DrawProperListview(peopleData);

            ResultsPanelFadeIn.Begin();       
        }

        private void DrawProperListview(Dictionary<string, PersonReportCard> peopleData)
        {

            List<string> entries = new List<string>();

            foreach (var person in peopleData)
            {
                String concat = "";

                concat += person.Value.firstname + " " + person.Value.lastname;
                foreach (var project in person.Value.projects)
                {
                    concat += "\n" + ">>" + project.title + " [" + project.start + "] ";
                }
                concat += "\n";
                entries.Add(concat);
            }
            
            PersonsItemsControl.ItemsSource = entries;
        }

        private void DrawTextDump(Dictionary<string,PersonReportCard> peopleData)
        {
            String output = "";

            foreach (var personReportCard in peopleData)
            {
                output += "\n" + personReportCard.Value.firstname + " - " + personReportCard.Value.lastname;
                foreach (var project in personReportCard.Value.projects)
                {
                    output += "\n>>" + project.title + " [" + project.start + "] " + "\n";
                }
                output += "\n";
            }

            DumpBlock.Text = output;         
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ExpertIs.Focus(FocusState.Programmatic);
        }

        private void ExpertFor_KeyDown_1(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                MainSequence();
            }
        }

        void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.Escape)
            {
                Reset();
            }
        }

        private async void Search(string expertIs, string expertFor)
        {
            var fapi = new Services.ApiInteract();
            DumpBlock.Text = await fapi.ApiSearch(expertFor);
        }

        private async Task<Dictionary<string, PersonReportCard>>  GetPeople(string expertIs, string expertFor )
        {
            var fapi = new Services.ApiInteract();
            var register = await fapi.GetPeople(expertFor);
            return register;
        }
    }
}
