using DevExpress.Xpf.PropertyGrid;

namespace ForensicStudio.Core.Control.PropertyGrid;

public class FsPropertyGridControl : PropertyGridControl
{
    public FsPropertyGridControl()
    {
        ShowProperties = ShowPropertiesMode.WithPropertyDefinitions;
        SortMode = PropertyGridSortMode.Definitions;
        ShowCategories = CategoriesShowMode.Hidden;
    }
}