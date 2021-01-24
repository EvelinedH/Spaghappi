using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spaghappi.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace Spaghappi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerView : ContentPage
    {
        ScannerViewmodel vm;
        public ScannerView()
        {
            InitializeComponent();
            scanView.Options.TryHarder = true;
            scanView.ToggleTorch();
            BindingContext = vm = new ScannerViewmodel();
            image.Source = ImageSource.FromResource("Spaghappi.Images.spaghetti.jpg");
        }
        public void scanView_OnScanResult(Result result)
        {
            scanView.IsScanning = false;
            
            vm.scanView_OnScanResult(result);
        }       
    }
}