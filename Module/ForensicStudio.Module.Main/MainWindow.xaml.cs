using System;
using System.Windows;

namespace ForensicStudio.Module.Main;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        Closed += OnClosed;
    }

    private void OnClosed(object sender, EventArgs e)
    {
        var pp = Application.Current.Windows;
    }
}