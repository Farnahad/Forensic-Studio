using ForensicStudio.Core.Main.Command;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.Hibernate;

public class HibernateViewModel : GeneralViewModel
{
    private readonly HibernateExtractor _hibernateExtractor;

    public HibernateViewModel(IContainerService containerService,
        HibernateExtractor hibernateExtractor) : base(containerService)
    {
        _hibernateExtractor = hibernateExtractor;
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
        var methodResult = _hibernateExtractor.GetHibernate();

        if (methodResult.IsSuccess)
            Hibernate = methodResult.Result;
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        Hibernate = null;
    }

    private void Help()
    {
    }

    private Logic.Windows.Model.Hibernate _hibernate;
    public Logic.Windows.Model.Hibernate Hibernate
    {
        get => _hibernate;
        set
        {
            _hibernate = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}