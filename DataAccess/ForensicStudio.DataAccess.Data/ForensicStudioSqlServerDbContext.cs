using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ForensicStudio.DataAccess.Data;

public class ForensicStudioSqlServerDbContext : ForensicStudioDbContext
{
    private readonly string _connectionString;

    public ForensicStudioSqlServerDbContext(string connectionString) : base()
    {
        _connectionString = connectionString;
    }

    public bool IsRecordUsed<TEntity>(TEntity entity) where TEntity : class
    {
        var entityType = typeof(TEntity);
        var entityEntry = Entry(entity);

        // Get all entity types in the DbContext
        var allEntityTypes = Model.GetEntityTypes();

        foreach (var type in allEntityTypes)
        {
            // Skip the current entity type
            if (type.ClrType == entityType)
                continue;

            // Get the DbSet for the current entity type using reflection
            var setMethod = typeof(DbContext).GetMethod("Set").MakeGenericMethod(type.ClrType);
            var dbSet = setMethod.Invoke(this, null);

            // Get all navigation properties of the current entity type
            var navigationProperties = type.GetNavigations();

            foreach (var navigation in navigationProperties)
            {
                // Check if the navigation property references the target entity type
                if (navigation.TargetEntityType.ClrType == entityType)
                {
                    // Create a query to check if any record references the target entity
                    var query = ((IQueryable<object>)dbSet).AsQueryable();
                    var parameter = Expression.Parameter(type.ClrType, "e");
                    var property = Expression.Property(parameter, navigation.Name);
                    var idProperty = Expression.Property(Expression.Constant(entity), "Id");
                    var equalExpression = Expression.Equal(property, idProperty);
                    var lambda = Expression.Lambda(equalExpression, parameter);
                    var anyMethod = typeof(Queryable).GetMethods()
                        .First(m => m.Name == "Any" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(type.ClrType);

                    var result = (bool)anyMethod.Invoke(null, new object[] { query, lambda });

                    if (result)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(_connectionString);
}