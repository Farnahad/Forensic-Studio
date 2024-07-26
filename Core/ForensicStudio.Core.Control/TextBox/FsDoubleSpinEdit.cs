namespace ForensicStudio.Core.Control.TextBox;

public class FsDoubleSpinEdit : FsSpinEdit
{
    public FsDoubleSpinEdit()
    {
        EditValueType = typeof(double);
        IsFloatValue = true;
        Mask = "N2";
    }
}