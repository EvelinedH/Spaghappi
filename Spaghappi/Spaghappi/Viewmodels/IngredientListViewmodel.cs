using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Spaghappi.Models;
using Spaghappi.Services;
using Xamarin.Forms;

namespace Spaghappi.Viewmodels
{
    class IngredientListViewmodel
    {
        public String ProductName { get; set; }
        public String Barcode { get; set; }
        public String PageTitle { get; set; }

        public Command EndCommand { get; set; }
        public ObservableCollection<Ingredient> IngredientList { get; set; }

        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        public IngredientListViewmodel()
        {
            PageTitle = "Ingrediëntenlijst";
            IngredientList = new ObservableCollection<Ingredient>();
            GetData();
            EndCommand = new Command(GotoMasterPage);
        }

        async public void GetData()
        {
            var IngredientFromDataStore = await DataStore.GetAllIngredientAsync();

            IngredientList.Clear();
            foreach (var ingredient in IngredientFromDataStore)
            {
                IngredientList.Add(ingredient);
            }
        }

        public void GotoMasterPage()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
