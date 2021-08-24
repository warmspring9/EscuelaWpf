using System.Windows;
using System.Windows.Controls;

namespace EscuelaWPF
{
    public class FocusProperty : BasedAttachedProperty<FocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;
            if ((bool)e.NewValue)
                control.Focus();
        }
    }
}
