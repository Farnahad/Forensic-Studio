using System.Collections;
using System.ComponentModel;

namespace ForensicStudio.DataAccess.Wrapper.Core;

public class NotifyDataErrorInfoBase : NotifyPropertyChangedBase, INotifyDataErrorInfo
{
    protected readonly Dictionary<string, List<string>> ErrorsByPropertyName;

    protected NotifyDataErrorInfoBase()
    {
        ErrorsByPropertyName = new Dictionary<string, List<string>>();
    }

    public IEnumerable GetErrors(string propertyName)
    {
        return ErrorsByPropertyName.ContainsKey(propertyName) ?
            ErrorsByPropertyName[propertyName] : null;
    }

    public bool HasErrors => ErrorsByPropertyName.Any();

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    protected virtual void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        base.OnPropertyChanged(nameof(HasErrors));
    }

    protected void AddError(string propertyName, string error)
    {
        if (ErrorsByPropertyName.ContainsKey(propertyName) == false)
        {
            ErrorsByPropertyName[propertyName] = new List<string>();
        }

        if (ErrorsByPropertyName[propertyName].Contains(error) == false)
        {
            ErrorsByPropertyName[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }
    }

    protected void ClearErrors(string propertyName)
    {
        if (ErrorsByPropertyName.ContainsKey(propertyName))
        {
            ErrorsByPropertyName.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }

    protected void ClearErrors()
    {
        foreach (var propertyName in ErrorsByPropertyName.Keys.ToList())
        {
            ErrorsByPropertyName.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }
}