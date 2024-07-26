using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace ForensicStudio.Core.Control.Mvvm;

public class FsStackPanelRegionAdapter : RegionAdapterBase<StackPanel>
{
    public FsStackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
        : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, StackPanel regionTarget)
    {
        region.Views.CollectionChanged += (_, args) =>
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                if (args.NewItems != null)
                {
                    foreach (FrameworkElement frameworkElement in args.NewItems)
                        regionTarget.Children.Add(frameworkElement);
                }
            }
            else if (args.Action == NotifyCollectionChangedAction.Remove)
            {
                if (args.OldItems != null)
                {
                    foreach (FrameworkElement frameworkElement in args.OldItems)
                        regionTarget.Children.Remove(frameworkElement);
                }
            }
        };
    }

    protected override IRegion CreateRegion()
    {
        return new Region();
    }
}