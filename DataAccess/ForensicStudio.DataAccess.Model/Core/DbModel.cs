using System.ComponentModel.DataAnnotations;

namespace ForensicStudio.DataAccess.Model.Core;

public abstract class DbModel : IDbModel
{
    public int Id { get; protected set; }
    [Timestamp]
    public byte[] RowVersion { get; protected set; }

    public abstract string GetModelName();
    public abstract string GetPluralModelName();
    public new abstract string ToString();
}