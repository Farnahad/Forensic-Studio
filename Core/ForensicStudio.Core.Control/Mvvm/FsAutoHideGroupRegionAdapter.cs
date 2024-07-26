using System.Collections.Specialized;
using System.Windows;
using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Main.Mvvm;
using Prism.Regions;

namespace ForensicStudio.Core.Control.Mvvm;

public class FsAutoHideGroupRegionAdapter : RegionAdapterBase<FsAutoHideGroup>
{
    public FsAutoHideGroupRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
        : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, FsAutoHideGroup regionTarget)
    {
        region.Views.CollectionChanged += (_, args) =>
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                if (args.NewItems != null)
                {
                    foreach (FrameworkElement frameworkElement in args.NewItems)
                    {
                        regionTarget.Add(GetFsLayoutPanel(frameworkElement));
                    }
                }
            }
            else if (args.Action == NotifyCollectionChangedAction.Remove)
            {
                if (args.OldItems != null)
                {
                    foreach (FrameworkElement frameworkElement in args.OldItems)
                    {
                        var fsLayoutPanel = GetFsLayoutPanel(regionTarget, frameworkElement);
                        if (fsLayoutPanel != null)
                            regionTarget.Remove(fsLayoutPanel);
                    }
                }
            }
        };
    }

    protected override IRegion CreateRegion()
    {
        return new Region();
    }

    private FsLayoutPanel GetFsLayoutPanel(FrameworkElement content)
    {
        var viewModel = (ViewModel)content.DataContext;

        var fsLayoutPanel = new FsLayoutPanel
        {
            Caption = viewModel.Title,
            Content = content,
            IsActive = true
        };

        return fsLayoutPanel;
    }

    private FsLayoutPanel GetFsLayoutPanel(FsAutoHideGroup fsAutoHideGroup, FrameworkElement content)
    {
        foreach (var baseLayoutItem in fsAutoHideGroup.Items)
        {
            var fsLayoutPanel = (FsLayoutPanel)baseLayoutItem;
            if (fsLayoutPanel != null && Equals(fsLayoutPanel.Content, content))
                return fsLayoutPanel;
        }

        return null;
    }
}