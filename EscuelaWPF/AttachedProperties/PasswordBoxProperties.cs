using System;
using System.Windows;
using System.Windows.Controls;

namespace EscuelaWPF
{
    class PasswordBoxProperties
    {
        
    }
    /// <summary>
    /// The Monitor Password attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty: BasedAttachedProperty<HasTextProperty, bool> 
    {
        /// <summary>
        /// Set the has text value based on if the caller has any text
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            HasTextProperty.SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
    /// <summary>
    /// The Has Text attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty: BasedAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get caller
            var passwordBox = sender as PasswordBox;

            // Make sure it is a password box
            if (passwordBox == null)
                return;

            // Remove previous event
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // If monitor password property was set to true
            if ((bool)e.NewValue)
            {
                //set default value 
                HasTextProperty.SetValue(passwordBox);
                // start listening out for password change
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }
}
