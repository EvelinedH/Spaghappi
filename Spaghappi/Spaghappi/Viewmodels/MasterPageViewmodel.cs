using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Spaghappi.Models;
using Spaghappi.Services;
using Spaghappi.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Spaghappi.Viewmodels
{
   
    class MasterPageViewmodel
    {
        public String PageTitle { get; set; }
        public Command ListCommand { get; set; }
        public Command CheckStockCommand { get; set; }
        public Command AddCommand { get; set; }
        public Command FillCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        public MasterPageViewmodel()
        {
            ListCommand = new Command(GotoListPage);        // voorraad bekijken
            CheckStockCommand = new Command(CheckStock);    // spaghetti klaarmaken
            AddCommand = new Command(GotoChooseAddPage);    // boodschappen toevoegen
            FillCommand = new Command(MakeStock);           // 1 (resetten voorraad bij SQLite)
            DeleteCommand = new Command(DeleteIngredient);
            PageTitle = "Spaghappi";
        }

        public void OnAppearing()
        {

        } 

        public void GotoListPage()
        {
            App.Current.MainPage.Navigation.PushAsync(new IngredientListView());
        }

        public void GotoChooseAddPage()
        {
            App.Current.MainPage.Navigation.PushAsync(new ChooseAddView());
        }

        async public void CheckStock()
        {
            Boolean Stock = true;
            var IngredientFromDataStore = await DataStore.GetAllIngredientAsync();
            foreach (Ingredient i in IngredientFromDataStore)
            {
                if (i.Quantity < 1) {
                    Stock = false;
                }
            }
            if (Stock == true)
            {
                StockOk();
            }
            else StockNotOk();
        }

        async void StockOk()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Er is voldoende voorraad", "Ga je spaghetti maken?", "Ja", "Nee");
            if (answer) {
                HappyMeal();
            }
        }
        async public void HappyMeal()
        {
            await App.Current.MainPage.DisplayAlert("Smakelijk!", "De voorraad wordt automatisch aangepast", "OK");
            var IngredientFromDataStore = await DataStore.GetAllIngredientAsync();
            foreach (Ingredient i in IngredientFromDataStore)
            {
                i.Quantity -= 1;
                DataStore.UpdateIngredient(i);
            }
            await DataStore.GetAllIngredientAsync();
        }

        public void StockNotOk()
            {
                App.Current.MainPage.DisplayAlert("Er is onvoldoende voorraad", "Bekijk voorraad en ga boodschappen doen", "OK");
            }

        public void MakeStock()
        {
            DataStore.RestoreAsync();
        }

        async public void DeleteIngredient()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DeleteIngredientView());
        }
    }

}
