using EscuelaWPF.Core;
using EscuelaWPF.Interfaces;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for DialogMessageBox.xaml
    /// </summary>
    public partial class AddStudentBox : BaseDialogUserControl, ICloseable
    {
        public AddStudentBox()
        {
            InitializeComponent();

        }

        public void Close()
        {
            base.CLose();
        }
        private void GuardianField_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            string temp = GuardianField.Text;
            if (temp.Length >= 8 && temp != null)
            {
                try
                {
                    GuardianResult.Text = IoC.GuardianService.GetbyId(temp).Result.ToString();
                }
                catch
                {
                    GuardianResult.Text = "Encargado no encontrado";
                }
            }
            
        }

        private void SectionField_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            string temp = SectionField.Text;
            if (temp.Length != null && temp != "")
            {
                try
                {
                    SectionResult.Text = IoC.SectionService.GetbyId(temp).Result.ToString();
                }
                catch
                {
                    SectionResult.Text = "Seccion no encontrada";
                }
                
            }
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddStudentBoxViewModel context = (AddStudentBoxViewModel)DataContext;
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

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            AddStudentBoxViewModel context = (AddStudentBoxViewModel)DataContext;
            // Subir imagen
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
                context.Image = imageText.Text = Convert.ToBase64String(Encode(temp, format));
                context.Extension = ",." + format;
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
            AddStudentBoxViewModel cont = (AddStudentBoxViewModel)this.DataContext;
            cont.ExpirationDate = datePicker2.SelectedDate.ToString();
        }
    }
}
