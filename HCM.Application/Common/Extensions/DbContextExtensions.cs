using Microsoft.EntityFrameworkCore.Metadata;

namespace HCM.Application.Common.Extensions
{
    public static class DbContextExtensions
    {
        public static string? GetPrimaryKeyColumnName(this DbContext dbContext, Type type)
        {
            var entityType = dbContext.Model.FindEntityType(type);

            // Table info 
            var tableName = entityType!.GetTableName();
            var tableSchema = entityType!.GetSchema();

            // Column info 
            foreach (var property in entityType!.GetProperties())
            {
                if (property.IsPrimaryKey())
                {
                    var store = StoreObjectIdentifier.Table(tableName!);
                    var columnName = property.GetColumnName(store);
                    //var columnType = property.GetColumnType();
                    return columnName;
                }
            };
            return null;
        }
    }
}
