
using Android.App;
using NameMaker.Droid;
using ZXing.Mobile;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(DroidScanner))]

namespace NameMaker.Droid
{
    class DroidScanner : IScanner
    {

        async Task<string> IScanner.Barcode()
        {

            // Creates a new MobileBarcodeScanner variable
            MobileBarcodeScanner scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();
            if(result != null)
            {
                return result.Text;
            }

            return null;
        }

    }
}