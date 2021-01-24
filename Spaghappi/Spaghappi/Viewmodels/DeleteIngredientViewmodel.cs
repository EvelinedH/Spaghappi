using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Spaghappi.Models;
using Spaghappi.Services;
using Xamarin.Forms;

namespace Spaghappi.Viewmodels
{
    class DeleteIngredientViewmodel
    {
        public String PageTitle { get; set; }
        public Ingredient SelectedIngredient { get; set; }
        public Command FinishedCommand { get; set; }
        public ObservableCollection<Ingredient> IngredientList { get; set; }

        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        public DeleteIngredientViewmodel()
        {
            PageTitle = "Kies een Ingrediënt";
            FinishedCommand = new Command(GotoMasterPage);
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
                    bool answer = await App.Current.MainPage.DisplayAlert(SelectedIngredient.ProductName + " geselecteerd", "Wil je dit product verwijderen uit de voorraad?", "Ja", "Nee");
                    if (answer)
                    {
                        DataStore.DeleteIngredient(SelectedIngredient);
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
    }
}