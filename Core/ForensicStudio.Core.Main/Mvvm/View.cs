using System.Windows.Controls;
using DevExpress.Xpf.Core;
using Prism.Mvvm;

namespace ForensicStudio.Core.Main.Mvvm;

public abstract class View : UserControl
{
    public View()
    {
        ViewModelLocator.SetAutoWireViewModel(this, true);

        IsTabStop = false;
        Loaded += async (_, _) =>
        {
            var viewModel = (ViewModel)DataContext;
            if (viewModel != null)
            {
                ViewModel = viewModel;
                ViewModel.View = this;
                await viewModel.LoadAsync();
            }

            SetStartFocus();
        };
        Focusable = false;
        ThemeManager.SetTheme(this, Theme.Office2013DarkGray);
    }

    protected virtual void SetStartFocus()
    {
    }

    public virtual void SetTitle(string title)
    {
    }

    public ViewModel ViewModel { get; set; }
}