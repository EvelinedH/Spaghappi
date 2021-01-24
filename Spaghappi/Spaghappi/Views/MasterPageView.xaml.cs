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
    public partial class MasterPageView : ContentPage
    {
        MasterPageViewmodel _viewmodel;

        public MasterPageView()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new MasterPageViewmodel();
            image.Source = ImageSource.FromResource("Spaghappi.Images.spaghetti.jpg");
        }

        protected override void OnAppearing()
        {
            _viewmodel.OnAppearing();
        }
    }
}