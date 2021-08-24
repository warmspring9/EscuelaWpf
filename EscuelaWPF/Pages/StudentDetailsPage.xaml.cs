using EscuelaWPF.Core;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class StudentDetailsPage : BasePage<StudentDetailViewModel>
    {
        public StudentDetailsPage(StudentDetailViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string format = Path.GetExtension(op.FileName);
                format = format.Replace('.', ' ').TrimStart();
                BitmapImage temp = new BitmapImage(new Uri(op.FileName));
                profilePhoto.Source = temp;
                ViewModel.Image = imageText.Text = Convert.ToBase64String(Encode(temp, format));
                ViewModel.Extension = ",." + format;
            }
        }

        private static byte[] Encode(BitmapImage bitmapImage, string format)
        {
            byte[] data = null;
            BitmapEncoder encoder = null;
            switch (format.ToUpper())
            {
                case "PNG":
                    encoder = new PngBitmapEncoder();
                    break;
                case "GIF":
                    encoder = new GifBitmapEncoder();
                    break;
                case "BMP":
                    encoder = new BmpBitmapEncoder();
                    break;
                case "JPG":
                    encoder = new JpegBitmapEncoder();
                    break;
            }
            if (encoder != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                using (var ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    data = ms.ToArray();
                }
            }

            return data;
        }

        private void datePicker2_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            StudentDetailViewModel cont = (StudentDetailViewModel)this.DataContext;
            cont.Expiration_date = (DateTime)datePicker2.SelectedDate;
        }

        private void ChangeDoc(object sender, System.Windows.RoutedEventArgs e)
        {
            StudentDetailViewModel context = (StudentDetailViewModel)DataContext;
            // Subir imagen
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a document";
            op.Filter = "All supported graphics|*.pdf";
            if (op.ShowDialog() == true)
            {
                string format = Path.GetExtension(op.FileName);
                format = format.Replace('.', ' ').TrimStart();
                context.Document = System.Convert.ToBase64String(File.ReadAllBytes(op.FileName)) + ",." + format;
            }
        }
    }

}    

