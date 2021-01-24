using System;
using System.Collections.Generic;
using System.Text;
using Spaghappi.Views;
using Xamarin.Forms;

namespace Spaghappi.Viewmodels
{
    class ChoosAddViewmodel
    {
        public String PageTitle { get; set; }
        public Command BarCommand { get; set; }
        public Command ManuelCommand { get; set; }
        public Command EndCommand { get; set; }

        public ChoosAddViewmodel()
        {
            PageTitle = "Toevoegkeuze";
            ManuelCommand = new Command(GotoAddManuel);
            BarCommand = new Command(GotoScanner);
            EndCommand = new Command(GotoMasterPage);
        }

        public void GotoAddManuel()
        {
            App.Current.MainPage.Navigation.PushAsync(new ChooseIngredientView());
        }
        public void GotoScanner()
        {
            App.Current.MainPage.Navigation.PushAsync(new ScannerView());
        }
        public void GotoMasterPage()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
