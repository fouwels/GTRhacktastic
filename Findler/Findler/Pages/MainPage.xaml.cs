// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Findler.Services;
using Findler.Templates;
using Findler.Templates.JsonTemplates.Projects;

namespace Findler
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Reset();
        }

        private void Reset()
        {
            ResultsPanelFadeOut.Begin();
            QueryPanelFadeIn.Begin();
        }

        public async void MainSequence()
        {
            QueryPanelFadeOut.Begin();

            Dictionary<string, PersonReportCard> peopleData = await GetPeople(ExpertIs.Text, ExpertFor.Text);

            DrawProperListview(peopleData);

            ResultsPanelFadeIn.Begin();
        }

        private void DrawProperListview(Dictionary<string, PersonReportCard> peopleData)
        {
            var entries = new List<string>();

            foreach (var person in peopleData)
            {
                String concat = "";

                concat += person.Value.firstname + " " + person.Value.lastname;
                foreach (Project project in person.Value.projects)
                {
                    concat += "\n" + ">>" + project.title + " [" + project.start + "] ";
                }
                concat += "\n";
                entries.Add(concat);
            }

            PersonsItemsControl.ItemsSource = entries;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ExpertIs.Focus(FocusState.Programmatic);
        }

        private void ExpertFor_KeyDown_1(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                MainSequence();
            }
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (args.VirtualKey == VirtualKey.Escape)
            {
                Reset();
            }
        }

        private async void Search(string expertIs, string expertFor)
        {
            var fapi = new ApiInteract();
            DumpBlock.Text = await fapi.ApiSearch(expertFor);
        }

        private async Task<Dictionary<string, PersonReportCard>> GetPeople(string expertIs, string expertFor)
        {
            var fapi = new ApiInteract();
            Dictionary<string, PersonReportCard> register = await fapi.GetPeople(expertFor);
            return register;
        }
    }
}