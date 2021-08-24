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
    public partial class SectionDetailsPage : BasePage<SectionDetailViewModel>
    {
        public SectionDetailsPage(SectionDetailViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
