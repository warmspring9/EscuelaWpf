using EscuelaWPF.Core;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.QrCode;

namespace EscuelaWPF
{
    /// <summary>
    /// A converter that takes a string a return a qr code of its code
    /// </summary>
    public class StringToQr : BaseValueConverter<StringToQr>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = "";
            if (value.GetType() == typeof(TextEntryViewModel))
            {
                s = (value as TextEntryViewModel).OriginalText;
            } else
            {
                return defaultImage();
            }
            QrCodeEncodingOptions options = new()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250,
            };
            BarcodeWriter writer = new()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };

            if (String.IsNullOrEmpty(s) || String.IsNullOrWhiteSpace(s))
            {
                return defaultImage();
            } else
            {
                var qr = new ZXing.BarcodeWriter();
                qr.Options = options;
                qr.Format = ZXing.BarcodeFormat.QR_CODE;
                Bitmap result = new(qr.Write(s));
                return ToBitmapImage(result);
            }
            
        }

        public BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }


        public BitmapImage defaultImage()
        {
            string alt = "/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAAAeAAD/4QMvaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzEzOCA3OS4xNTk4MjQsIDIwMTYvMDkvMTQtMDE6MDk6MDEgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDQyAyMDE3IChXaW5kb3dzKSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo5RjhGRDhDMjg2OEQxMUU3OTkxQ0Y0M0JBQ0I2RENFQyIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo5RjhGRDhDMzg2OEQxMUU3OTkxQ0Y0M0JBQ0I2RENFQyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjlGOEZEOEMwODY4RDExRTc5OTFDRjQzQkFDQjZEQ0VDIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjlGOEZEOEMxODY4RDExRTc5OTFDRjQzQkFDQjZEQ0VDIi8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+/+4ADkFkb2JlAGTAAAAAAf/bAIQAEAsLCwwLEAwMEBcPDQ8XGxQQEBQbHxcXFxcXHx4XGhoaGhceHiMlJyUjHi8vMzMvL0BAQEBAQEBAQEBAQEBAQAERDw8RExEVEhIVFBEUERQaFBYWFBomGhocGhomMCMeHh4eIzArLicnJy4rNTUwMDU1QEA/QEBAQEBAQEBAQEBA/8AAEQgAqgCqAwEiAAIRAQMRAf/EAGgAAQEBAQEBAAAAAAAAAAAAAAAFBAMCAQEBAAAAAAAAAAAAAAAAAAAAABAAAgECAwUIAwEBAAAAAAAAAAECAwQRUhQhMZGhEkFRcYHBMhMzsSJyYdERAQAAAAAAAAAAAAAAAAAAAAD/2gAMAwEAAhEDEQA/AN4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAdbeg608N0VvYHIFNW9BLDoXntPvwUckeAEsFT4KOSPAfBRyR4ASwVPgo5I8B8FHJHgBLBU+CjkjwHwUckeAEsFT4KOSPAfBRyR4ASwVPgo5I8B8FHJHgBLBU+CjkjwM9zaxUXOmsMN8QMYAAAAAAABusPZLx9DCbrD65ePoByvZyVVJNpYLYjh1zzPidr77l/KPFvRdaeG6K3sDx1zzPiOueZ8SlGhSisFBeLWLOda0pzi3BdMuzDcwMPXPM+I655nxPLTTwe9AD11zzPiOueZ8TyAPXXPM+I655nxPIA9dc8z4jrnmfE8gD18k8z4lR7YPHtRJKz9nkBJAAAAAAAAN1h9cvH0MJusPrl4+gHG++5fyjtYYfHLvx9Djffcv5R4t67ozxe2L3oCmDxGtSmsYyRyrXVOmmovqn2JbgMlzh888O85Btttva3vAAA0W1s6r6pbILmB8t7Z1f2lsh3954rUZUpdMt3Y+8ppJLBbEtyPNSnGpFxktn4AlA6VqMqUumW7sfecwBWfs8iSVn7PICSAAAAAAAAbrD65ePoYTdYfXLx9AON99y/lepnNF99y/lflmcAD6k5NRisW9yKFC2jTj+y6pS3/8AnA0XNs6T6o7YPkLa2dR9c9kPyAtrZ1H1z2QXM3pJLBbEgkksFsSPoAAAeKlONSLjJbPwTq1GVKXTLd2PvKh4qU41IuMls/AEorP2eRJKz9nkBJAAAAAAAAN1h9cvH0MJusPrl4+gHG++5fyvyzgk5NRisW9yO999y/lflnaxhHoc8P2xwx/wD3b26pLF7Zve+47gAfGk1g9qe9BJJYLYkfQAAAAAAAABHe8rP2eRJe8rP2eQEkAAAAAAAA3WH1y8fQwm6wf6SX+gcb77l/K/LOlpWpQpYTkk8XsF3RqzqKUI4rDA4aavkfIDdqaGdDU0M6MOmr5HyGmr5HyA3amhnQ1NDOjDpq+R8hpq+R8gN2poZ0NTQzow6avkfIaavkfIDdqaGdDU0M6MOmr5HyGmr5HyA3amhnQ1NDOjDpq+R8hpq+Rgcis/Z5E7TV8jKMtkHj2ICSAAAAAAAAdKNaVGfUtqe9HMAUFeUGsW2n3NH3V2+bkycAKOrt83JjV2+bkycAKOrt83JjV2+bkycAKOrt83JjV2+bkycAKOrt83JjV2+bkycAKOrt83JjV2+bkycAKOrt83JnC4u+uLhT2Re9vtMoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/9k=";

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(alt));
            bi.EndInit();
            return bi;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

