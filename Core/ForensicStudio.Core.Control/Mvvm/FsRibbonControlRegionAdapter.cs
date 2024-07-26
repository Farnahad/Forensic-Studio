using DevExpress.Xpf.Ribbon.Internal;
using ForensicStudio.Core.Control.Ribbon;
using Prism.Regions;

namespace ForensicStudio.Core.Control.Mvvm;

public class FsRibbonControlRegionAdapter : RegionAdapterBase<FsRibbonControl>
{
    public FsRibbonControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
        : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, FsRibbonControl fsRibbonControl)
    {
        region.Views.CollectionChanged += (_, e) =>
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems != null)
                {
                    foreach (IRibbonItem element in e.NewItems)
                        fsRibbonControl.Items.Add(element);
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                if (e.OldItems != null)
                {
                    foreach (IRibbonItem element in e.OldItems)
                        fsRibbonControl.Items.Remove(element);
                }
            }
        };
    }

    protected override IRegion CreateRegion()
    {
        return new AllActiveRegion();
    }
}