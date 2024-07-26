using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Core.Main.Event;
using ForensicStudio.DataAccess.Model.Core;
using ForensicStudio.DataAccess.Wrapper.Core;
using ForensicStudio.Module.Core.Edit;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;
using ForensicStudio.Service.Core.Crud;

namespace ForensicStudio.Module.Core.List;

public abstract class ListViewModelBase<TModel, TModelWrapper, TEditView> : GeneralViewModel
    where TModel : IDbModel, new()
    where TModelWrapper : ModelWrapper<TModel>, new()
    where TEditView : EditView, new()
{
    private readonly ICrudService<TModel> _crudService;

    public ListViewModelBase(IContainerService containerService,
        ICrudService<TModel> crudService) : base(containerService)
    {
        _crudService = crudService;

        EventAggregator.GetEvent<AfterModelEditedEvent>()
            .Subscribe(AfterModelEdited);
        EventAggregator.GetEvent<AfterModelDeletedEvent>()
            .Subscribe(AfterModelDeleted);
    }

    public FsCommand NewCommand { get; set; }
    public FsCommand EditCommand { get; set; }
    public FsCommand DeleteCommand { get; set; }

    protected override void InitialCommands()
    {
        base.InitialCommands();

        NewCommand = new FsCommand(New);
        EditCommand = new FsCommand(Edit, CanEdit);
        DeleteCommand = new FsCommand(Delete, CanDelete);
    }

    protected virtual void New()
    {
        WindowService.ShowDialog<TEditView>();
    }

    protected virtual void Edit()
    {
        WindowService.ShowDialog<TEditView>(
            new Tuple<string, object>("Id", CurrentModel.Id));
    }

    protected virtual bool CanEdit()
    {
        return CurrentModel != null;
    }

    protected virtual async void Delete()
    {
        if (await _crudService.CanRemove(CurrentModel.DbModel) == false)
        {
            MessageBoxService.ShowCaNotBeDeletedMessage(CurrentModel.DbModel);
            return;
        }

        var result = MessageBoxService.ShowYesNo(
            $"Do you really want to delete the friend \"{CurrentModel.DbModel.ToString()}\"", "Question");

        if (result == true)
        {
            _crudService.Remove(CurrentModel.DbModel);
            await _crudService.SaveAsync();
            RaiseAfterModelDeletedEvent();
        }
    }

    private bool CanDelete()
    {
        return CurrentModel != null;
    }

    public override async Task LoadAsync()
    {
        Title = new TModel().GetPluralModelName();

        int? currentId = null;
        if (CurrentModel != null)
            currentId = CurrentModel.Id;

        var list = await _crudService.GetAllAsync();
        Models = new ObservableCollection<TModelWrapper>(
            list.Select(item => new TModelWrapper
            {
                DbModel = item
            }));

        CurrentModel = currentId != null ?
            Models.FirstOrDefault(item => item.Id == currentId) : Models.FirstOrDefault();
    }

    private ObservableCollection<TModelWrapper> _models;
    public ObservableCollection<TModelWrapper> Models
    {
        get => _models;
        set
        {
            _models = value;
            OnPropertyChanged();

        }
    }

    private TModelWrapper _currentModel;
    public TModelWrapper CurrentModel
    {
        get => _currentModel;
        set
        {
            _currentModel = value;
            OnPropertyChanged();
            EditCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
        }
    }

    protected virtual void RaiseAfterModelDeletedEvent()
    {
        EventAggregator.GetEvent<AfterModelDeletedEvent>().Publish(
            new AfterModelDeletedEventArgs
            {
                DbModel = CurrentModel.DbModel,
                ViewModelName = GetType().Name
            });
    }

    private async void AfterModelEdited(AfterModelEditedEventArgs afterModelEditedEventArgs)
    {
        if (CurrentModel == null || afterModelEditedEventArgs.DbModel.GetType() == CurrentModel.DbModel.GetType())
        {
            await LoadAsync();

            var currentModel = Models.FirstOrDefault(
                item => item.Id == afterModelEditedEventArgs.DbModel.Id);
            if (currentModel != null)
            {
                CurrentModel = currentModel;
            }
        }
    }

    private async void AfterModelDeleted(AfterModelDeletedEventArgs afterModelDeletedEventArgs)
    {
        if (CurrentModel == null || afterModelDeletedEventArgs.DbModel.GetType() == CurrentModel.DbModel.GetType())
            await LoadAsync();
    }

    //private void InitializeFriendPhoneNumbers(ICollection<FriendPhoneNumber> phoneNumbers)
    //{
    //    foreach (var wrapper in PhoneNumbers)
    //    {
    //        wrapper.PropertyChanged -= FriendPhoneNumberWrapper_PropertyChanged;
    //    }
    //    PhoneNumbers.Clear();
    //    foreach (var friendPhoneNumber in phoneNumbers)
    //    {
    //        var wrapper = new FriendPhoneNumberWrapper(friendPhoneNumber);
    //        PhoneNumbers.Add(wrapper);
    //        wrapper.PropertyChanged += FriendPhoneNumberWrapper_PropertyChanged;
    //    }
    //}

    //private void FriendPhoneNumberWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
    //{
    //    if (!HasChanges)
    //    {
    //        HasChanges = _friendRepository.HasChanges();
    //    }

    //    if (e.PropertyName == nameof(FriendPhoneNumberWrapper.HasErrors))
    //    {
    //        ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
    //    }
    //}

    //private async Task LoadProgrammingLanguageLookupAsync()
    //{
    //    ProgrammingLanguages.Clear();
    //    ProgrammingLanguages.Add(new NullLookupItem { DisplayMember = " - " });
    //    var lookup = await _programmingLanguageLookupDataService.GetProgrammingLanguageLookupAsync();
    //    foreach (var lookupItem in lookup)
    //    {
    //        ProgrammingLanguages.Add(lookupItem);
    //    }
    //}

    //private void OnAddPhoneNumberExecute()
    //{
    //    var newNumber = new FriendPhoneNumberWrapper(new FriendPhoneNumber());
    //    newNumber.PropertyChanged += FriendPhoneNumberWrapper_PropertyChanged;
    //    PhoneNumbers.Add(newNumber);
    //    Friend.Model.FriendPhoneNumbers.Add(newNumber.Model);
    //    newNumber.Number = "";
    //}

    //private void OnRemovePhoneNumberExecute()
    //{
    //    SelectedPhoneNumber.PropertyChanged -= FriendPhoneNumberWrapper_PropertyChanged;
    //    _friendRepository.RemovePhoneNumber(SelectedPhoneNumber.Model);
    //    Friend.Model.FriendPhoneNumbers.Remove(SelectedPhoneNumber.Model);
    //    PhoneNumbers.Remove(SelectedPhoneNumber);
    //    SelectedPhoneNumber = null;
    //    HasChanges = _friendRepository.HasChanges();
    //    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
    //}

    //private bool OnRemovePhoneNumberCanExecute()
    //{
    //    return SelectedPhoneNumber != null;
    //}

    //public ObservableCollection<LookupItem> ProgrammingLanguages { get; }

    //public ObservableCollection<FriendPhoneNumberWrapper> PhoneNumbers { get; }

    //private FriendPhoneNumberWrapper _selectedPhoneNumber;
    //public FriendPhoneNumberWrapper SelectedPhoneNumber
    //{
    //    get { return _selectedPhoneNumber; }
    //    set
    //    {
    //        _selectedPhoneNumber = value;
    //        OnPropertyChanged();
    //        ((DelegateCommand)RemovePhoneNumberCommand).RaiseCanExecuteChanged();
    //    }
    //}

    //public ICommand AddPhoneNumberCommand { get; }

    //public ICommand RemovePhoneNumberCommand { get; }

    //private DataAccess.Model._Pluralsight.Friend CreateNewFriend()
    //{
    //    var friend = new DataAccess.Model._Pluralsight.Friend();
    //    _friendRepository.Add(friend);
    //    return friend;
    //}

    //private async void AfterCollectionSaved(AfterCollectionSavedEventArgs args)
    //{
    //    if (args.ViewModelName == nameof(ProgrammingLanguageDetailViewModel))
    //    {
    //        await LoadProgrammingLanguageLookupAsync();
    //    }
    //}
}