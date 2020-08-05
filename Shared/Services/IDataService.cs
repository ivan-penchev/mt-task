using System.Threading.Tasks;
namespace Shared.Services
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
