namespace ForensicStudio.Core.Control.TextBox;

public class FsCurrencySpinEdit : FsIntSpinEdit
{
    public FsCurrencySpinEdit()
    {
        MinValue = 0;
        Mask = "C0";
    }
}