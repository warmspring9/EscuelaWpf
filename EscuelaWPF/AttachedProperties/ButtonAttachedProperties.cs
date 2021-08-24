using System;
using System.Windows;
using System.Windows.Controls;

namespace EscuelaWPF
{
    public class ButtonAttachedPorpeties
    {
    }
    /// <summary>
    /// The is busy property for anything that wants to flag if the control is busy
    /// </summary>
    public class IsBusyProperty : BasedAttachedProperty<IsBusyProperty, bool> { }

    public class IconContentProperty : BasedAttachedProperty<IconContentProperty, string> { }
}
