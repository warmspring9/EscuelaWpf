using EscuelaWPF.Core;
using EscuelaWPF.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            // Finds the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage((LoginViewModel)parameter);
                case ApplicationPage.Menu:
                    return new MenuPage((MenuViewModel)parameter);
                case ApplicationPage.TeacherDetails:
                    return new TeacherDetailsPage((TeacherDetailViewModel)parameter);
                case ApplicationPage.StudentDetails:
                    return new StudentDetailsPage((StudentDetailViewModel)parameter);
                case ApplicationPage.GuardianDetails:
                    return new GuardianDetailsPage((GuardianDetailViewModel)parameter);
                case ApplicationPage.SectionDetails:
                    return new SectionDetailsPage((SectionDetailViewModel)parameter);
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
