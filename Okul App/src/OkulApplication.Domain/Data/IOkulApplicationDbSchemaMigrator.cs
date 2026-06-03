using System.Threading.Tasks;

namespace OkulApplication.Data;

public interface IOkulApplicationDbSchemaMigrator
{
    Task MigrateAsync();
}
