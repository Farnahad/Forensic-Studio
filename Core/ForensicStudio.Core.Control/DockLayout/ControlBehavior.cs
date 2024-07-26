using System.Windows;

// ReSharper disable once Check
namespace ForensicStudio.Core.Control.DockLayout;

public static partial class ControlBehavior
{
    public static FsDockType? GetFsDockType(DependencyObject dependencyObject)
    {
        return (FsDockType?)dependencyObject.GetValue(FsDockTypeProperty);
    }

    public static void SetFsDockType(DependencyObject dependencyObject, FsDockType? value)
    {
        dependencyObject.SetValue(FsDockTypeProperty, value);
    }

    public static readonly DependencyProperty FsDockTypeProperty =
        DependencyProperty.RegisterAttached("FsDockType", typeof(FsDockType?),
            typeof(ControlBehavior), new PropertyMetadata(null));


    public static FsDockPotion? GetFsDockPotion(DependencyObject dependencyObject)
    {
        return (FsDockPotion?)dependencyObject.GetValue(FsDockPotionProperty);
    }

    public static void SetFsDockPotion(DependencyObject dependencyObject, FsDockPotion? value)
    {
        dependencyObject.SetValue(FsDockPotionProperty, value);
    }

    public static readonly DependencyProperty FsDockPotionProperty =
        DependencyProperty.RegisterAttached("FsDockPotion", typeof(FsDockPotion?),
            typeof(ControlBehavior), new PropertyMetadata(null));
}