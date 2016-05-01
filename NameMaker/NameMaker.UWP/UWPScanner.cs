using NameMaker.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

[assembly: Xamarin.Forms.Dependency(typeof(UWPScanner))]

namespace NameMaker.UWP
{
    class UWPScanner : IScanner
    {
        MobileBarcodeScanner scanner = new MobileBarcodeScanner();

        async Task<string> IScanner.Barcode()
        {
            var result = await scanner.Scan();
            
            if (result != null)
            {
                return result.Text;
            }

            return null;
        }


    }
}
