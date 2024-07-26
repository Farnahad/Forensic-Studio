using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.PageFile;

public class PageFileViewModel : GeneralViewModel
{
    private readonly PageFileExtractor _pageFileExtractor;

    public PageFileViewModel(IContainerService containerService,
    PageFileExtractor pageFileExtractor) : base(containerService)
    {
        _pageFileExtractor = pageFileExtractor;
    }

    public FsCommand LoadCommand { get; set; }
    public FsCommand ClearCommand { get; set; }
    public FsCommand HelpCommand { get; set; }

    protected override void InitialCommands()
    {
        LoadCommand = new FsCommand(Load);
        ClearCommand = new FsCommand(Clear);
        HelpCommand = new FsCommand(Help);
    }

    private void Load()
    {
        var methodResult = _pageFileExtractor.GetPageFiles();

        if (methodResult.IsSuccess)
            PageFiles = new ObservableCollection<Logic.Windows.Model.PageFile>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        PageFiles = new ObservableCollection<Logic.Windows.Model.PageFile>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.PageFile> _pageFiles;
    public ObservableCollection<Logic.Windows.Model.PageFile> PageFiles
    {
        get => _pageFiles;
        set
        {
            _pageFiles = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.PageFile _currentPageFile;
    public Logic.Windows.Model.PageFile CurrentPageFile
    {
        get => _currentPageFile;
        set
        {
            _currentPageFile = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}