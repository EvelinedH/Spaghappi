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
    public partial class NewIngredientView : ContentPage
    {
        public NewIngredientView(String barcode)
        {
            InitializeComponent();
            BindingContext = new NewIngredientViewmodel(barcode);
            image.Source = ImageSource.FromResource("Spaghappi.Images.spaghetti.jpg");
        }
    }
}