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
    public partial class AddIngredientView : ContentPage
    {
        public AddIngredientView(Ingredient ingredient)
        {
            InitializeComponent();
            BindingContext = new AddIngredientViewmodel(ingredient);
            image.Source = ImageSource.FromResource("Spaghappi.Images.spaghetti.jpg");
        }
    }
}