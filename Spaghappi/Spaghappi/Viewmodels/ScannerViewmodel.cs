using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Spaghappi.Models;
using Spaghappi.Services;
using Spaghappi.Views;
using Xamarin.Forms;
using ZXing;

namespace Spaghappi.Viewmodels
{
    class ScannerViewmodel
    {
        public String PageTitle { get; set; }
        public String barcode { get; set; }
        public Command FinishedCommand { get; set; }
        public Command NextScan { get; set; }
      //  public Result result { get; set; }
        public ObservableCollection<Ingredient> IngredientList { get; set; }
       

        public IDataStore DataStore => DependencyService.Get<IDataStore>();
        public Ingredient _ingredient;
        

        public ScannerViewmodel()
        {
            PageTitle = "Scanner";
            FinishedCommand = new Command(GoBack);
            IngredientList = null;
        }
        public void Again()
        {
            App.Current.MainPage.Navigation.PopToRootAsync();
            App.Current.MainPage.Navigation.PushAsync(new ScannerView());
        } 
        public void GoBack()
        {
            App.Current.MainPage.Navigation.PopToRootAsync();
        }

         async public void scanView_OnScanResult(Result result)
         {
             var IngredientFromDataStore = await DataStore.GetAllIngredientAsync();
             _ingredient = null;
             foreach (var ingredient in IngredientFromDataStore)
             {
                 if (result.Text == ingredient.Barcode)
                 {
                     _ingredient = ingredient;
                     Device.BeginInvokeOnMainThread(async () =>
                     {
                         await App.Current.MainPage.Navigation.PushAsync(new AddIngredientView(_ingredient));
                     });
                 }
             };

             if (_ingredient == null)
             {
                 Device.BeginInvokeOnMainThread(async () =>
                 {
                     bool answer = await App.Current.MainPage.DisplayAlert(
                         "Foutje", "Dit product is niet gekend", "Nieuw product toevoegen", "Cancel");
                     if (answer)
                     {
                         // barcode = result.Text;
                         await App.Current.MainPage.Navigation.PopToRootAsync();
                         await App.Current.MainPage.Navigation.PushAsync(new NewIngredientView(result.Text));
                     }
                     else
                     {
                         result = null;
                         Again();
                     }
                 });
             }
         }
    }
}
