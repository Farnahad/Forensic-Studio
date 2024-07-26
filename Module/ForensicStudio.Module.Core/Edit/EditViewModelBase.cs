using System.Linq;
using System.Threading.Tasks;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Core.Main.Event;
using ForensicStudio.Core.Main.Window;
using ForensicStudio.DataAccess.Model.Core;
using ForensicStudio.DataAccess.Wrapper.Core;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;
using ForensicStudio.Service.Core.Crud;
using Microsoft.EntityFrameworkCore;

namespace ForensicStudio.Module.Core.Edit;

public abstract class EditViewModelBase<TModel, TModelWrapper> : GeneralViewModel
    where TModel : IDbModel, new()
    where TModelWrapper : ModelWrapper<TModel>, new()
{
    private readonly ICrudService<TModel> _crudService;

    public EditViewModelBase(IContainerService containerService,
        ICrudService<TModel> crudService) : base(containerService)
    {
        _crudService = crudService;
    }

    public FsCommand SaveCommand { get; set; }
    public FsCommand DeleteCommand { get; set; }
    public FsCommand CancelCommand { get; set; }

    protected override void InitialCommands()
    {
        base.InitialCommands();

        SaveCommand = new FsCommand(Save, CanSave);
        DeleteCommand = new FsCommand(Delete, CanDelete);
        CancelCommand = new FsCommand(Cancel);
    }

    public override async Task LoadAsync()
    {
        TModel model;
        if (ContainsParameter("Id"))
        {
            var id = GetParameter<int>("Id");
            model = await _crudService.GetByIdAsync(id);
            Title = $"Edit {model.GetModelName()}";
        }
        else
        {
            model = CreateNewModel();
        }

        InitializeModel(model);
    }

    protected virtual TModel CreateNewModel()
    {
        var model = new TModel();
        _crudService.Add(model);
        return model;
    }

    private void InitializeModel(TModel model)
    {
        Model = new TModelWrapper
        {
            DbModel = model
        };
        Model.PropertyChanged += (_, e) =>
        {
            if (IsChanged == false)
                IsChanged = _crudService.HasChanges();

            if (e.PropertyName == nameof(Model.HasErrors))
                SaveCommand.RaiseCanExecuteChanged();
        };

        Title = $"Add {Model.DbModel.GetModelName()}";
        SaveCommand.RaiseCanExecuteChanged();
    }

    protected virtual async void Save()
    {
        try
        {
            await _crudService.SaveAsync();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            var databaseValues = await exception.Entries.Single().GetDatabaseValuesAsync();
            if (databaseValues == null)
            {
                MessageBoxService.ShowInfo("The entity has been deleted by another user");
                RaiseAfterModelDeletedEvent();
                return;
            }

            var result = MessageBoxService.ShowYesNo(
                "The entity has been changed in the meantime by someone else. Click OK " +
                "to save your changes anyway, click cancel to reload the entity from the database.", "Question");

            if (result == true)
            {
                var entry = exception.Entries.Single();
                // ReSharper disable once MethodHasAsyncOverload
                entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                await _crudService.SaveAsync();
            }
            else
            {
                await exception.Entries.Single().ReloadAsync();
                await LoadAsync();
            }
        }

        IsChanged = _crudService.HasChanges();
        RaiseAfterModelEditedEvent();
        WindowService.Close(this, WindowResult.Ok);
    }

    protected virtual bool CanSave()
    {
        return Model is { HasErrors: false } && IsChanged;
    }

    protected virtual async void Delete()
    {
        if (await _crudService.CanRemove(Model.DbModel) == false)
        {
            MessageBoxService.ShowCaNotBeDeletedMessage(Model.DbModel);
            return;
        }

        var result = MessageBoxService.ShowYesNo(
            $"Do you really want to delete the friend \"{Model.DbModel.ToString()}\"", "Question");

        if (result == true)
        {
            _crudService.Remove(Model.DbModel);
            await _crudService.SaveAsync();
            RaiseAfterModelDeletedEvent();
            WindowService.Close(this, WindowResult.Ok);
        }
    }

    private bool CanDelete()
    {
        return Model.DbModel.Id != 0;
    }

    protected virtual void Cancel()
    {
        WindowService.Close(this, WindowResult.Cancel);
    }

    private TModelWrapper _model;
    public TModelWrapper Model
    {
        get => _model;
        protected set
        {
            _model = value;
            OnPropertyChanged();
            DeleteCommand.RaiseCanExecuteChanged();
        }
    }

    private bool _isChanged;
    public bool IsChanged
    {
        get => _isChanged;
        set
        {
            if (_isChanged != value)
            {
                _isChanged = value;
                OnPropertyChanged();

                SaveCommand.RaiseCanExecuteChanged();
            }
        }
    }

    protected virtual void RaiseAfterModelEditedEvent()
    {
        EventAggregator.GetEvent<AfterModelEditedEvent>().Publish(
            new AfterModelEditedEventArgs
            {
                DbModel = Model.DbModel,
                ViewModelName = GetType().Name
            });
    }

    protected virtual void RaiseAfterModelDeletedEvent()
    {
        EventAggregator.GetEvent<AfterModelDeletedEvent>().Publish(
            new AfterModelDeletedEventArgs
            {
                DbModel = Model.DbModel,
                ViewModelName = GetType().Name
            });
    }

    protected override bool CanCloseWindow()
    {
        if (IsChanged)
        {
            var result = MessageBoxService.ShowYesNo(
                "You've made changes. Close this item?", "Question");

            if (result ?? false)
                return true;
        }
        else
            return true;

        return false;
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

    //public ObservableCollection<LookupItem> ProgrammingLanguages { get; }

    //public ObservableCollection<FriendPhoneNumberWrapper> PhoneNumbers { get; }

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