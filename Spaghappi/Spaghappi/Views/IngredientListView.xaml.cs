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
    public partial class IngredientListView : ContentPage
    {
        public IngredientListView()
        {
            InitializeComponent();
            BindingContext = new IngredientListViewmodel();
            image.Source = ImageSource.FromResource("Spaghappi.Images.spaghetti.jpg");
        }
    }
}