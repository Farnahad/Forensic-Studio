using System.Collections.Specialized;
using System.Windows;
using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Main.Mvvm;
using Prism.Regions;

namespace ForensicStudio.Core.Control.Mvvm;

public class FsDocumentGroupRegionAdapter : RegionAdapterBase<FsDocumentGroup>
{
    public FsDocumentGroupRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
        : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, FsDocumentGroup regionTarget)
    {
        region.Views.CollectionChanged += (_, args) =>
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                if (args.NewItems != null)
                {
                    foreach (FrameworkElement frameworkElement in args.NewItems)
                        regionTarget.Add(GetFsDocumentPanel(frameworkElement));
                }
            }
            else if (args.Action == NotifyCollectionChangedAction.Remove)
            {
                if (args.OldItems != null)
                {
                    foreach (FrameworkElement frameworkElement in args.OldItems)
                    {
                        var fsDocumentPanel = GetFsDocumentPanel(regionTarget, frameworkElement);
                        if (fsDocumentPanel != null)
                            regionTarget.Remove(fsDocumentPanel);
                    }
                }
            }
        };
    }

    protected override IRegion CreateRegion()
    {
        return new Region();
    }

    private FsDocumentPanel GetFsDocumentPanel(FrameworkElement content)
    {
        var viewModel = (ViewModel)content.DataContext;

        var fsDocumentPanel = new FsDocumentPanel
        {
            Caption = viewModel.Title,
            Content = content,
            IsActive = true
        };

        return fsDocumentPanel;
    }

    private FsDocumentPanel GetFsDocumentPanel(FsDocumentGroup fsDocumentGroup, FrameworkElement content)
    {
        foreach (var baseLayoutItem in fsDocumentGroup.Items)
        {
            var fsDocumentPanel = (FsDocumentPanel)baseLayoutItem;
            if (fsDocumentPanel != null && Equals(fsDocumentPanel.Content, content))
                return fsDocumentPanel;
        }

        return null;
    }
}