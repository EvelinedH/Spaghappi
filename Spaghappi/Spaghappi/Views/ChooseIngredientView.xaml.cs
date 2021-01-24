using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spaghappi.Models;
using Spaghappi.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spaghappi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseIngredientView : ContentPage
    {
        ChooseIngredientViewmodel vm;
        public ChooseIngredientView()
        {
            InitializeComponent();
            BindingContext = vm = new ChooseIngredientViewmodel();
            image.Source = ImageSource.FromResource("Spaghappi.Images.spaghetti.jpg");
        }
        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            vm.ListView_ItemSelected(sender, e);
        }


    }
}