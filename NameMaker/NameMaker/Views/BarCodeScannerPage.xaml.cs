using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NameMaker
{
    public partial class BarCodeScannerPage : ContentPage
    {
        public BarCodeScannerPage()
        {
            InitializeComponent();

        }

        async void ScanClick(object sender, EventArgs e)
        {

            var barcode = DependencyService.Get<IScanner>();
            var barcodeResult = await barcode.Barcode();

            if (barcodeResult != null)
            {

                ScanResult.Text = barcodeResult;
            }

        }

    }
}
