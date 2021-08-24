using EscuelaWPF.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {


        #region Dependency Properties
        /// <summary>
        /// Registers the current page to show in the page host
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged ));

        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel), typeof(PageHost), new UIPropertyMetadata());

        #endregion
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            var currentPage = d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            var oldPageContent = newPageFrame.Content;

            newPageFrame.Content = null;

            oldPageFrame.Content = oldPageContent;
            
            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;

                _ = Task.Delay(millisecondsDelay: (int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                  {
                    //oldPageFrame.Content = null;
                });
            }

            newPageFrame.Content = new ApplicationPageValueConverter().Convert(currentPage, null, currentPageViewModel);

            return value;
        }



        #region Contructor
        public PageHost()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
