using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Spaghappi.Models;
using Spaghappi.Services;
using Spaghappi.Views;
using Xamarin.Forms;

namespace Spaghappi.Viewmodels
{
    class ChooseIngredientViewmodel
    {
        public String PageTitle { get; set; }
        public Ingredient SelectedIngredient { get; set; }
        public Command FinishedCommand { get; set; }
        public Command NewCommand { get; set; }
        public ObservableCollection<Ingredient> IngredientList { get; set; }

        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        public ChooseIngredientViewmodel()
        {
            PageTitle = "Kies een Ingrediënt";
            FinishedCommand = new Command(GotoMasterPage);
            NewCommand = new Command(NewIngredient);
            IngredientList = new ObservableCollection<Ingredient>();
            GetData();
        }

        async private void GetData()
        {
            var IngredientFromDataStore = await DataStore.GetAllIngredientAsync();

            IngredientList.Clear();
            foreach (var ingredient in IngredientFromDataStore)
            {
                IngredientList.Add(ingredient);
            }
            
        }

        public async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (SelectedIngredient != null)
            {
                bool answer = await App.Current.MainPage.DisplayAlert(SelectedIngredient.ProductName + " geselecteerd", "Er zijn " + SelectedIngredient.Quantity + " stuks in voorraad. Wil je van dit product nog eentje toevoegen?", "Ja", "Nee");
                if (answer)
                {
                    SelectedIngredient.Quantity += 1;
                    DataStore.UpdateIngredient(SelectedIngredient);
                    GetData();
                }
            }
            SelectedIngredient = null;
            ((ListView)sender).SelectedItem = null;
        }

        public void GotoMasterPage()
        {
            App.Current.MainPage.Navigation.PopToRootAsync();
        }
        async public void NewIngredient()
        {
            Ingredient newIngredient = new Ingredient();
            string result1 = await App.Current.MainPage.DisplayPromptAsync("Nieuw Ingrediënt",
                                                        "Vul de barcode in (13 cijfers)", keyboard: Keyboard.Numeric);

            if (result1 != null && result1!="")
            {
                string result2 = await App.Current.MainPage.DisplayPromptAsync("Nieuw Ingrediënt", "Vul de naam van dit product in");
                newIngredient.Barcode = result1;
                newIngredient.ProductName = result2;
                newIngredient.Quantity = 1;

                DataStore.AddIngredient(newIngredient);

               // await DataStore.GetAllIngredientAsync();
                GetData();
                //newIngredient = null;
            }   
        }
    } 
}
