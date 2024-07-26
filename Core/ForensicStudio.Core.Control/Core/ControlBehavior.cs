using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using DevExpress.Xpf.Grid;

namespace ForensicStudio.Core.Control.Core;

public static partial class ControlBehavior
{
    public static FsColumnWidth? GetFsColumnWidth(DependencyObject dependencyObject)
    {
        return (FsColumnWidth?)dependencyObject.GetValue(FsColumnWidthProperty);
    }

    public static void SetFsColumnWidth(DependencyObject obj, FsColumnWidth? value)
    {
        obj.SetValue(FsColumnWidthProperty, value);
    }

    public static readonly DependencyProperty FsColumnWidthProperty =
        DependencyProperty.RegisterAttached("FsColumnWidth", typeof(FsColumnWidth?),
            typeof(DockLayout.ControlBehavior), new PropertyMetadata(null, OnFsColumnWidthChanged));

    private static void OnFsColumnWidthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        var baseColumn = (BaseColumn)dependencyObject;

        var fsColumnWidth = (FsColumnWidth?)e.NewValue;

        if (fsColumnWidth != null)
        {
            if (fsColumnWidth == FsColumnWidth.Star1 || fsColumnWidth == FsColumnWidth.Star2 ||
                fsColumnWidth == FsColumnWidth.Star3)
            {
                baseColumn.Width = 5;
                baseColumn.Width = new GridColumnWidth((double)fsColumnWidth, GridColumnUnitType.Star);
                baseColumn.MinWidth = 5;
            }
            else if (fsColumnWidth == FsColumnWidth.Auto)
                baseColumn.MinWidth = 50;
            else
                baseColumn.MinWidth = (double)fsColumnWidth;
        }
    }


    public static FsControlWidth GetFsControlWidth(DependencyObject dependencyObject)
    {
        return (FsControlWidth)dependencyObject.GetValue(FsControlWidthProperty);
    }

    public static void SetFsControlWidth(DependencyObject dependencyObject, FsControlWidth value)
    {
        dependencyObject.SetValue(FsControlWidthProperty, value);
    }

    public static readonly DependencyProperty FsControlWidthProperty =
        DependencyProperty.RegisterAttached("FsControlWidth", typeof(FsControlWidth),
            typeof(DockLayout.ControlBehavior), new PropertyMetadata(FsControlWidth.Normal, OnMeControlWidthChanged));

    private static void OnMeControlWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var frameworkElement = (FrameworkElement)d;

        var fsControlWidth = (FsControlWidth)e.NewValue;

        if (fsControlWidth == FsControlWidth.Auto)
        {
            frameworkElement.Width = double.NaN;
            frameworkElement.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        else
            frameworkElement.Width = (double)fsControlWidth;
    }


    public static FsFontFamily GetFsFontFamily(DependencyObject dependencyObject)
    {
        return (FsFontFamily)dependencyObject.GetValue(FsFontFamilyProperty);
    }

    public static void SetFsFontFamily(DependencyObject obj, FsFontFamily value)
    {
        obj.SetValue(FsFontFamilyProperty, value);
    }

    public static readonly DependencyProperty FsFontFamilyProperty =
        DependencyProperty.RegisterAttached("FsFontFamily", typeof(FsFontFamily),
            typeof(DockLayout.ControlBehavior), new PropertyMetadata(FsFontFamily.SegoeUi, OnMeFontFamilyChanged));

    private static void OnMeFontFamilyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        var control = (System.Windows.Controls.Control)dependencyObject;

        var fsFontFamily = (FsFontFamily)e.NewValue;

        if (DesignerProperties.GetIsInDesignMode(control) == false)
        {
            switch (fsFontFamily)
            {
                case FsFontFamily.SegoeUi:
                    control.FontFamily = new FontFamily(new Uri(
                        "pack://Application:,,,/Forensic Studio;component/Fonts/"), "./#segoeui");
                    control.FontSize = 13;
                    break;
                case FsFontFamily.Tahoma:
                    break;
                case FsFontFamily.Roboto:
                    break;
            }
        }

        if (DesignerProperties.GetIsInDesignMode(control))
        {
            switch (fsFontFamily)
            {
                case FsFontFamily.SegoeUi:
                    control.FontFamily = new FontFamily("Segoe UI");
                    control.FontSize = 13;
                    break;
                case FsFontFamily.Tahoma:
                    break;
                case FsFontFamily.Roboto:
                    break;
            }
        }
    }


    public static FsFontSize GetFsFontSize(DependencyObject dependencyObject)
    {
        return (FsFontSize)dependencyObject.GetValue(FsFontSizeProperty);
    }

    public static void SetFsFontSize(DependencyObject dependencyObject, FsFontSize value)
    {
        dependencyObject.SetValue(FsFontSizeProperty, value);
    }

    public static readonly DependencyProperty FsFontSizeProperty =
        DependencyProperty.RegisterAttached("FsFontSize", typeof(FsFontSize),
            typeof(DockLayout.ControlBehavior), new PropertyMetadata(FsFontSize.Normal, OnMeFontSizeChanged));

    private static void OnMeFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (System.Windows.Controls.Control)d;

        var fsFontSize = (FsFontSize)e.NewValue;
        control.FontSize = (double)fsFontSize;
    }
}