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
    class NewIngredientViewmodel
    {
        public String PageTitle { get; set; }
        public String productName { get; set; }
        public String Barcode { get; set; }
        public int Quantity { get; set; }
        public String bc { get; set; }
        public Command OkCommand { get; set; }
        public ObservableCollection<Ingredient> IngredientList { get; set; }
        public IDataStore DataStore => DependencyService.Get<IDataStore>();
        public Ingredient i { get; set; }
        public NewIngredientViewmodel(String barcode)
        {
            PageTitle = "Niew product";
            Ingredient i = new Ingredient();
            bc = barcode;
            OkCommand = new Command(Nieuw);
            i.Barcode = barcode;
        }
        async public void Nieuw()
        {
            productName = this.productName;
            DataStore.AddIngredient(new Ingredient() { ProductName = productName, Barcode = bc, Quantity = 1 });
            await App.Current.MainPage.Navigation.PopToRootAsync();
            await App.Current.MainPage.Navigation.PushAsync(new ScannerView());
            await DataStore.GetAllIngredientAsync();
        }
    }
}
