using System;
using System.Collections.Generic;
using System.Text;
using Spaghappi.Models;
using Spaghappi.Services;
using Spaghappi.Views;
using Xamarin.Forms;

namespace Spaghappi.Viewmodels
{
    
    class AddIngredientViewmodel
    {
        public String PageTitle { get; set; }
        public Command NoCommand { get; set; }
        public Command YesCommand { get; set; }
        public Ingredient i { get; set; }
        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        public AddIngredientViewmodel(Ingredient ingredient)
        {
            PageTitle = "Voeg ingrediënt toe aan de voorraad";
            NoCommand = new Command(Nee);
            YesCommand = new Command(Ja);
            i = ingredient;
        }

        public void Nee()
        {
            App.Current.MainPage.Navigation.PushAsync(new ScannerView());
        }
        async public void Ja()
        {
            i.Quantity += 1;
            DataStore.UpdateIngredient(i);
            await App.Current.MainPage.Navigation.PushAsync(new ScannerView());
            await DataStore.GetAllIngredientAsync();
        }
    }
}
