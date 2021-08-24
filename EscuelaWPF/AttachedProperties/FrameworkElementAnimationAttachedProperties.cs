
using System.Windows;

namespace EscuelaWPF
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation on false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BasedAttachedProperty<Parent, bool>
        where Parent : BasedAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties

        public bool FirstLoad { get; set; } = true;

        #endregion
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (sender is not FrameworkElement element)
            {
                return;
            }

            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
            {
                return;
            }

            if (FirstLoad)
            {
                //Create a single self-unhookable event
                //for the element Loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    element.Loaded -= onLoaded;

                    //Do desired animation
                    DoAnimation(element, (bool)value);

                    FirstLoad = false;
                };

                //Hood into the loaded event 
                element.Loaded += onLoaded;
            } else
            {
                DoAnimation(element, (bool)value);
            }
        }
        /// <summary>
        /// Animation method that is fired when the value changes
        /// </summary>
        /// <param name="element"> The element to animate</param>
        /// <param name="value"> The boolean action </param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {

        }
    }

    /// <summary>
    /// Animates sliding out to the left and unsliding
    /// </summary>
    public class AnimatedSlideInFromLeftProperty : AnimateBaseProperty<AnimatedSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, false);
            } else
            {
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, false);
            }
        }
    }

    public class AnimatedSlideInFromBottomProperty : AnimateBaseProperty<AnimatedSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, false);
            }
            else
            {
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom);
            }
        }
    }

    public class AnimatedFadeInProperty : AnimateBaseProperty<AnimatedFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.FadeInAsync(false);
            }
            else
            {
                await element.FadeOutAsync();
            }
        }
    }
}
