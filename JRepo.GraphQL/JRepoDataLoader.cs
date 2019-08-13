using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using JRepo.Core;

namespace JRepo.GraphQL
{
    public class JRepoDataLoader<TKey, T> : IDataLoader<T>, IDataLoader<TKey, T> where T : IId<TKey>
    {
        private readonly IRepository<TKey, T> _repository;

        public JRepoDataLoader(IRepository<TKey, T> repository)
        {
            _repository = repository;
        }

        public async Task<T> LoadAsync()
        {
            return _repository.Queryable().FirstOrDefault();
        }

        public async Task<T> LoadAsync(TKey key)
        {
            return _repository.Queryable().FirstOrDefault(it => it.Id.Equals(key));
        } 
    }
}