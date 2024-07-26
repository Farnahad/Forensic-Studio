using System.Windows.Data;

namespace ForensicStudio.Core.Main.Application;

public class FsBinding : Binding
{
    public FsBinding()
    {
        Mode = BindingMode.TwoWay;
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        ValidatesOnDataErrors = true;
        NotifyOnSourceUpdated = true;
    }
}