using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ForensicStudio.DataAccess.Model.Core;

namespace ForensicStudio.DataAccess.Wrapper.Core;

public class ModelWrapper<T> : NotifyDataErrorInfoBase, IValidatableObject where T : IDbModel
{
    public int Id => DbModel.Id;

    public T DbModel { get; set; }

    public ModelWrapper()
    {
    }

    public ModelWrapper(T dbModel)
    {
        if (dbModel == null)
            throw new ArgumentException("DbModel");

        DbModel = dbModel;
        Validate();
    }


    #region General

    protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
    {
        // ReSharper disable once PossibleNullReferenceException
        return (TValue)typeof(T).GetProperty(propertyName).GetValue(DbModel);
    }

    protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
    {
        // ReSharper disable once PossibleNullReferenceException
        typeof(T).GetProperty(propertyName).SetValue(DbModel, value);
        OnPropertyChanged(propertyName);
        ValidatePropertyInternal(propertyName, value);

        var propertyInfo = DbModel.GetType().GetProperty(propertyName);
        // ReSharper disable once PossibleNullReferenceException
        var currentValue = propertyInfo.GetValue(DbModel);

        if (Equals(currentValue, value) == false)
        {
            propertyInfo.SetValue(DbModel, value);
            Validate();
            OnPropertyChanged(propertyName);
            OnPropertyChanged(propertyName + "IsChanged");
        }
    }

    #endregion


    #region Validation

    protected virtual IEnumerable<string> ValidateProperty(string propertyName)
    {
        return null;
    }

    private void Validate()
    {
        ClearErrors();

        var results = new List<ValidationResult>();
        var context = new ValidationContext(DbModel);

        try
        {
            Validator.TryValidateObject(this, context, results, true);
        }
        catch (Exception)
        {
        }

        if (results.Any())
        {
            var propertyNames = results.SelectMany(r => r.MemberNames).Distinct().ToList();

            foreach (var propertyName in propertyNames)
            {
                ErrorsByPropertyName[propertyName] = results
                    .Where(r => r.MemberNames.Contains(propertyName))
                    .Select(r => r.ErrorMessage)
                    .Distinct()
                    .ToList();

                OnErrorsChanged(propertyName);
            }
        }

        OnErrorsChanged(nameof(HasErrors));
    }

    private void ValidatePropertyInternal(string propertyName, object currentValue)
    {
        ClearErrors(propertyName);
        ValidateDataAnnotations(propertyName, currentValue);
        ValidateCustomErrors(propertyName);
    }

    private void ValidateDataAnnotations(string propertyName, object currentValue)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(DbModel) { MemberName = propertyName };
        Validator.TryValidateProperty(currentValue, context, results);

        foreach (var error in results)
            AddError(propertyName, error.ErrorMessage);
    }

    private void ValidateCustomErrors(string propertyName)
    {
        var errors = ValidateProperty(propertyName);
        if (errors != null)
        {
            foreach (var error in errors)
                AddError(propertyName, error);
        }
    }

    #endregion


    #region IValidatableObject

    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        yield break;
    }

    #endregion
}