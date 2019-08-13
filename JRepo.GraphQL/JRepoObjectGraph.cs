using GraphQL.Types;
using JRepo.Core;

namespace JRepo.GraphQL
{
    public class JRepoObjectGraph<TKey, T> : ObjectGraphType<T> where T : IId<TKey>
    {
        private readonly object _repository;

        public JRepoObjectGraph(IRepository<TKey, T> repository)
        {
            _repository = repository;
            
            Field<TKey, T>()
                .Name(typeof(T).Name).ResolveAsync(context =>
                {
                    cont
                })
        }
    }
}