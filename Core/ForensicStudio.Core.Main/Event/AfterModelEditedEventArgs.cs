using ForensicStudio.DataAccess.Model.Core;

namespace ForensicStudio.Core.Main.Event;

public class AfterModelEditedEventArgs
{
    public IDbModel DbModel { get; set; }
    public string ViewModelName { get; set; }
}