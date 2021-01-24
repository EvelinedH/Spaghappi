using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spaghappi.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spaghappi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteIngredientView : ContentPage
    {
        DeleteIngredientViewmodel vm;
        public DeleteIngredientView()
        {
            InitializeComponent();
            BindingContext = vm = new DeleteIngredientViewmodel();
            image.Source = ImageSource.FromResource("Spaghappi.Images.spaghetti.jpg");
        }
        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            vm.ListView_ItemSelected(sender, e);
        }
    }
}