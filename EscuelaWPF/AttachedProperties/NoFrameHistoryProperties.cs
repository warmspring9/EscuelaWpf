using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EscuelaWPF
{
    /// <summary>
    /// The no frame history property for creating a frame that dosen't show navigation
    /// </summary>
    public class NoFrameHistoryProperty : BasedAttachedProperty<NoFrameHistoryProperty, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Frame frame = sender as Frame;

            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }

}
