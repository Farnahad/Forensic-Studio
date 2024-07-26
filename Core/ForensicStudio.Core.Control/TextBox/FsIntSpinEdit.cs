namespace ForensicStudio.Core.Control.TextBox;

public class FsIntSpinEdit : FsSpinEdit
{
    public FsIntSpinEdit()
    {
        EditValueType = typeof(int);
        IsFloatValue = false;
        Mask = "D0";
    }
}